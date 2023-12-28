using AddressBookShared.Interfaces;


namespace AddressBookShared.Models 
{

    
    public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public int? StreetNumber { get; set; } 
        public string City { get; set; } = null!;
        public int? PostalCode { get; set; }
        public string Country { get; set; } = null!;

    }
}

