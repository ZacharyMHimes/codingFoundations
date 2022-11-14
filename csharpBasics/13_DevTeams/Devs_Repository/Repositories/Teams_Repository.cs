
//* This class holds the list of teams, and associated methods
/*public class Teams_Repository
{
        public Devs_Repository _devRepo;
        private readonly List<Team> _teamRepo = new List<Team>();
        private int _count;

        public Teams_Repository()
        {

        }       
        public Teams_Repository(Devs_Repository teams)
        {
        _devRepo = teams;
        PopulateTeams();
        }

//todo CREATE METHOD
    public bool AddTeamProfile(Team team)
    {
        return (team is null) ? false : AddToDatabase(team);
    }

public bool AddToDatabase(Team team)
            {
            _count++;
            team.TeamId = _count;
            _teamRepo.Add(team);
            return true;
            }
            
        
//todo READ METHODS:
public List<Team> GetAllTeams()
    {
        return _teamRepo;
    }

    //* Get (helper) methods (Returns by checking value of a given property):
public Team GetTeamByID(int searchId) //gets by Id
    {
        foreach (var team  in _devRepo) //cycles through list
        {
            if (team.TeamName == searchId) //if ID matches
            {
                return team;         //returns full profile
            }
        }
        return null;                   
    }
public bool ValidateTeamInDatabase(int searchId)
    {
        Team team = GetTeamByID(searchId);
        if (team != null)
        {
            return true;
        }
        else
        {
            System.Console.WriteLine
            (
                $"Found No Developer associated with ID: {searchId}"
            );
            return false;
        }
    }
    

private void PopulateTeams()
    {

        var Borg = _devRepo.GetDeveloperByID(116479);
        var Corg = _devRepo.GetDeveloperByID(116480);
        var Dorg = _devRepo.GetDeveloperByID(116481);
        var Forg = _devRepo.GetDeveloperByID(116482);
        var Gorg = _devRepo.GetDeveloperByID(116483);
        
        var teamCali = new Team("Front-End", new List<Developer>
        {
            Borg,
            Corg
        });

        var teamCopenhagen = new Team("Back-End", new List<Developer>
        {
            Dorg,
            Forg,
            Gorg
        });

        AddTeamProfile(teamCali);
        AddTeamProfile(teamCopenhagen);
    }
}*/
//------------------------------------------------------------

public class Teams_Repository
{
    private Devs_Repository _devRepo;

    private readonly List<Team> _devTeamDb = new List<Team>();
    private int _count;

    public Teams_Repository(Devs_Repository devRepo)
    {
        _devRepo = devRepo;
        PopulateTeams();
    }

    public bool AddTeamProfile(Team team)
    {
        if (team is null)
        {
            return false;
        }
        else
        {
            _count++;
            team.TeamId = _count;
            _devTeamDb.Add(team);
            return true;
        }
    }

    public List<Team> GetAllTeams()
    {
        return _devTeamDb;
    }

    public Team GetDeveloperTeam(int devTeamId)
    {
        foreach (Team team in _devTeamDb)
        {
            if (team.TeamId == devTeamId)
            {
                return team;
            }
        }
        return null;
    }

    public bool UpdateDevTeam(int devTeamId, Team updatedTeamData)
    {
        var teamInDB = GetDeveloperTeam(devTeamId);

        if (teamInDB != null)
        {
            teamInDB.TeamName = updatedTeamData.TeamName;
            teamInDB.TeamMembers = updatedTeamData.TeamMembers;
            return true;
        }
        return false;
    }

    public bool DeleteDeveloperTeam(int devTeamId)
    {
        var teamInDB = GetDeveloperTeam(devTeamId);
        return _devTeamDb.Remove(teamInDB);
    }

    public bool AddMultiDevsToTeam(int devTeamId, List<Developer> devs)
    {
        var teamInDB = GetDeveloperTeam(devTeamId);
        if (teamInDB != null && devs != null)
        {
            teamInDB.TeamMembers.AddRange(devs);
            return true;
        }
        else
        {
            return false;
        }
    }
private void PopulateTeams()
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
