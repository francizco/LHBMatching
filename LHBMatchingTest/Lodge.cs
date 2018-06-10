using System;
using System.Collections.Generic;

namespace LHBMatchingTest
{
    public class Lodge
    {
        private List<Room> rooms;
        private string name;
        private int capacity;
        private int size = 0;
        private string constraintID;
        private bool wheelchair = false;
        private bool stairs = false;

        public Lodge(){}

        public Lodge(string lodgeName, int size)
        {
            rooms = new List<Room>();
            name = lodgeName;
            capacity = size;
        }

		public Lodge(string lodgeName, int size, bool wheelchair_access, bool has_stairs)
		{
			rooms = new List<Room>();
			name = lodgeName;
			capacity = size;
            wheelchair = wheelchair_access;
            stairs = has_stairs;
		}

        public List<Room> Rooms { get { return rooms; } set { rooms = value; } }

        public string Name 
        { 
            get { return this.name; } 
            set 
            { 
                this.name = value;
                foreach(Room room in rooms)
                {
                    room.Parent = value;
                }
            } 
        }

        public int Capacity
        {
            get { return this.capacity; }
            set 
            {
                this.capacity = value;
            }
        }

        public bool isFull() { return rooms.Count == capacity; }

        public void AddRoom(Room room)
        {
            rooms.Add(room);

            if (capacity == 0) { constraintID = room.ToString(); }

            size += 1;
        }

        public void RemoveRoom(Room room)
        {
            if(rooms.Contains(room)) { rooms.Remove(room); size -= 1; }
            if (capacity == 0) { constraintID = ""; }
        }

        public bool isEmpty() { return size == 0; }

        public List<Camper> GetCampers()
        {
            List<Camper> campers = new List<Camper>();
            foreach(Room room in rooms)
            {
                campers.Add(room.Camper);
            }
            return campers;
        }

        public bool RoomateMatch(Camper c)
        {
            foreach(Room r in Rooms)
            {
                if (c.Constraints.isRoomateMatch(r.Camper.CamperName)) { return true; }
            }
            return false;
        }

        public Camper Rearrange(Camper camper)
        {
            Room result = null;
            int index = 0;
            bool success = false;
            Room[] roomlist = new Room[rooms.Count];
            rooms.CopyTo(roomlist);
            // Find a camper that can be replaced
            // Will get the most recent
            for (int i = 0; i < rooms.Count; i++)
            {
                Room r = roomlist[i];
                foreach(Room room in rooms)
                {
                    if(!room.Camper.Constraints.isRoomateMatch(r.Camper.CamperName))
                    {
                        result = r;
                        index = i;
                    }
                }
            }

            if (result == null) { return null; }

			// Check if the incoming camper is a match
			foreach (Room room in rooms)
			{
				if (room.Camper.Constraints.isRoomateMatch(camper.CamperName))
				{
					success = true;
				}
			}

            // swap campers
            if (success)
            {
                Camper previous = rooms[index].Camper;
                rooms[index].Camper = camper;
                return previous;
            }
            else { return null; }

        }

    }
}
