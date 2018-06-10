using System;
namespace LHBMatchingTest
{
    public class Camper
    {
        private string id;
        private string camperName;
        private Constraint constraints;
        public string comment = "None";

        // Constructs a basic Camper object with only their constraints
        public Camper(string Id, bool p, bool s, bool d, string g)
        {
            id = Id;
            //person = p;
            //smoking = s;
            //dog = d;
            constraints = new Constraint(p, s, d, g);
        }

		public Camper(string Id, string camper_name, bool p, bool s, bool d, string g, string pref1, string pref2, string pref3, string pref4)
		{
			id = Id;
            camperName = camper_name;
			constraints = new Constraint(p, s, d, g, pref1, pref2, pref3, pref4);
		}
        // Constructs camper object with camper's name and name of person they don't want
        // to be paired with.
		public Camper(string Id, string camper_name, bool p, bool s, bool d, string g)
		{
			id = Id;
            camperName = camper_name;
			constraints = new Constraint(p, s, d, g);
		}
        public string Id { get { return id; } }
        public string CamperName { get { return camperName; } set { camperName = value; }}
        public bool Person { get { return constraints.Person; } }
        public bool Smoking { get { return constraints.Smoking; } }
        public bool Dog { get { return constraints.Dog; } }
        public string Gender { get { return constraints.Gender; }}
        public Constraint Constraints { get { return constraints; } set { constraints = value; }}
        public override string ToString()
        {
            return string.Format("[Camper: Id: {0}, Name: {1}, Gender: {2}, Person: {3}, Smoking: {4}, Dog: {5}, Constraints: {6}, Comment: {7}]", Id, CamperName, Constraints.Gender, Person, Smoking, Dog, Constraints, comment);
        }
    }
}
