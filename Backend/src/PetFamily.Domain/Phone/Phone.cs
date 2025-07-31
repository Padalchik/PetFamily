using System.Numerics;
using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Phone;

public record Phone
{
    public string Number { get; }

    //ef core
    private Phone()
    {
        
    }

    private Phone(string number)
    {
        Number = number;
    }

    public static Result<Phone> Create(string number)
    {
        if (string.IsNullOrEmpty(number))
            return Result.Failure<Phone>("Phone number cannot be empty");
        
        var cleaned = number.Replace(" ", "").Replace("-", "");
        
        if (!Regex.IsMatch(cleaned, @"^\+?\d{7,15}$"))
            return Result.Failure<Phone>("Phone number does not match the format");

        var phone = new Phone(number);
        return Result.Success(phone);
    }
}