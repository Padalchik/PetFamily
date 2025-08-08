using System.Numerics;
using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Phone;

public record Phone
{
    public string Number { get; }

    private Phone(string number)
    {
        Number = number;
    }

    public static Result<Phone, Error> Create(string number)
    {
        if (string.IsNullOrEmpty(number))
            return Errors.General.ValueIsRequired("Phone number");
        
        var cleaned = number.Replace(" ", "").Replace("-", "");
        
        if (!Regex.IsMatch(cleaned, @"^\+?\d{7,15}$"))
            return Errors.General.ValueIsInvalid("Phone number");

        var phone = new Phone(number);
        return Result.Success<Domain.Phone.Phone, Error>(phone);
    }
}