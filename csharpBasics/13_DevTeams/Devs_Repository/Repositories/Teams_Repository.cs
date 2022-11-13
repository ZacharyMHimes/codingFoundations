
//* This class holds the list of teams, and associated methods
public class Teams_Repository
{
        private Devs_Repository _devRepo;
        private readonly List<Teams_Repository> _teams = new List<Teams_Repository>();
        private int _count = 000001;

        
        public Teams_Repository(Devs_Repository devRepo)
        {
        _devRepo = devRepo;
        PopulateFromStored();
        }


public List<Developer> GetAllDevelopers()
    {
        return _devDb;
    }

//todo CREATE METHOD
public bool AddTeamProfile(Team team)
    {
        return (team is null) ? false : AddToDatabase(team);
    }

public bool AddToDatabase(Team team)
    {   _count++;
        team.TeamId = _count;
        _teams.Add(team);
        return true;
    }
private void PopulateFromStored()
    {

        var Borg = _devRepo.GetDeveloperByID(116479);
        var Corg = _devRepo.GetDeveloperByID(116480);
        var Dorg = _devRepo.GetDeveloperByID(116481);
        var Forg = _devRepo.GetDeveloperByID(116482);
        var Gorg = _devRepo.GetDeveloperByID(116483);
        var teamCali = new Team("Silicon Valley", new List<Developer>
        {
            Borg,
            Corg
        });

        var teamCopenhagen = new Team("Silicon Fjord", new List<Developer>
        {
            Dorg,
            Forg,
            Gorg
        });

        AddTeamProfile(teamCali);
        AddTeamProfile(teamCopenhagen);
    }
}
