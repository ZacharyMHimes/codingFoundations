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
                        ListAllDeveloperProfilesToDisplay();
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
                case "6":
                    Console.Clear();
                    AddDevProfile();
                    break;
                case "7":
                    UserSearchId();
                    //ListAllDeveloperProfilesToSearch();
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

public void AddDevProfile()
    {
        try
        {
            Developer profile = UserProfileInput();
            if (_devRepo.AddToDatabase(profile))
            {
                System.Console.WriteLine($"Now You've gone and done it! {profile.FullName} has been added! >:^c ");
            }
            else
            { 
                System.Console.WriteLine("Unable to add new Dev Profile");
                ReadKey();
                DevIndexMenuReturn();
            }
        }
        catch 
        {
                System.Console.WriteLine("Unable to add new Dev Profile");
                ReadKey();
                DevIndexMenuReturn(); 
        }
        DevIndexMenuReturn();
    }

private Developer UserProfileInput()
    {
        Developer profile = new Developer();

        WriteLine("What is the Developers first name?");
        profile.FirstName = ReadLine();

        WriteLine("What is the Developers Last name?");
        profile.LastName = ReadLine();

        bool hasMadeSelection = false;

        while (!hasMadeSelection)
        {
            WriteLine("Does this Developer have a Pluralsight Account?\n" +
                "1. yes\n" +
                "2. no\n");

            string userInputPsAcct = ReadLine();
            switch (userInputPsAcct)
            {
                case "1":
                    profile.HasPluralsight = true;
                    hasMadeSelection = true;
                    break;

                case "2":
                    profile.HasPluralsight = false;
                    hasMadeSelection = true;
                    break;

                default:
                    WriteLine("Invalid Selection");
                    DevIndexMenuReturn();
                    break;
            }
        }

        return profile;
    }
    
private void ListAllDeveloperProfilesToDisplay()
    {
        List<Developer> devsInDb = _devRepo.GetAllDevelopers();
        ValidateDatabase_PrintData(devsInDb);
    }


private void ValidateDatabase_PrintData(List<Developer> devsInDb)
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

/*
private void ListAllDeveloperProfilesToSearch()
    {
        List<Developer> devsInDb = _devRepo.GetAllDevelopers();
        ValidateDatabase_RemoveDev(devsInDb);
    }
*/
/*
public void ValidateDatabase_RemoveDev(List<Developer> devsInDb)
    {
        if (devsInDb.Count > 0)
        {
            foreach (Developer profile in devsInDb)
            {
                if (profile.Id = int searchId)
                {
                    
                }
            }
        }
        else
        {
            WriteLine("No Developer Profiles Found.");
            ReadKey();
            DevIndexMenuReturn();
        }
    }
*/

private void DisplayDevProfile(Developer profile)
    {
        System.Console.WriteLine(profile);
    }

private void UserSearchId()
            {
                System.Console.WriteLine("Please Enter Developer ID number");           
                int searchId = int.Parse(Console.ReadLine());
                
            }
/*
private bool ValidateDeveloperInDatabase(int searchId)
    {
        Developer profile = GetDeveloperById(int searchId);
        if (profile != null)
        {
            Clear();
            return true;
        }
        else
        {
            WriteLine($"Could Not Find Developer ID: {userInputDevId}");
            return false;
        }
    }
    }
*/
}