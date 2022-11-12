using Xunit;
namespace Devs_Repository_Tests;
public class Devs_Repository_Tests
{
    [Fact]
    public void AddDevProfile_ShouldGetCorrectBoolean()
    {
        //AAA

        //Arrange
        Developer profile = new Developer();
        Devs_Repository repository = new Devs_Repository();

        //Act 
        bool addDev = repository.AddDevProfile(profile);

        //Assert
        Assert.True(addDev);
    }


[Fact]
    public void Get_AllDevelopers_Should_Return_CorrectCollection()
    {
        //Arrange
        Developer profile = new Developer();
        Devs_Repository repository = new Devs_Repository();

        repository.AddDevProfile(profile);

        //Act 
        List<Developer> profiles = repository.GetAllDevelopers();

        bool dbaseHasProfile = profiles.Contains(profile);

        //Assert
        Assert.True(dbaseHasProfile);
    }


} 
