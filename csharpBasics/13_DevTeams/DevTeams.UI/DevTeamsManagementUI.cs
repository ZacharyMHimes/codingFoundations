using static System.Console;

public class DevTeamsManagement_UI
{
private DevMenu_UI _rundevMenuUI;
private TeamMenu_UI _runteamMenuUI;
private RunPluralSight_UI _runPluralUI;
private Devs_Repository _devRepo;
public DevTeamsManagement_UI()
{
        _devRepo = new Devs_Repository();
        _rundevMenuUI = new DevMenu_UI();
        _runteamMenuUI = new TeamMenu_UI(_devRepo);
        _runPluralUI = new RunPluralSight_UI();
}
public bool isRunning = true; 
public void Run()
    {   while (isRunning == true)
        {   
            RunApplication();
        };
    } 
/* LOG IN SCREEN
private void LogInScreen()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("\n" 
            + "                                                                                                                \n" 
            + "                                Komodo Insurance Dev Team Management Application                                \n");
        ResetColor(); 
        Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine("\n"
            + "                              'We'll absolve your corporation of ALL liability!!!'                               \n");
        ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine("\n"
            +"Press '1' to Main Menu \n"
            +"Press '2' to Close Application");
        ResetColor();
            
        var userInput = ReadLine();
        {
            switch (userInput)
            {
                case "1": //Enters Main Menu
                    Console.Clear();
                    RunApplication();
                    break;
                case "2": //Closes Console App
                    Console.Clear();
                    isRunning = false;
                    break;
                default: //Returns User to "Log In Screen"
                    Console.Clear();
                    LogInScreen();
                    break;
            }
        };
    }
*/
//* MAIN MENU
private void RunApplication()
    {   Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("\n" 
            + "                                                                                                                \n" 
            + "                                   Komodo Insurance Dev Team Management Application                              ");  Console.ForegroundColor = ConsoleColor.DarkYellow;System.Console.WriteLine(
            "                                                    Main Menu Options                                            \n"); 
        ResetColor();                                                                                                              
            System.Console.WriteLine("\n"
            + "                                                                                                                \n"
            + "     1. Manage Developers                                                          6. Manage Teams              \n" //4. Display Developer Profile  (Allows search by ID number - displays details)
            + "     2. -----------------------                                                    7. Run HR Pluralsight Report \n" //5. Edit Developer Profile
            + "     3. -----------------------                                                    8. ------------              \n" //6. Manage Teams (1.View All Teams  2.Assign New Team  3.Remove Team 4.Remove All Teams )
            + "     4. -----------------------                                                    9. ------------              \n" //7. Run HR Pluralsight Report (Prints Employee Directory w/ "Needs Access" text next to names w/o)
            + "     5. -----------------------                                                    10.Application Sign Out     \n" //10. Ends Program
            + "                                                                                                                \n"); //todo: Figure out how to color Specific Text w/in writeline
    
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.WriteLine("\n"
            + " Please Enter a Menu Number:");
            ResetColor();

            var mainMenuNav = ReadLine();
            switch (mainMenuNav)
            {
                case "1":
                    
                    Console.Clear();
                    _rundevMenuUI.Run();
                    break;
                case "6":
                    Console.Clear();
                    _runteamMenuUI.Run();
                    break;
                case "7":
                    Console.Clear();
                    _runPluralUI.Run();
                    break;
                case "10":
                    Console.Clear();
                    isRunning = false;
                    break;   
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("Invalid Selection, Please Enter an Integer Value");
                    ResetColor();
                    ReadLine();
                    break;
            }
    
    }
}
