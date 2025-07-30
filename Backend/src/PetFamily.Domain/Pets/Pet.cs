using CSharpFunctionalExtensions;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Domain.Pets;

public class Pet : Entity
{
    private readonly List<PaymentDetails> _paymentDetails = [];

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Sex Sex { get; private set; }
    public Species.Species Species { get; private set; }
    public Breed Breed { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string Color { get; private set; } = string.Empty;
    public string HealthInfo { get; private set; } = string.Empty;
    public float WeightKg { get; private set; }
    public float HeightCm { get; private set; }
    public string Address { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public bool IsNeutered { get; private set; }
    public bool IsVaccinated { get; private set; }
    public DateTime BirthDate { get; private set; }
    public HelpStatus HelpStatus { get; private set; }
    public IReadOnlyList<PaymentDetails> PaymentDetails => _paymentDetails;
    public DateTime CreateDate { get; private set; }
    
    //ef core
    private Pet()
    {
    }

    private Pet(string name, Sex sex, Species.Species species, Breed breed, string description, string color,
        string healthInfo, float weightKg, float heightCm, string address, string phoneNumber, bool isNeutered,
        bool isVaccinated, DateTime birthDate, HelpStatus helpStatus, IEnumerable<PaymentDetails> paymentDetails)
    {
        Name = name;
        Sex = sex;
        Species = species;
        Breed = breed;
        Description = description;
        Color = color;
        HealthInfo = healthInfo;
        WeightKg = weightKg;
        HeightCm = heightCm;
        Address = address;
        PhoneNumber = phoneNumber;
        IsNeutered = isNeutered;
        IsVaccinated = isVaccinated;
        BirthDate = birthDate;
        HelpStatus = helpStatus;
        _paymentDetails = new List<PaymentDetails>(paymentDetails);
        CreateDate = DateTime.Now;
    }
    
    public static Result<Pet> Create(string name, Sex sex, Species.Species species, Breed breed, string description,
        string color, string healthInfo, float weightKg, float heightCm, string address, string phoneNumber,
        bool isNeutered, bool isVaccinated, DateTime birthDate, HelpStatus helpStatus,
        IEnumerable<PaymentDetails> paymentDetails)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>("Name is required");

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Pet>("Description is required");

        var pet = new Pet(name, sex, species, breed, description, color, healthInfo, weightKg, heightCm, address,
            phoneNumber, isNeutered, isVaccinated, birthDate, helpStatus, paymentDetails);

        return Result.Success(pet);
    }
}
