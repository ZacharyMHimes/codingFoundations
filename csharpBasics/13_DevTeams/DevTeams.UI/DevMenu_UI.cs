using static System.Console;
public class DevMenu_UI
{
    private Devs_Repository _devRepo;
    private bool isRunningDevUI;
    //private DeveloperTeamUI _dtUI;

    public DevMenu_UI()
        {
        _devRepo = new Devs_Repository();
        //_devUI = new DeveloperUI();
        //_devTeamUI = new DeveloperTeamUI(_devRepo);
        }

public void Run()
        {
            OpenDevMenu();
        }

private void OpenDevMenu()
        {
            isRunningDevUI = true;
            while (isRunningDevUI)
                {
                    ViewDevIndex();
                };
        }
private void CloseDevMenu()
        {
            Console.Clear();
            isRunningDevUI = false;
        }

//* 1. Developer Menu
private void ViewDevIndex()
    {   Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("\n" 
            + "                                                                                                                \n" 
            + "                                Komodo Insurance Dev Team Management Application                                \n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine(
            "                                             Developer Index Menu Options                                         \n");
        ResetColor();                                                                                                                
            System.Console.WriteLine("\n"
            + "                                                                                                                \n"
            + "     1. List All Developer Profiles                                                6. Add Dev Profile           \n"
            + "     2. List All Teamed Devs                                                       7. Remove Dev Profile        \n"
            + "     3. List All Unteamed Devs                                                     8. ------------              \n" 
            + "     4. List All Devs By Team                                                      9. ------------              \n" 
            + "     5. Return to Main                                                             10.------------              \n" 
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
                        +"                                        Current Developer Profiles In Use:                                         ");
                    ResetColor();
                        ListAllDeveloperProfiles(); //method
                        DevIndexMenuReturn();
                    break;
                case "2":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                        System.Console.WriteLine("\n"
                        +"                                        Current Developer Profiles On Teams:                                        ");
                    ResetColor();
                        //ListAllDeveloperProfilesOnTeams(); //method
                        ReadKey();
                        DevIndexMenuReturn();
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
                        DevIndexMenuReturn();
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
                        DevIndexMenuReturn();
                    break;
                case "5":
                    Console.Clear();
                    CloseDevMenu();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("Invalid Selection, Please enter an Integer value");
                    ResetColor();
                    ReadLine();
                    break;
                
                    }
    }
private void DevIndexMenuReturn()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        System.Console.WriteLine("Return to Developer Index Menu:");
        ResetColor();
        ReadKey();
        Console.Clear();
        ViewDevIndex();
    }
private void ListAllDeveloperProfiles()
    {
        List<Developer> devsInDb = _devRepo.GetAllDevelopers();
        ValidateDeveloperDatabaseData(devsInDb);
    }

private void ValidateDeveloperDatabaseData(List<Developer> devsInDb)
    {
        if (devsInDb.Count > 0)
        {
            //Clear();
            foreach (Developer profile in devsInDb)
            {
            System.Console.WriteLine($" {profile.Id}   {profile.FirstName}   {profile.LastName}");
            }
            ReadKey();
            DevIndexMenuReturn();
        }
        else
        {
            WriteLine("No Developer Profiles Found.");
            ReadKey();
            DevIndexMenuReturn();
        }
    }
private void DisplayDevProfile(Developer profile)
    {
        System.Console.WriteLine(profile);
    }
}