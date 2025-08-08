using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

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
    
    public static Result<Breed, Error> Create(BreedId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsRequired("Breed name");

        var breed = new Breed(id, name);
        return Result.Success<Breed, Error>(breed);
    }
}