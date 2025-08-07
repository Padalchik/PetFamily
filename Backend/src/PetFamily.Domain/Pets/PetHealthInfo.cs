using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets;

public record PetHealthInfo
{
    public Sex Sex  { get; }
    public float WeightKg { get; }
    public float HeightCm { get; }
    public DateTime BirthDate { get; }
    public bool IsNeutered { get; }
    public bool IsVaccinated { get; }
    public string Description { get; }
    
    private PetHealthInfo(Sex sex, float weightKg, float heightCm, DateTime birthDate, string description, bool isNeutered, bool isVaccinated)
    {
        Sex = sex;
        WeightKg = weightKg;
        HeightCm = heightCm;
        BirthDate = birthDate;
        Description = description;
        IsNeutered = isNeutered;
        IsVaccinated = isVaccinated;
    }

    public static Result<PetHealthInfo, Error> Create(Sex sex, float weightKg, float heightCm, DateTime birthDate, string description, bool isNeutered, bool isVaccinated)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsRequired("Description");

        if (weightKg <= 0)
            return Errors.General.ValueIsInvalid("WeightKg");
        
        if (heightCm <= 0)
            return Errors.General.ValueIsInvalid("HeightCm");
        
        var petHealthInfo = new PetHealthInfo(sex, weightKg, heightCm, birthDate ,description, isNeutered, isVaccinated);
        return Result.Success<PetHealthInfo, Error>(petHealthInfo);
    }
}

public enum Sex
{
    None = 0,
    Male = 1,
    Female = 2
}