using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public class Breed
{
    public BreedId Id { get; private set; }
    public string Name { get; }

    //ef core
    private Breed()
    {
        
    }
    
    private Breed(BreedId id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public static Result<Breed> Create(BreedId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Breed>("Breed name cannot be empty");

        var breed = new Breed(id, name);
        return Result.Success(breed);
    }
}