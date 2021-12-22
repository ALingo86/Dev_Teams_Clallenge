using DevTeams_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Developer
{
    public class DeveloperRepo
    {
        public readonly List<Developer> _devRepo = new List<Developer>();
        public bool AddDeveloperToDirectory(Developer newDev)
        {
            //Create
            int startingCount = _devRepo.Count;
            _devRepo.Add(newDev);

            bool wasAdded = (_devRepo.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public List<Developer> GetDevelopers()
        {
            return _devRepo;
        }
        public Developer GetDeveloper(int ID)
        {
            foreach (Developer developer in _devRepo)
            {
                if (developer.ID == ID)
                    return developer;
            }
            return null;
        }
        public List<Developer> GetAllDevelopersByHasPluralSight()
        {
            List<Developer> hasPluralSight = new List<Developer>();
            foreach (Developer developer in _devRepo)
            {
                if (developer.HasPluralSight)
                {
                    hasPluralSight.Add(developer);
                }
            }
            return hasPluralSight;
        }
        public List<Developer> GetAllDevelopersWithoutPluralSight()
        {
            List<Developer> noPluralSight = new List<Developer>();
            foreach (Developer developer in _devRepo)
            {
                if((developer.HasPluralSight)==false)
                {
                    noPluralSight.Add(developer);
                }
            }
            return noPluralSight;
        }
        public Developer GetDeveloperByID(int ID)
        {
            foreach (Developer content in _devRepo)
            {
                if (content.ID == ID)
                {
                    return content;
                }
            }
            return null;
        }
        //Update
        public bool UpdateExistingDeveloper(int originalID, Developer newdata)
        {
            //find the old content...
            Developer oldDeveloper = GetDeveloper(originalID);

            if (oldDeveloper != null)
            {
                oldDeveloper.ID = newdata.ID;
                oldDeveloper.FirstName = newdata.FirstName;
                oldDeveloper.LastName = newdata.LastName;
                oldDeveloper.HasPluralSight = newdata.HasPluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteDeveloper(Developer developer)
        {
            bool deleteResult = _devRepo.Remove(developer);
            return deleteResult;
        }
        public bool DeleteID(int ID)
        {
            Developer developer = GetDeveloper(ID);
            if (developer != null)
            {
                _devRepo.Remove(developer);
                return true;
            }
            return false;
        }
    }
}

