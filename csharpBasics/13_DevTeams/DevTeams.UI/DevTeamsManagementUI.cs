using static System.Console;
//todo: 1. Figure Out How to Close Application (Use Booleans)
//todo: 2. Figure build Out Developer Class to include needed properties.
//todo: 3. Make "view developer index" work with Dev. Repository
//todo: 4. Ask Terry to clarify how Repository draws from data file, so that you can scope out a means to store
//todo:    Dev class property values all up in there.
public class DevTeamsManagement_UI
{
    public void Run()
    {
        RunApplication();
    }
/*
private void ReturnToMainMenu()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        System.Console.WriteLine("Return to Main Menu");
        ReadKey();
        ResetColor();
    }
*/
    private void RunApplication()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("\n" 
            + "                                                                                                                \n" 
            + "                                Komodo Insurance Dev Team Management Application                                \n"   //1. Lists All Developer Profiles By Employee ID
            + "                                                   Main Menu Options                                            \n"); //2. Add New Developer Profile (Allow input to Dev Repository)); 
        ResetColor();                                                                                                                //3. Remove Developer Profile  (Allow Deletion)

            System.Console.WriteLine("\n"
            + "                                                                                                                \n"
            + "     1. View Developer Index                                                       6. Manage Teams              \n" //4. Display Developer Profile  (Allows search by ID number - displays details)
            + "     2. Add New Developer Profile                                                  7. Run HR Pluralsight Report \n" //5. Edit Developer Profile
            + "     3. Remove Developer Profile                                                   8. ------------              \n" //6. Manage Teams (1.View All Teams  2.Assign New Team  3.Remove Team 4.Remove All Teams )
            + "     4. Search Developer By I.D. #                                                 9. ------------              \n" //7. Run HR Pluralsight Report (Prints Employee Directory w/ "Needs Access" text next to names w/o)
            + "     5. Edit Developer Profile                                                     10.Application Sign Out     \n" //10. Ends Program
            + "                                                                                                                \n"
            + "                                                                                                                \n"); //todo: Figure out how to color Specific Text w/in writeline
    
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.WriteLine("\n"
            + " Please Enter a Menu Number:");
            ResetColor();

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    ViewDevIndex();
                    break;
                case "2":
                    AddNewDevProf();
                    break;
                case "3":
                    RmvDevProf();
                    break;
                case "4":
                    SearchDev();
                    break;
                case "5":
                    EditDevProf();
                    break;
                case "6":
                    ManageTeams();
                    break;
                case "7":
                    RunHrReport();
                    break;
                case "10":
                    Console.Clear();
                    AppSignOut();
                    break;   
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("Invalid Selection, Press Any Key to Return to Main");
                    ResetColor();
                    ReadLine();
                    break;
            }
    
    }
//* 1. List Developer Index
    private void ViewDevIndex()
    {
        // 1. List all Devs
        // 2. List all Teamed Devs
        // 3. List all Unteamed Devs
        // 4. Back To Main
    }
//* 2. Add New Developer Profile
    private void AddNewDevProf()
    {
        // 1. Create new instance of Developer Class //todo: Figure out how to store Dev. information in referenced Repository
        // Probably use one off writelines and Readlines to log Dev attribute data. Use Integer counter or number gen. to assign Employee ID.
    }
//* 3. Remove Developer Profile
    private void RmvDevProf()
    {
        //1. Create option to select and delete Developer profiles from directory.
        //2. Should Probably include a warning message. "Are you sure? this will delete all info..."

    }
//* 4. Search Dev. by Employee I.D. #
    private void SearchDev()
    {
        //1. Enter Employee I.D. , Console Prints full profile
        //2. Enter Employee lastName + firstName, console prints full profile
    }
//* 5. Edit Dev. Profile
    private void EditDevProf()
    {
        //1. User enters employee I.D. 
        //2. User is prompted to select a property to edit.
        //3. User returns to Employee edit menu.
        //4. Return to Main.
    
    }
//* 6. Manage Teams
    private void ManageTeams()
    {
        //1. View Teams Indexes
                //* 1. Console Prints Team Aliases Only
                    // Any Key Returns to Manage Teams Menu
                //* 2. Console Prints Team Aliases + Employee I.D.s
                    // Any Key Returns to Manage Teams Menu            
                //* 3. Console Prints All Team Info
                    // Any Key Returns to Manage Teams Menu
        //2. Search Team by Alias
                //* 1. Console returns team info based on userInput
        //3. Create New Team
                //* 1. Prompts userInput for new team alias
                //* 2. Lists Devs available for assignment
                    //1. Create team from available Devs?
                    //   yes - prompt user to enter Team I.D.'s to create new team (3)
                    //   no - go to Add / Remove Team Members menu
                    //   no - return to Manage Teams Menu
                //* 3. input employee I.D., then press enter, when finished adding team members, type Team Complete
                //* 4. Console Writeline:
                       // "New Team 'new team alias' created"
                       // 1. Create a New Team
                       // 2. Return to Manage Teams
                       // 3. Return to Main
        //4. Add Members to a Current Team
                //* 1. Select a Team to add members to:
                       // 1. Lists Current Team Aliases
                       // 2. Readline user input (teamAlias)
                //* 2. The Following Devs are available for assignment:
                       // 3. List Available Devs by ID + lastName, firstName
                       // 4. To add a Dev input I.D. and press Enter. When finished, type Team Complete
                       // When teamComplete = true, writeline:
                            //* Add Members to Another Team? (back to one)
                            //* 1. Return to Manage Teams
                            //* 2. Return to Main
        //5. Remove Members From a Current Team, or Delete a Current Team
                //* 1. Select a Team to Remove members from or delete:
                       // 1. Lists Current Team Aliases
                       // 2. Readline user input (teamAlias)
                //* 2. The Following Devs are assigned to this team:
                       // 3. List team roster ID + lastName, firstName
                       // 4. To remove a Dev input I.D. and press Enter. When finished, type Team Complete
                       // When teamComplete = true, writeline:
                            //* Remove Members from Another Team? (back to one)
                            //* 1. Return to Manage Teams
                            //* 2. Return to Main
                        // To Remove all members and delete team Alias, type Delete Team
                            //* Are you sure? This will remove all devs from team AND delete team alias.
                                // yes
                                // cancel - returns to //*1.
        //6. Delete all Team Aliases (requires all Devs be reassigned from scratch.)
                //* Are you sure? You will need to create all new Team Aliases for future dev assignments.
                    // yes
                    // cancel - returns to Manage Teams
        //7. Return to Main Menu
    }
//* 7. Run HR Report
    private void RunHrReport()
    {

        //Prints to console list of all Devs plus Access status for Web learning tool (has access / needs access)

    }
//* 10. Sign Out
    private void AppSignOut()
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
            +"Press Space + Enter to Return to Main Menu");
        var userInput = ReadLine();
        {
            switch (userInput)
            {
                case " ":
                    Console.Clear();
                    RunApplication();
                    break;
                default:
                    Console.Clear();
                    AppSignOut();
                    break;
            }
        };
    }
    
}