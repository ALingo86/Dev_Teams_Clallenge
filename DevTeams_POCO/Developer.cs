using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_POCO
{
    public class Developer
    {
        public Developer()
        {

        }
        public Developer(int iD, string firstName, string lastName, string fullName, bool hasPluralSight)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            HasPluralSight = hasPluralSight;
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public bool HasPluralSight { get; set; }

    }
}
