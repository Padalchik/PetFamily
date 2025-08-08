using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public record SocialNetwork
{
    public string Name { get; }
    public string Url { get;}
    
    private SocialNetwork(string name, string url)
    {
        Name = name;
        Url = url;
    }
    
    public static Result<SocialNetwork, Error> Create(string name, string url)
    {
        if (string.IsNullOrEmpty(name))
            return Errors.General.ValueIsRequired("Name");
        
        if (string.IsNullOrEmpty(url))
            return Errors.General.ValueIsRequired("Url");
        
        var socialNetwork = new SocialNetwork(name, url);
        return Result.Success<SocialNetwork, Error>(socialNetwork);
    }
}