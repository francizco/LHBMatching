using System;
namespace LHBMatchingTest
{
    public class Constraint
    {
        private bool person;
        private bool smoking;
        private bool dog;
        private string gender;
        private string roomate_pref1 = "";
        private string roomate_pref2 = "";
        private string roomate_pref3 = "";
        private string roomate_pref4 = "";


        public Constraint(bool p, bool s, bool d, string g)
        {
            person = p;
            smoking = s;
            dog = d;
            gender = g;
        }

		public Constraint(bool p, bool s, bool d, string g, string pref1, string pref2, string pref3, string pref4)
		{
			person = p;
			smoking = s;
			dog = d;
			gender = g;
            roomate_pref1 = pref1;
            roomate_pref2 = pref2;
            roomate_pref3 = pref3;
            roomate_pref4 = pref4;
		}

        public bool Person { get { return person; } set { person = value; } }

        public bool Smoking { get { return smoking; } set { smoking = value; } }

        public bool Dog { get { return dog; } set { dog = value; } }

        public string Gender { get { return gender; } set { gender = value; } }

        public string Roomate_Pref1 { get { return roomate_pref1; } set { roomate_pref1 = value; } }
        public string Roomate_Pref2 { get { return roomate_pref2; } set { roomate_pref2 = value; } }
        public string Roomate_Pref3 { get { return roomate_pref3; } set { roomate_pref3 = value; } }
        public string Roomate_Pref4 { get { return roomate_pref4; } set { roomate_pref4 = value; } }

        public bool isRoomateMatch(string name)
        {
            if (roomate_pref1 == name || roomate_pref2 == name || roomate_pref3 == name || roomate_pref4 == name) { return true; }
            else return false;
        }

        public override string ToString()
        {
            return person.ToString() + smoking.ToString() + dog.ToString();
        }

        public override int GetHashCode()
        {
            int p = 0; // person
            int s = 0; // smoking
            int d = 0; // dog
            int m = 0; // male
            int f = 0; // female
            int o = 0; // other gender
            int r = 0; // roomates
            if (person) { p = 1; }
            if (smoking) { s = 2; }
            if (dog) { d = 4; }
            if (gender == "Male" || gender == "male" || gender == "M" || gender == "m") { m = 8; }
            else if (gender == "Female" || gender == "female" || gender == "F" || gender == "f") { f = 16; }
            else { o = 25; }
            return p + s + d + m + f + o;
        }

        private int roomateCode()
        {
            int result = 0;
            if (roomate_pref1.Length > 0) { result += 1; }
            if (roomate_pref2.Length > 0) { result += 1; }
            if (roomate_pref3.Length > 0) { result += 1; }
            if (roomate_pref4.Length > 0) { result += 1; }
            return result;
        }
    }
}
