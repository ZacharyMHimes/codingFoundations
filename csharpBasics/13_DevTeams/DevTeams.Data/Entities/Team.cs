
//* This class describes the properties of each team stored in team repository list.
public class Team
{
        // Needs name property, int unique identifer, 'members' string.

// Properties
public int Id {get; set;}
public string TeamName {get; set;}
// Generates a new list populated with the Developers on the team
public List<Developer> TeamMembers {get; set;} = new List<Developer>();

// Method that converts all Team data into printable string for ease of use
public override string ToString()
{
    var str = $"TeamId: {Id}\n" +
                $"TeamName: {TeamName}\n" +
                $"--------  Team Members -------------\n";
    foreach (Developer dev in TeamMembers)
    {
        str += dev + "\n";
    }

    return str;
    }
}