using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

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
    
    public static Result<PetTypeInfo, Error> Create(Guid speciesId, Guid breedId,  string color)
    {
        if (speciesId == Guid.Empty)
            return Errors.General.ValueIsRequired("SpeciesId");
            
        if (breedId == Guid.Empty)
            return Errors.General.ValueIsRequired("BreedId");
        
        if (string.IsNullOrEmpty(color))
            return Errors.General.ValueIsRequired("Color");

        var petTypeInfo = new PetTypeInfo(speciesId, breedId,  color);
        return Result.Success<PetTypeInfo, Error>(petTypeInfo);
    }
}