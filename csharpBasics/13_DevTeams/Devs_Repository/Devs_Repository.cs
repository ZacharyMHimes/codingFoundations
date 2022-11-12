using System.Collections.Generic;
using static System.Console;
public class Devs_Repository
{
// Fake Database
private readonly List<Developer> _devDb = new List<Developer>();
private int _count = 0;

//C.R.U.D -> Create, Read , Update , and Delete  (methods)

//todo CREATE METHOD
public bool AddDevProfile(Developer profile)
    {
        int startingCount = _devDb.Count;
        _devDb.Add(profile);

        if (_devDb.Count > startingCount)
        {
            return true;
        }
        else
        {
            return false;
        }
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
        foreach (var profile  in _devDb)
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

}