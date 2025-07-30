using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : Entity
{
    private readonly List<PaymentDetails> _paymentDetails = [];
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Pet> _petsOwned = [];
    
    //ef core
    private Volunteer()
    {
    }

    public Guid Id { get; private set; }
    public string FIO { get; private set; }
    public string Email { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public int YearsOfExperience { get; private set; }
    public int PetsFoundHome => GetPetsByStatus(HelpStatus.FoundHome).Count;
    public int PetsNeedHome => GetPetsByStatus(HelpStatus.NeedHome).Count;
    public int PetsNeedHelp => GetPetsByStatus(HelpStatus.NeedHelp).Count;
    public string PhoneNumber { get; private set; } = string.Empty;
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyList<PaymentDetails> PaymentDetails => _paymentDetails;
    public IReadOnlyList<Pet> PetsOwned => _petsOwned;
    
    /*public static Result<Volunteer> Create()
    {
        
    }*/

    private List<Pet> GetPetsByStatus(HelpStatus status)
    {
        return _petsOwned.Where(p => p.HelpStatus == status).ToList();
    }
}