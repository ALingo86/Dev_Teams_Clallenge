using _01_Developer;
using _02_DevTeamRepo;
using DevTeams_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevTeams
{
    public class Program_UI
    {
        private readonly DeveloperRepo _devRepo = new DeveloperRepo();
        private readonly DevTeamRepo _devTeam;

        public Program_UI()
        {
            _devTeam = new DevTeamRepo(_devRepo);
        }
        public void Run()
        {
            Seed();
            ShowMenu();
        }
        private void ShowMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to dev Teams.\n" +
                    "1.Add a developer\n" +
                    "2.View all existing developers\n" +
                    "3.See all developers without pluralsight\n" +
                    "4.Update an existing developer\n" +
                    "5.Delete an existing developer\n" +
                    "6.View all existing dev teams\n" +
                    "7.Add a dev team\n" +
                    "8.Add developers to dev teams\n" +
                    "9.Delete a dev team\n");

                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        AddADeveloper();
                        break;
                    case "2":
                        ViewAllExistingDevelopers();
                        break;
                    case "3":
                        ViewAllDevsWithoutPluralSight();
                        break;
                    case "4":
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        DeleteDeveloper();
                        break;
                    case "6":
                        GetAllDevTeams();
                        break;
                    case "7":
                        CreateDevTeam();
                        break;
                    case "8":
                        AddDeveloperToDevTeam();
                        break;
                    case "9":
                        DeleteDevTeam();
                        break;

                    default:
                        Console.WriteLine("Invalid Selection");
                        WaitForKey();
                        break;
                }
                Console.Clear();
            }
        }
        private void AddADeveloper()
        {
            Console.Clear();
            Developer developer = new Developer();

            Console.Write("Please enter Developers first name.");
            string firstName = Console.ReadLine();
            developer.FirstName = firstName;

            Console.Write("Please enter Developers last name.");
            string lastName = Console.ReadLine();
            developer.LastName = lastName;

            Console.WriteLine($"Is this correct? {firstName} {lastName} (y/n)");
            if (Console.ReadLine() == "n")
            {
                return;
            }
            else firstName = new Developer().FirstName; lastName = new Developer().LastName;

            Console.WriteLine($"Does Developer have PluralSite? (y/n)");
            if (Console.ReadLine() == "n")
            {
                developer.HasPluralSight = false;
            }
            else developer.HasPluralSight = true;

            _devRepo.AddDeveloperToDirectory(developer);
            Console.WriteLine($"Developer {developer.FullName} Added Successfully");
            WaitForKey();
        }
        private void ViewAllExistingDevelopers()
        {
            Console.Clear();
            List<Developer> developers = _devRepo.GetDevelopers();
            foreach (Developer developer in developers)
            {
                Console.WriteLine
                    (
                    $"Developer ID: {developer.ID}\n" +
                    $"Name: {developer.FullName}\n" +
                    $"Has Pluralsight? {developer.HasPluralSight}");

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        private void ViewAllDevsWithoutPluralSight()
        {
            Console.Clear();
            Console.WriteLine(" -Developers without Plural Sight-");
            foreach (Developer developer in _devRepo.GetAllDevelopersWithoutPluralSight())
            {
                Console.WriteLine
                    (
                    $"Developer ID: {developer.ID}\n" +
                    $"Name: {developer.FullName}\n" 
                    );
            }
            WaitForKey();
        }
        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            ViewAllExistingDevelopers();
            Developer newDev = new Developer();

            Console.WriteLine("Please enter the developer ID that you would like to update:");
            int oldID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the developers new ID:");
            newDev.ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the developer's first name:");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("Please enter the developer's last name:");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("Does the developer have Pluralsight? (y/n)");
            if (Console.ReadLine() != "y")
            {
                newDev.HasPluralSight = false;
            }
            else
            {
                newDev.HasPluralSight = true;
            }
            bool updated = _devRepo.UpdateExistingDeveloper(oldID, newDev);
            if (updated)
                Console.WriteLine("Developer updated successfully");
            else
                Console.WriteLine("Developer update failed. Please try again.");
        }
        private void DeleteDeveloper()
        {
            Console.Clear();
            ViewAllExistingDevelopers();
            Console.WriteLine("Please enter the Developer ID you wish to delete:");
            bool deleted = _devRepo.DeleteID(Convert.ToInt32(Console.ReadLine()));
            if (deleted)
                Console.WriteLine("Developer deleted successfully.");
            else
                Console.WriteLine("Deletion failed.");
        }
        private void GetAllDevTeams()
        {
            Console.Clear();
            List<DevTeam> devTeams = _devTeam.GetDevTeams();
            foreach (DevTeam devTeam in devTeams)
            {
                Console.WriteLine
                    (
                    $"Dev Team Name: {devTeam.TeamName}\n" +
                    $"Dev Team ID: {devTeam.TeamID}\n" +
                    $"_________________________________");
                foreach (Developer dev in devTeam.Developers)
                {
                    Console.WriteLine
                        (
                        $"Name: {dev.FullName}\n" +
                        $"ID: {dev.ID}\n" +
                        $"______________"
                        );
                }
            }
            WaitForKey();
        }
        private void CreateDevTeam()
        {
            Console.Clear();
            GetAllDevTeams();
            Console.Write("Do you want to create a new team? (y/n)");
            {
                if (Console.ReadLine() == "y")
                {
                    DevTeam newDevTeam = new DevTeam();
                    newDevTeam.TeamName = "Change Me";
                    _devTeam.AddDevTeam(newDevTeam);
                    Console.WriteLine("Team added successfully");
                    WaitForKey();
                }
                else
                {
                    return;
                }
            }
        }
        private void AddDeveloperToDevTeam()
        {
            Console.Clear();
            GetAllDevTeams();
            Console.WriteLine("Please input the team ID:");
            int teamID = Convert.ToInt32(Console.ReadLine());

            ViewAllExistingDevelopers();
            Console.WriteLine("Please enter the Developer ID:");
            int devID = Convert.ToInt32(Console.ReadLine());

            var success = _devTeam.AddDeveloperToDevTeam(teamID, devID);

            if (success)
            {
                Console.WriteLine("Dev added successfully.");
            }
            else
                Console.WriteLine("Add failed.");
            WaitForKey();
        }
        private void DeleteDevTeam()
        {
            Console.Clear();
            GetAllDevTeams();
            Console.WriteLine("Please enter the DevTeam ID you wish to delete:");
            bool deleted = _devTeam.DeleteDevTeam(Convert.ToInt32(Console.ReadLine()));
            if (deleted)
                Console.WriteLine("Dev Team deleted successfully.");
            else
                Console.WriteLine("Deletion failed.");
        }
        private void WaitForKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void Seed()
        {
            Developer Andrew = new Developer();
            Andrew.ID = 1;
            Andrew.FirstName = "Andrew";
            Andrew.LastName = "Lingo";
            Andrew.HasPluralSight = false;
            _devRepo.AddDeveloperToDirectory(Andrew);

            Developer Bob = new Developer();
            Bob.ID = 2;
            Bob.FirstName = "Robert";
            Bob.LastName = "Edge";
            Bob.HasPluralSight = true;
            _devRepo.AddDeveloperToDirectory(Bob);

            Developer Sarah = new Developer();
            Sarah.ID = 3;
            Sarah.FirstName = "Sarah";
            Sarah.LastName = "Engwall";
            Sarah.HasPluralSight = true;
            _devRepo.AddDeveloperToDirectory(Sarah);

            Developer Sam = new Developer();
            Sam.ID = 4;
            Sam.FirstName = "Samantha";
            Sam.LastName = "Simpson";
            Sam.HasPluralSight = false;
            _devRepo.AddDeveloperToDirectory(Sam);

            DevTeam a = new DevTeam();
            a.TeamName = "TigerTeam";
            a.TeamID = 1;
            a.Developers = new List<Developer>();
            _devTeam.AddDevTeam(a);

            DevTeam b = new DevTeam();
            b.TeamName = "SharkTeam";
            b.TeamID = 2;
            b.Developers = new List<Developer>();
            _devTeam.AddDevTeam(b);
        }
    }
}







