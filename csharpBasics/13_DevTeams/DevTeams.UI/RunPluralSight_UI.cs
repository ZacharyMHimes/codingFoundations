using static System.Console;

public class RunPluralSight_UI //Contains Pluralsight report app
{

    private Devs_Repository _devRepo; //defines a Devs_Repository field
    private bool isRunningPluralReportUI; //Serves to turn on / off Pluralsight report app
    

    public RunPluralSight_UI()
        {
        _devRepo = new Devs_Repository();
        //_devUI = new DeveloperUI();
        //_devTeamUI = new DeveloperTeamUI(_devRepo);
        }

public void Run()
        {
            RunReport();
        }

private void RunReport()
        {
            isRunningPluralReportUI = true;
            while (isRunningPluralReportUI)
                {
                    GetReport();
                    ReadKey();
                    CloseReport();
                };
        }
private void CloseReport()
        {
            Console.Clear();
            isRunningPluralReportUI = false;   
        }

private void GetReport()
    {
        ListAllDeveloperProfiles();
    }

private void ListAllDeveloperProfiles()
    {
        List<Developer> devsInDb = _devRepo.GetAllDevelopers();
        ValidateDatabase_and_PrintReport(devsInDb);
    }

private void ValidateDatabase_and_PrintReport(List<Developer> devsInDb)
    {
        if (devsInDb.Count > 0)
        {
            foreach (Developer profile in devsInDb)
            {
                if (profile.HasPluralsight == false)
                {
                    System.Console.WriteLine ($" {profile.Id}   {profile.FirstName}   {profile.LastName} Needs Pluralsight Access");
                    //Console.ForegroundColor = ConsoleColor.Red; System.Console.WriteLine("Needs Pluralsight Access");ResetColor();
                }
                else
                {
                    System.Console.WriteLine ($" {profile.Id}   {profile.FirstName}   {profile.LastName}" ); 
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta; 
            System.Console.WriteLine("Return to Main");
            ReadKey();
            CloseReport();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("Something Went Wrong. Return to Main.");
            ReadKey();
            CloseReport();
        }
    }

}
