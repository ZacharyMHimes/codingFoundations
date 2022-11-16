

public class Teams_Repository
{
    private Devs_Repository _devRepo;

    private readonly List<Team> _devTeamDb = new List<Team>();

public Teams_Repository(Devs_Repository devRepo)
    {
        _devRepo = devRepo;
        PopulateTeams();
    }
    private int _count = 0;


//todo CREATE
    public bool AddTeamProfile(Team team)
    {
        if (team is null)
        {
            return false;
        }
        else
        {
            _count++;
            _count = team.TeamId;
            _devTeamDb.Add(team);
            return true;
        }
    }
//helper method - adding devs to a team
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
//todo READ
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
private void PopulateTeams()
    {

        var Borg = _devRepo.GetDeveloperByID(116479);
        var Corg = _devRepo.GetDeveloperByID(116480);
        var Dorg = _devRepo.GetDeveloperByID(116481);
        var Forg = _devRepo.GetDeveloperByID(116482);
        var Gorg = _devRepo.GetDeveloperByID(116483);
        
        var teamIndy = new Team()
        {
            TeamId = 1,
            TeamName = "Silicon Cornfield",
            TeamMembers = new List<Developer>{Borg,Corg}
        };

        var teamCali = new Team()
        {
            TeamId = 2,
            TeamName = "Silicon Valley",
            TeamMembers = new List<Developer>{Dorg}
        };

        var teamCopenhagen = new Team()
        {
            TeamId = 3,
            TeamName = "Silicon Fjord",
            TeamMembers = new List<Developer>{Forg,Gorg}
        };

        AddTeamProfile(teamIndy);
        AddTeamProfile(teamCali);
        AddTeamProfile(teamCopenhagen);
    }
}
