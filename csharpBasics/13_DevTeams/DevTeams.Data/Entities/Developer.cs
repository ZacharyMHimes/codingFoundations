//'Streaming Content' - Info Deliverable to User via UI
public class Developer
{
//* Example Constructor


    public Developer
    (
        int devID,
        string firstName, 
        string lastName, 
        bool hasPluralsight,
        string pluralsightHRReport
    )
    {   
        Id = devID;
        FirstName = firstName;
        LastName = lastName;
        HasPluralsight = hasPluralsight;
    }

    public Developer()
    {
    }

    //* Properties
    //  "Unique Identifier" (hint hint probably)
    public int Id = 1;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
    public bool HasPluralsight { get; set; }
    public string PluralsightHRReport
    {
        get
        {
            if (HasPluralsight == false)
            {
                return $"Needs access to Pluralsight";
            }
            else
            {
                return $"                           ";
            }
        }
    }
}
