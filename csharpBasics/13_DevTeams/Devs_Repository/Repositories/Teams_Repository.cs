
//* This class holds the list of teams, and associated methods
public class Teams_Repository
{
        public Devs_Repository _devRepo;
        private readonly List<Team> _teamRepo = new List<Team>();
        private int _count;

        public Teams_Repository()
        {

        }       
        public Teams_Repository(Devs_Repository devRepo)
        {
        _devRepo = devRepo;
        PopulateTeams();
        }

    public List<Team> GetDeveloperTeams()
    {
        return _teamRepo;
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
