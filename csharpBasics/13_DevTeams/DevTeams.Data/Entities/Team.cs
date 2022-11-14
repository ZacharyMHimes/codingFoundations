
//* This class describes the properties of each team stored in team repository list.
public class Team
{
        public Team
        (

            string teamName,
            List<Developer> teamMembers
        )
        {
            teamName = TeamName;
            teamMembers = TeamMembers;
        }

        public Team()
        {   
        }

// Properties
public int TeamId {get; set;}
public string TeamName {get; set;}
// Generates a new list populated with the Developers on the team
public List<Developer> TeamMembers {get; set;} = new List<Developer>();

// Method that converts all Team data into printable string for ease of use
public override string ToString()
{
    var report = $"TeamId: {TeamId}\n" +
                $"TeamName: {TeamName}\n" +
                $"--------  Team Members -------------\n";
    foreach (Developer profile in TeamMembers)
    {
        report += profile + "\n";
    }

    return report;
}

}