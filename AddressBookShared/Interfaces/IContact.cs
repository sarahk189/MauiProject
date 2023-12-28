using AddressBookShared.Models;

namespace AddressBookShared.Interfaces;

public interface IContact 
{
    string FirstName { get; set;  }
    string LastName { get; set; }
    int? PhoneNumber { get; set; }
    string Email { get; set; }
    string StreetName { get; set; }
    int? StreetNumber { get; set; }
    string City { get; set; }
    int? PostalCode { get; set; }
    string Country { get; set; }
}