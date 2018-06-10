using System;
using Medallion;
using System.Collections.Generic;

namespace LHBMatchingTest
{
    public class MockData
    {
        private List<Camper> campers;
        private List<Lodge> lodges;
        private List<Room> rooms;
        //private List<Constraint> constraints;

        // Automaticall fill lists with mock data
        public MockData()
        {
            campers = new List<Camper>();
            lodges = new List<Lodge>();
            rooms = new List<Room>();
            //constraints = new List<Constraint>();
			// Fill camper list with mock data
			campers.Add(new Camper("001", "John", true, false, false, "Male","Stewart", "Hal", "Barry","Bruce"));
			campers.Add(new Camper("002", "Stewart", true, false, false, "M", "John", "Hal", "Barry", "Bruce"));
			campers.Add(new Camper("003", "Hal", true, false, false, "male", "John", "Stewart","Barry", "Bruce"));
			campers.Add(new Camper("004", "Barry", true, false, false, "m", "John","Stewart","Hal","Bruce"));
			campers.Add(new Camper("005", "Bruce", true, false, false, "Male", "John", "Stewart", "Hal","Barry"));

			campers.Add(new Camper("006", "Diana", false, true, false, "Female", "Kara", "Barbara", "", ""));
			campers.Add(new Camper("007", "Kara", false, true, false, "F", "Diana", "Barabara", "", ""));
			campers.Add(new Camper("008", "Barbara", false, true, false, "female","Diana", "Kara", "", ""));

			campers.Add(new Camper("009", "Clark", false, false, true, "Male", "Victor","", "",""));
			campers.Add(new Camper("010", "Harley", false, false, true, "Female"));
			campers.Add(new Camper("011", "Victor", false, false, true, "Male", "Clark","","",""));
			campers.Add(new Camper("012", "Pamela", false, false, true, "Female"));

			campers.Add(new Camper("013", "Barda", true, true, false, "Female","Dinah","Helena","Zatanna","Jennifer"));
			campers.Add(new Camper("014", "Dinah", true, true, false, "Female","Barda", "Helena", "Zatanna", "Jennifer"));
			campers.Add(new Camper("015", "Helena", true, true, false, "Female","Barda","Dinah", "Zatanna", "Jennifer"));
			campers.Add(new Camper("016", "Zatanna", true, true, false, "Female", "Barda", "Dinah","Helena", "Jennifer"));
			campers.Add(new Camper("017", "Jennifer", true, true, false, "Female", "Barda", "Dinah", "Helena", "Zatanna"));

			campers.Add(new Camper("018", "Jaime", true, false, true, "Male"));
			campers.Add(new Camper("019", "Damian", true, false, true, "Male"));
			campers.Add(new Camper("020", "Billy", true, false, true, "Male"));
			campers.Add(new Camper("021", "Arthur", true, false, true, "Male"));
			campers.Add(new Camper("022", "Mera", true, false, true, "Female", "Zatanna", "","",""));
			campers.Add(new Camper("023", "Oliver", true, false, true, "Female"));
			campers.Add(new Camper("024", "Ted", true, false, true, "Female"));

			campers.Add(new Camper("025", "Alan", false, true, true, "Male"));
			campers.Add(new Camper("026", "Jay", false, true, true, "Male"));
			campers.Add(new Camper("027", "Dick", false, true, true, "Male"));

			campers.Add(new Camper("028", "Adrianna", true, true, true, "Female"));
			campers.Add(new Camper("029", "Mary", true, true, true, "Female"));
			campers.Add(new Camper("030", "Nura", true, true, true, "Female"));
			campers.Add(new Camper("031", "Artemis", true, true, true, "Female"));

			campers.Add(new Camper("032", "Travis", false, false, false, "Other"));
			campers.Add(new Camper("033", "Jonah", false, false, false, "Other"));
			campers.Add(new Camper("034", "Kent", false, false, false, "Other"));
			campers.Add(new Camper("035", "Carter", false, false, false, "Other"));

			// Fill lodge list with mock data
			lodges.Add(new Lodge("Alpha", 4));
			lodges.Add(new Lodge("Beta", 4));
			lodges.Add(new Lodge("Gamma", 4));
			lodges.Add(new Lodge("Delta", 4));
			lodges.Add(new Lodge("Epsilon", 4));

			lodges.Add((new Lodge("Zeta", 2)));

			lodges.Add(new Lodge("Eta", 3));
			lodges.Add(new Lodge("Theta", 3));

			lodges.Add(new Lodge("Iota", 5));
			lodges.Add(new Lodge("Kappa", 5));
            lodges.Add(new Lodge("Lambda", 4));
            lodges.Add(new Lodge("Mu", 4));
            lodges.Add(new Lodge("Nu", 4));
            lodges.Add(new Lodge("Xi", 4));
            lodges.Add((new Lodge("Omicron", 4)));

			// Fill constraint list with mock data
			//foreach (Camper camper in campers)
			//{
			//	constraints.Add(camper.Constraints);
			//}

			foreach (Lodge lodge in lodges)
			{
				for (int i = 0; i < lodge.Capacity; i++) { rooms.Add(new Room(1)); }
			}
            campers.Shuffle();
        }



        public List<Camper> Campers { get { return campers; } set { campers = value; } }
        public List<Lodge> Lodges { get { return lodges; } set { lodges = value; } }
        public List<Room> Rooms { get { return rooms; } set { rooms = value; } }
        //public List<Constraint> Constraints { get { return constraints; } set { constraints = value; } }
    }
}
