using CSharpFunctionalExtensions;

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

    //ef core
    private PetHealthInfo()
    {
        
    }
    
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

    public static Result<PetHealthInfo> Create(Sex sex, float weightKg, float heightCm, DateTime birthDate, string description, bool isNeutered, bool isVaccinated)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<PetHealthInfo>("Description cannot be empty.");

        if (weightKg <= 0)
            return Result.Failure<PetHealthInfo>("WeightKg cannot be less than zero.");
        
        if (heightCm <= 0)
            return Result.Failure<PetHealthInfo>("HeightCm cannot be less than zero.");
        
        var petHealthInfo = new PetHealthInfo(sex, weightKg, heightCm, birthDate ,description, isNeutered, isVaccinated);
        return Result.Success(petHealthInfo);
    }
}