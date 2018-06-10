using System;
namespace LHBMatchingTest
{
    public class Room
    {
        private int size;
        private string parent;
        private Camper camper;
        public Room(string parentName, int roomSize)
        {
            size = roomSize;
            parent = parentName;
        }
        public Room(int roomSize)
        {
            size = roomSize;
        }

        public int Size { get { return size; } set { size = value; } }

        public string Parent { get { return parent; } set { parent = value; } }

        public Camper Camper 
        { 
            get 
            {
                return camper;
            }
            set 
            {
                camper = value;
            }
        }

        public override string ToString()
        {
            return string.Format("[Room: Size={0}, Parent={1}, Camper={2}]", Size, Parent, Camper);
        }
    }
}
