using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_POCO
{
    public class DevTeam
    {
        public DevTeam()
        {
        }
        public DevTeam(string teamName, List<Developer> devList)
        {
            TeamName = teamName;
            Developers = new List<Developer>();
            Developers = devList;
        }
        public string TeamName { get; set; }
        public List<Developer> Developers { get; set; } = new List<Developer>();
        public List<DevTeam> devTeams { get; set; } = new List<DevTeam>();
        public int TeamID { get; set; }
    }
}