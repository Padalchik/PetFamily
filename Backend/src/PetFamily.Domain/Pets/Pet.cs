using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Domain.Pets;

public class Pet : Entity
{
    private readonly List<PaymentDetails> _paymentDetails = [];

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public PetTypeInfo TypeInfo { get; private set; }
    public PetHealthInfo HealthInfo { get; private set; }
    public Address.Address Address { get; private set; }
    public Phone.Phone PhoneNumber { get; private set; }
    public HelpStatus HelpStatus { get; private set; }
    public IReadOnlyList<PaymentDetails> PaymentDetails => _paymentDetails;
    public DateTime CreateDate { get; private set; }
    
    //ef core
    private Pet()
    {
    }

    private Pet(string name, PetTypeInfo typeInfo, PetHealthInfo healthInfo, string description, Address.Address address, Phone.Phone phone, HelpStatus helpStatus, IEnumerable<PaymentDetails> paymentDetails)
    {
        Name            = name;
        TypeInfo        = typeInfo;
        Description     = description;
        HealthInfo      = healthInfo;
        Address         = address;
        PhoneNumber     = phone;
        HelpStatus      = helpStatus;
        _paymentDetails = new List<PaymentDetails>(paymentDetails);
        CreateDate      = DateTime.Now;
    }
    
    public static Result<Pet> Create(string name, PetTypeInfo typeInfo, PetHealthInfo healthInfo, string description, Address.Address address, Phone.Phone phone, HelpStatus helpStatus, IEnumerable<PaymentDetails> paymentDetails)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>("Name is required");

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Pet>("Description is required");

        var pet = new Pet(name, typeInfo, healthInfo, description, address,
            phone, helpStatus, paymentDetails);

        return Result.Success(pet);
    }
}
