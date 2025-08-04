using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : Entity
{
    private readonly List<PaymentDetails> _paymentDetails = [];
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Pet> _petsOwned = [];
    
    public VolunteerId Id { get; private set; }
    public string FIO { get; private set; }
    public string Email { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public int YearsOfExperience { get; private set; }
    public int PetsFoundHome => GetPetsByStatus(HelpStatus.FoundHome).Count;
    public int PetsNeedHome => GetPetsByStatus(HelpStatus.NeedHome).Count;
    public int PetsNeedHelp => GetPetsByStatus(HelpStatus.NeedHelp).Count;
    public Phone.Phone Phone { get; private set; }
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyList<PaymentDetails> PaymentDetails => _paymentDetails;
    public IReadOnlyList<Pet> PetsOwned => _petsOwned;
    
    //ef core
    private Volunteer()
    {
    }

    private Volunteer(VolunteerId id, string fio, string email, string description, int yearsOfExperience, Phone.Phone phone,
        IEnumerable<SocialNetwork> socialNetworks, IEnumerable<PaymentDetails> paymentDetails)
    {
        Id = id;
        FIO = fio;
        Email = email;
        Description = description;
        Phone = phone;
        YearsOfExperience = yearsOfExperience;
        _socialNetworks = new List<SocialNetwork>(socialNetworks);
        _paymentDetails = new List<PaymentDetails>(paymentDetails);
    }
    
    public static Result<Volunteer> Create(VolunteerId id, string fio, string email, string description, int yearsOfExperience, Phone.Phone phone,
        IEnumerable<SocialNetwork> socialNetworks, IEnumerable<PaymentDetails> paymentDetails)
    {
        if (string.IsNullOrWhiteSpace(fio))
            Result.Failure<Volunteer>("Fio cannot be null or empty");
        
        var volunteer = new Volunteer(id, fio, email, description, yearsOfExperience, phone, socialNetworks, paymentDetails);
        return Result.Success(volunteer);
    }
    
    private List<Pet> GetPetsByStatus(HelpStatus status)
    {
        return _petsOwned.Where(p => p.HelpStatus == status).ToList();
    }
}