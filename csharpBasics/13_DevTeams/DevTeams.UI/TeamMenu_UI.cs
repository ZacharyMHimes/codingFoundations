using static System.Console;
public class TeamMenu_UI
{
private Devs_Repository _devRepo;
private Teams_Repository _teams;
private readonly List<Developer> _devDb = new List<Developer>();
private bool isRunningDevUI;

    public TeamMenu_UI(Devs_Repository devRepo)
    {
        _devRepo = devRepo;
        _teams = new Teams_Repository(_devRepo);
    }

    
public void Run()
        {
            OpenTeamMenu();
        }

private void OpenTeamMenu()
        {
            isRunningDevUI = true;
            while (isRunningDevUI)
                {
                    ViewTeamIndex();
                };
        }
private void CloseTeamMenu()
        {
            Console.Clear();
            isRunningDevUI = false;
        }   

//* 1. Developer Menu
private void ViewTeamIndex()
    {   Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("\n" 
            + "                                                                                                                \n" 
            + "                                Komodo Insurance Dev Team Management Application                                \n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine(
            "                                             Manage Teams Menu Options                                         \n");
        ResetColor();                                                                                                                
            System.Console.WriteLine("\n"
            + "                                                                                                                \n"
            + "     1. List All Teams                                                             6. Add Team Profile          \n"
            + "     2. --------------------                                                       7. Remove Team Profile       \n"
            + "     3. --------------------                                                       8. ------------              \n" 
            + "     4. --------------------                                                       9. ------------              \n" 
            + "     5. -------------                                                             10. Return to Main            \n" 
            + "                                                                                                                \n"
            + "                                                                                                                \n"); 
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.WriteLine(" Please Enter a Menu Number:");
        ResetColor();

            var devIndexNav = ReadLine();
            switch (devIndexNav)
            { 
                case "1":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                        System.Console.WriteLine("\n"
                        +"                                        Current Team Configuration In Use:                                         ");
                    ResetColor();
                        ListAllTeams_ToDisplay();
                    break;
                case "10":
                    Console.Clear();
                    CloseTeamMenu();
                    break;
                case "6":
                    Console.Clear();
                    AddTeamToDatabase();
                    break;
                case "7":
                    Console.Clear();
                    //RemoveTeamFromDatabase();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("Invalid Selection, Please enter an Integer value");
                    ResetColor();
                    ReadLine();
                    break;
                
                    }
    }

private void ListAllTeams_ToDisplay()
    {
        List<Team> teamsInDb = _teams.GetAllTeams();
        ValidateTeams_PrintRosters(_teams.GetAllTeams());
    }

private void ValidateTeams_PrintRosters(List<Team> teamsInDb)
    {
        System.Console.WriteLine(" Komodo Insurance Development Teams Report: ");
        if (teamsInDb.Count > 0)
        {
            foreach (Team team in teamsInDb)
            System.Console.WriteLine(
                $"{team.TeamId}"
                );
            ReadKey();
            OpenTeamMenu();
        }
        else
        {
            WriteLine("No Teams Found.");
            ReadKey();
            OpenTeamMenu();
        }
    }


private Team NewTeamProfile()
    {
        try
        {
            Team team = new Team();
            WriteLine("Please enter the DevTeam Name:");
            team.TeamName = ReadLine();

            bool hasFilledPositions = false;

            List<Developer> auxDevelopers = _devRepo.GetAllDevelopers();

            while (!hasFilledPositions)
            {
                WriteLine("Does this team have any Developers? y/n");
                string userInputAnyDevs = ReadLine();
                if (userInputAnyDevs == "Y".ToLower())
                {
                    if (auxDevelopers.Count() > 0)
                    {
                        DisplayDevelopers_ToAdd(auxDevelopers);
                        WriteLine("Select the Dev you want on this team by DevId.");
                        var userInputDevId = int.Parse(ReadLine());
                        Developer selectedDev = _devRepo.GetDeveloperByID(userInputDevId);
                        if (selectedDev != null)
                        {
                            team.TeamMembers.Add(selectedDev);
                            auxDevelopers.Remove(selectedDev);
                        }
                        else
                        {
                            WriteLine($"Could not find profile: {userInputDevId}.");
                        }
                    }
                    else
                    {
                        WriteLine("Could Not Find Developers to Add.");
                        ReadKey();
                        break;
                    }
                }
                else
                {
                    hasFilledPositions = true;
                }
            }
            return team;

        }
        catch
        {
            System.Console.WriteLine("Sorry - Could not Complete Request.");
            ReadKey();
        }
        return null;
    }

private void DisplayDevelopers_ToAdd(List<Developer> devsInDb)
    {
        if (devsInDb.Count > 0)
        {
            foreach (Developer profile in devsInDb)
            {
            System.Console.WriteLine($" {profile.Id}   {profile.FirstName}   {profile.LastName}");
            }
        }
        else
        {
            WriteLine("No Developer Profiles Found.");
            ReadKey();
        }
    }

private void AddTeamToDatabase()
    {
        Team newTeam = NewTeamProfile();
        if ( _teams.AddTeamProfile(newTeam))
            {System.Console.WriteLine($"New Team: {newTeam.TeamName} Created.");}
        else{
            System.Console.WriteLine("Sorry - Could not Complete Request.");
            ReadKey();
            };
    }

}