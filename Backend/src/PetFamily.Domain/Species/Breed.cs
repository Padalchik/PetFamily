using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Species;

public record Breed
{
    public string Name { get; }

    //ef core
    private Breed()
    {
        
    }
    
    private Breed(string name)
    {
        Name = name;
    }
    
    public static Result<Breed> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Breed>("Breed name cannot be empty");

        var breed = new Breed(name);
        return Result.Success(breed);
    }
}