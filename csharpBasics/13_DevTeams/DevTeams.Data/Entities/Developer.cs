//* This class describes the qualities of each developer 
//* held by the developer repository list.
public class Developer
{
//* Example Constructor


    public Developer
    (
        int devID,
        string firstName, 
        string lastName, 
        bool hasPluralsight
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
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName},";
        }
    }
    public bool HasPluralsight { get; set; }
    
}
