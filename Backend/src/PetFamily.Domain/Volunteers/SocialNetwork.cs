using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public record SocialNetwork
{
    public string Name { get; }
    public string Url { get;}
    
    //ef core
    private SocialNetwork(string name, string url)
    {
        Name = name;
        Url = url;
    }
    
    public static Result<SocialNetwork> Create(string name, string url)
    {
        if (string.IsNullOrEmpty(name))
            return Result.Failure<SocialNetwork>("Name cannot be empty");
        
        if (string.IsNullOrEmpty(url))
            return Result.Failure<SocialNetwork>("Url cannot be empty");
        
        var socialNetwork = new SocialNetwork(name, url);
        return Result.Success(socialNetwork);
    }
}