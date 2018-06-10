using System;
using System.Collections.Generic;

namespace LHBMatchingTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            MockData mock = new MockData();
            List<Camper> Campers = mock.Campers;
            Match _match = new Match();
            Console.WriteLine(mock.Lodges.Count);

//            foreach(Camper camper in mock.Campers) { Console.WriteLine((camper)); }
            List<Lodge> LL = _match.MatchCamperRooms(mock.Campers, mock.Lodges, mock.Rooms);
            Console.WriteLine(LL.Count);

            foreach(Lodge lodge in LL)
            {
                Console.WriteLine("Name of Lodge: " + lodge.Name);
                foreach(Room room in lodge.Rooms)
                {
                    Console.WriteLine(room.Camper.ToString());
                }
                Console.WriteLine();
            }


        }
    }
}
