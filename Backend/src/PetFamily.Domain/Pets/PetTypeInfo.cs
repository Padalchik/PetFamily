using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public record PetTypeInfo
{
    public Guid SpeciesId { get; }
    public Guid BreedId { get; }
    public string Color { get; }

    private PetTypeInfo(Guid speciesId, Guid breedId, string color)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
        Color = color;
    }
    
    public static Result<PetTypeInfo> Create(Guid speciesId, Guid breedId,  string color)
    {
        if (speciesId == Guid.Empty)
            Result.Failure("SpeciesId cannot be empty");
            
        if (breedId == Guid.Empty)
            Result.Failure("BreedId cannot be empty");
        
        if (string.IsNullOrEmpty(color))
            Result.Failure("Color cannot be empty");

        var petTypeInfo = new PetTypeInfo(speciesId, breedId,  color);
        return Result.Success(petTypeInfo);
    }
}