using System.Security.AccessControl;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Address;

public record Address
{
    public string City { get; }
    public string Street { get; }
    public string HouseNumber { get; }

    private Address(string city, string street, string houseNumber)
    {
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }

    public static Result<Address, Error> Create(string city, string street, string houseNumber)
    {
        if (string.IsNullOrEmpty(city))
            return Errors.General.ValueIsRequired("City");
        
        if (string.IsNullOrEmpty(street))
            return Errors.General.ValueIsRequired("Street");
        
        if (string.IsNullOrEmpty(houseNumber))
            return Errors.General.ValueIsRequired("House");
        
        var address = new Address(city, street, houseNumber);
        return Result.Success<Address, Error>(address);
    }
    
    public override string ToString()
    {
        var partOfAddress = new List<string>()
        { 
            City, 
            Street, 
            HouseNumber 
        };

        var filteredParts = partOfAddress.Where(part => string.IsNullOrWhiteSpace(part) == false);
        return string.Join(", ", filteredParts);
    }
}