using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Species
{
    private List<Breed> _breeds;
    
    public Guid Id { get; private set; }
    public string Name { get; } = string.Empty;
    public IReadOnlyList<Breed> Breeds => _breeds;
    
    //ef core
    private Species()
    {
        
    }

    private Species(string name, IEnumerable<Breed> breeds)
    {
        Name = name;
        _breeds = new List<Breed>(breeds);
    }
    
    public static Result<Species> Create(string name, IEnumerable<Breed> breeds)
    {
        if (string.IsNullOrEmpty(name))
            return Result.Failure<Species>("Species name cannot be empty");

        var species = new Species(name, breeds);
        return Result.Success(species);
    }
}