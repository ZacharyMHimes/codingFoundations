
//* This class describes the properties of each team stored in team repository list.
public class Team
{
        public Team
        (   int teamId,
            string teamName,
            List<Developer> teamMembers
        )
        {   teamId = TeamId;
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

}