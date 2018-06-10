using System;
using System.Collections;
using System.Collections.Generic;
namespace LHBMatchingTest
{
    public class Match
    {
        private Dictionary< int, List<Lodge> > _matchList;
        private List<int> _hashList;
        public Match()
        {
            _matchList = new Dictionary<int, List<Lodge>>();
            _hashList = new List<int>();
        }

        // Assumes there is the same number of elementsw in Campers and Constraints
        public List<Lodge> MatchCamperRooms(List<Camper> Campers, List<Lodge> Lodges, List<Room> Rooms)
        {
            List<Camper> unmatched = new List<Camper>();
            List<Camper> leftovers = new List<Camper>();

            foreach (Camper camper in Campers)
            {
                // First, break if there are no more lodges
                // Copy remaining campers to a new list for
                // processing.
                if (Lodges.Count == 0) 
                {
                    int index = Campers.IndexOf(camper);
                    for (int i = index; i < Campers.Count; i++)
                    {
                        leftovers.Add(Campers[i]);
                    }
                    break; 
                }
                Constraint C = camper.Constraints;
                //Constraints.RemoveAt(0);
                int cHash = C.GetHashCode();
                //Console.WriteLine(cHash);
                if (!_hashList.Contains(cHash)) { _hashList.Add(cHash); }
                Room R = Rooms[0];
                Rooms.RemoveAt(0);

                // If a similar constraint already exists and the current lodge is not full
                if (_matchList.ContainsKey(cHash) && !_matchList[cHash][_matchList[cHash].Count - 1].isFull())
                {
                    // First check for a roomate match
                    if (camper.Person && !_matchList[cHash][_matchList[cHash].Count - 1].RoomateMatch(camper))
                    {
                        // The camper has a person they want to be roomates with but the person is not in this lodge
                        unmatched.Add(camper);
                    }
                    else
                    {
                        R.Parent = _matchList[cHash][_matchList[cHash].Count - 1].Name;
                        R.Camper = camper;
                        _matchList[cHash][_matchList[cHash].Count - 1].AddRoom(R);
                    }
                }
                // if a similar constraint exists and the current lodge is full
                else if (_matchList.ContainsKey(cHash) && _matchList[cHash][_matchList[cHash].Count - 1].isFull())
                {
                    Lodge L = Lodges[0];
                    Lodges.RemoveAt(0);
                    R.Parent = L.Name;
                    R.Camper = camper;
                    L.AddRoom(R);
                    _matchList[cHash].Add(L);
                }
                else
                {
                    List<Lodge> lodgeList = new List<Lodge>();
                    _matchList.Add(cHash, lodgeList);
                    Lodge L = Lodges[0];
                    Lodges.RemoveAt(0);
                    R.Parent = L.Name;
                    R.Camper = camper;
                    L.AddRoom(R);
                    _matchList[cHash].Add(L);
                }
            }
            // Prepare to process unmatched and leftover campers
            List<Lodge> tempLodgeList = new List<Lodge>();
            _matchList.Add(100,tempLodgeList);

            Lodge UnmatchedLodge = new Lodge("Unmatched", 100);
            _matchList[100].Add(UnmatchedLodge);
            _hashList.Add(100);

            // Process the unmatched and leftover campers
            _matchList = ProcessUnmatched(unmatched, leftovers,Rooms,_matchList);

            // Prepare final match list
            List<Lodge> Matches = new List<Lodge>();
            foreach(int key in _hashList)
            {
                foreach(Lodge lodge in _matchList[key])
                {
                    if(!Matches.Contains(lodge)) { Matches.Add(lodge); }
                }
            }

            return Matches;
        }

        private Dictionary<int, List<Lodge>> ProcessUnmatched(List<Camper> unmatched, List<Camper> leftovers, List<Room> rooms, Dictionary<int, List<Lodge>> matches)
        {
            Lodge remainders = new Lodge("Unmatched", 100);

            if (leftovers != null)
            {
                while (leftovers.Count != 0) { unmatched.Add(leftovers[0]); leftovers.RemoveAt(0);}
            }

            // Resolve roomate preferences
            foreach(Camper camper in unmatched)
            {
                //bool done = false;
                if (camper.Person)
                {
                    // find a missing roomate match for the camper
                    foreach (Lodge L in matches[camper.Constraints.GetHashCode()])
                    {
                        // first, find out if there is someone in the lodge that can be moved
                        Camper returned = L.Rearrange(camper);
                        if (returned != null)
                        {
                            leftovers.Add(returned);
                        }
                        else
                        {
                            leftovers.Add(camper);
                        }
                    }
                }
                else 
                {
                    leftovers.Add(camper);
                }
            }

            // find space for remaining
            foreach (Camper camper in leftovers)
            {
                // Find available space with current constriants
                Room r;
                if (rooms.Count > 0) { r = rooms[0]; rooms.RemoveAt(0); }
                else { r = new Room(1); }
                r.Camper = camper;
                bool found = false;
                    
                int top = matches[camper.Constraints.GetHashCode()].Count - 1;
                if (!matches[camper.Constraints.GetHashCode()][top].isFull()) { matches[camper.Constraints.GetHashCode()][top].AddRoom(r); }

                else 
                {
                    // Check other Lodges for space
                    foreach(Lodge lodge in matches[camper.Constraints.GetHashCode()])
                    {
                        if (!lodge.isFull()) { lodge.AddRoom(r); found = true; }
                    }
                }
                // find space by removing constraints one by one
               if (!found)
                {

                    // Copy camper
                    string pref1 = camper.Constraints.Roomate_Pref1;
                    string pref2 = camper.Constraints.Roomate_Pref2;
                    string pref3 = camper.Constraints.Roomate_Pref3;
                    string pref4 = camper.Constraints.Roomate_Pref4;
                    Constraint c = new Constraint(camper.Constraints.Person, camper.Constraints.Smoking, camper.Constraints.Dog, camper.Constraints.Gender, pref1, pref2, pref3, pref4);
                    Camper nextC = new Camper(camper.Id, camper.CamperName, camper.Person, camper.Smoking, camper.Dog, camper.Gender);
                    nextC.Constraints = c;
                    bool done = false;

                    if(nextC.Constraints.Dog)
                    {
                        nextC.Constraints.Dog = false;
                        if(matches.ContainsKey(nextC.Constraints.GetHashCode()))
                        {
							foreach (Lodge lodge in matches[nextC.Constraints.GetHashCode()])
							{
								if (!lodge.isFull())
								{
									camper.comment = "Couldn't find space with current preferences. Dog preference removed.";
									lodge.AddRoom(r);
									done = true;
								}
							}
                        }
						
                    }
                    if (!done && nextC.Constraints.Smoking)
                    {
                        nextC.Constraints.Smoking = false;
                        if (matches.ContainsKey(nextC.Constraints.GetHashCode()))
                        {
							foreach (Lodge lodge in matches[nextC.Constraints.GetHashCode()])
							{
								if (!lodge.isFull())
								{
									camper.comment = "Couldn't find space with current preferences. Smoking preference removed.";
									lodge.AddRoom(r);
									done = true;
								}
							}
                        }
						
                    }
                    if(!done && nextC.Constraints.Person)
                    {
                        nextC.Constraints.Person = false;

                        if(matches.ContainsKey(nextC.Constraints.GetHashCode()))
                        {
							foreach (Lodge lodge in matches[nextC.Constraints.GetHashCode()])
							{
								if (!lodge.isFull())
								{
									camper.comment = "Couldn't find space with current preferences. Roomate preference removed.";
									lodge.AddRoom(r);
								}
							}
                        }
						
                    }
                    else
                    {
                        // Couldn't find a match. Add "Unmatched" Lodge
                        camper.comment = "Couldn't find a match.";
                        remainders.AddRoom(r);
                    }
                }

                // If no space, add to unmatched list
                else 
                {
                    remainders.AddRoom(r);
                }

            }

            matches[100].Add(remainders);
            return matches;

        }
    }
}
