using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species;

public class Species
{
    private List<Breed> _breeds;
    
    public SpeciesId Id { get; private set; }
    public string Name { get; } = string.Empty;
    public IReadOnlyList<Breed> Breeds => _breeds;
    
    //ef core
    private Species()
    {
        
    }

    private Species(SpeciesId id, string name, IEnumerable<Breed> breeds)
    {
        Id = id;
        Name = name;
        _breeds = new List<Breed>(breeds);
    }
    
    public static Result<Species, Error> Create(SpeciesId id, string name, IEnumerable<Breed> breeds)
    {
        if (string.IsNullOrEmpty(name))
            return Errors.General.ValueIsRequired("Species name");

        var species = new Species(id, name, breeds);
        return Result.Success<Domain.Species.Species, Error>(species);
    }
}