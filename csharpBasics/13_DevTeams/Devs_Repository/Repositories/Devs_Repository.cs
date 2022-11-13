
using static System.Console;
public class Devs_Repository
{
// Fake Database
private readonly List<Developer> _devDb = new List<Developer>();
private int _count = 116478;

// Initial database of dev profiles generated from info stored in SeedData method.
public Devs_Repository()
    {
        PopulateFromStored();
    }

//C.R.U.D -> Create, Read , Update , and Delete  (methods)

//todo CREATE METHOD
public bool AddDevProfile(Developer profile)
    {
        return (profile is null) ? false : AddToDatabase(profile);
    }

public bool AddToDatabase(Developer profile)
    {
        _count++;
        profile.Id=_count;
        _devDb.Add(profile);
        return true;
    }

//todo READ METHODS:
    //* Read GetAll:
public List<Developer> GetAllDevelopers()
    {
        return _devDb;
    }

    //* Get (helper) methods (Returns by checking value of a given property):
public Developer GetDeveloperByID(int searchId) //gets by Id
    {
        foreach (var profile  in _devDb) //cycles through list
        {
            if (profile.Id == searchId) //if ID matches
            {
                return profile;         //returns full profile
            }
        }
        return null;                    //if not, returns NOTHING >:^}
    }
public bool ValidateDeveloperInDatabase(int searchId)
    {
        Developer profile = GetDeveloperByID(searchId);
        if (profile != null)
        {
            Clear();
            return true;
        }
        else
        {
            WriteLine($"Found No Developer associated with ID: {searchId}");
            return false;
        }
    }

public Developer GetDeveloperByFirstName(string searchFirstName)
    {
        foreach (var profile  in _devDb)
        {
            if (profile.FirstName == searchFirstName)
            {
                return profile;
            }
        }
        return null;
    }

public Developer GetDeveloperByLastName(string searchLastName)
    {
        foreach (Developer profile  in _devDb)
        {
            if (profile.LastName == searchLastName)
            {
                return profile;
            }
        }
        return null;
    }
//todo UPDATE METHOD
public bool UpdateExistingProfile(int Id, Developer updatedProfile)
    {
        Developer oldProfile = GetDeveloperByID(Id); //Looks for Developer Identifier

        if (oldProfile != null) // executes if profile w/ that Id number is found
        {
            oldProfile.FirstName = updatedProfile.FirstName;
            oldProfile.LastName = updatedProfile.LastName;  // Updates values of each specified property
            oldProfile.HasPluralsight = updatedProfile.HasPluralsight; //* ID should be immutable - no updating
            return true;
        }
        else
        {
            return false; //if there is no profile w/ requested Id, should return null
        }
    }

//todo DELETE METHOD:
public bool DeleteExistingProfile(Developer existingProfile)
    {
        bool deleteResult = _devDb.Remove(existingProfile); // Removes 'existing' dev profile from _devDb database
        return deleteResult;                                // when functioning, should return 'true' allowing conditionals
    }                                                       //  to prompt UI text output

//* Not a C.R.U.D.  method - populates first example of repo up top.
private void PopulateFromStored()
{

    var profileA = new Developer( _count++,"Borg", "Borgenson", false );
    var profileB = new Developer( _count++,"Corg", "Corgenson", true );
    var profileC = new Developer( _count++,"Dorg", "Dorgenson", false );
    var profileD = new Developer( _count++,"Forg", "Forgenson", false );
    var profileE = new Developer( _count++,"Gorg", "Gorgenson", true );
    var profileF = new Developer( _count++,"Horg", "Horgenson", false );
    var profileG = new Developer( _count++,"Jorg", "Jorgenson", false );
    var profileH = new Developer( _count++,"Korg", "Korgenson", true );
    var profileI = new Developer( _count++,"Lorg", "Lorgenson", false);
    var profileJ = new Developer( _count++,"Morg", "Morgenson", true );

    AddDevProfile(profileA);
    AddDevProfile(profileB);
    AddDevProfile(profileC);
    AddDevProfile(profileD);
    AddDevProfile(profileE);
    AddDevProfile(profileF);
    AddDevProfile(profileG);
    AddDevProfile(profileH);
    AddDevProfile(profileI);
    AddDevProfile(profileJ);
}
}