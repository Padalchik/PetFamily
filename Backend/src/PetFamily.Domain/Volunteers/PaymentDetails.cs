using CSharpFunctionalExtensions;

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

    public static Result<PaymentDetails> Create(string value, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<PaymentDetails>("Value cannot be empty");
        
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<PaymentDetails>("Name cannot be empty");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<PaymentDetails>("Description cannot be empty");
        
        var paymentDetails = new PaymentDetails(value, name, description);
        return Result.Success(paymentDetails);
    }
}