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
                case "2":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                        System.Console.WriteLine("\n"
                        +"                                        Current Developer Profiles On Teams:                                        ");
                    ResetColor();
                        //ListAllDeveloperProfilesOnTeams(); //method
                        ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                        System.Console.WriteLine("\n"
                        +"                                        Current Developer Profiles Not On Teams:                                    ");
                    ResetColor();
                        System.Console.WriteLine
                        (
                            //Conditional: bool hasTeam (if !true, print. If not, pass)
                            //External Reference to Developer Class Database. Print Format: I.D.# , lastName, firstName, teamName(null) 
                        );
                    break;
                case "4":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                        System.Console.WriteLine("\n"
                        +"                                        Current Developer Profiles By Team Roster:                                  ");
                    ResetColor();
                        System.Console.WriteLine
                        (
                            //External Reference to DevTeam Class Database. Print Format: Team Name, Team Members (I.D.# , lastName , FirstName)
                            //todo: Figure out how to format the Team Roster print line.
                        );
                    break;
                case "10":
                    Console.Clear();
                    CloseTeamMenu();
                    break;
                case "6":
                    Console.Clear();
                    //AddTeamProfile();
                    break;
                case "7":
                    Console.Clear();
                    //ListAllDeveloperProfilesToDelete();
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
        List<Team> teamsInDb = _teams.GetDeveloperTeams();
        ValidateTeams_PrintRosters(_teams.GetDeveloperTeams());
    }

private void ValidateTeams_PrintRosters(List<Team> teamsInDb)
    {
        System.Console.WriteLine(" Komodo Insurance Development Teams Report: ");
        if (teamsInDb.Count > 0)
        {
            foreach (Team team in teamsInDb)
            System.Console.WriteLine(
                $"{team.TeamId}  {team.TeamName}"
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

}