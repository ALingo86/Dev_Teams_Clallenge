using _01_Developer;
using DevTeams_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DevTeamRepo
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeam = new List<DevTeam>();
        private DeveloperRepo _devRepo;
        private int _count;

        public DevTeamRepo(DeveloperRepo devRepo)
        {
            _devRepo = devRepo;
        }
        //Create
        public bool AddDevTeam(DevTeam newDevTeam)
        {
            int startingCount = _devTeam.Count;
            newDevTeam.TeamID = ++_count;
            _devTeam.Add(newDevTeam);
            bool wasAdded = (_devTeam.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public List<DevTeam> GetDevTeams()
        {
            return _devTeam;
        }
        public DevTeam GetDevTeamID(int teamID)
        {
            foreach (DevTeam devTeam in _devTeam)
            {
                if (devTeam.TeamID == teamID)
                {
                    return devTeam;
                }
            }
            return null;
        }
        public bool AddDeveloperToDevTeam(int teamID, int devID)
        {
            DevTeam selectedTeam = GetDevTeamID(teamID);
            Developer developer = _devRepo.GetDeveloperByID(devID);
            int startingCount = selectedTeam.Developers.Count;
            if (developer == null)
            {
                return false;
            }
            foreach (Developer dev in selectedTeam.Developers)
            {
                if (dev.ID == devID)
                {
                    Console.WriteLine("Developer is already on this team.");
                    return false;
                }
            }
            selectedTeam.Developers.Add(developer);
            return startingCount < selectedTeam.Developers.Count;
        }
        public bool AddMultipleDevsToTeam(int teamID, List<Developer> developers)
        {
            DevTeam devteam = GetDevTeamID(teamID);
            if (devteam == null)
            {
                return false;
            }
            else
            {

                devteam.Developers.AddRange(developers);
                return true;
            }
        }
        public void AddDevToTeam(int teamID, int iD)
        {
            DevTeam devteam = GetDevTeamID(teamID);
        }
        public bool UpdateTeamName(int teamName, DevTeam oldTeam)
        {
            DevTeam updatedTeam = GetDevTeamID(teamName);
            if (oldTeam != null)
            {
                updatedTeam.TeamName = oldTeam.TeamName;
                return true;
            }
            return false;
        }
        //Delete
        public bool DeleteDevTeam(int ID)
        {
            DevTeam devteam = GetDevTeamID(ID);
            if (devteam == null)
            {
                return false;
            }
            else
            {
                _devTeam.Remove(devteam);
                return true;
            }
        }
    }

}




