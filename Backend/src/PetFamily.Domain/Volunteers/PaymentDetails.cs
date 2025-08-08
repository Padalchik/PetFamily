using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public record PaymentDetails
{
    public string Name { get; }
    public string Description { get; }
    public string Value { get;}
    
    private PaymentDetails(string value, string name, string description)
    {
        Value = value;
        Name = name;
        Description = description;
    }

    public static Result<PaymentDetails, Error> Create(string value, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("Value");
        
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsRequired("Name");
        
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsRequired("Description");
        
        var paymentDetails = new PaymentDetails(value, name, description);
        return Result.Success<PaymentDetails, Error>(paymentDetails);
    }
}