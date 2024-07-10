using PhoneNumbers;

namespace FitFad.Domain.Entities
{
    public class Contact(
        string? firstName = null,
        string? lastName = null,
        List<string>? otherNames = null,
        string? email = null,
        string? email1 = null,
        string? email2 = null,
        PhoneNumber? phoneNumber = null,
        PhoneNumber? phoneNumber1 = null,
        PhoneNumber? phoneNumber2 = null) : AbstractEntity<Contact>
    {
        public string? FirstName { get; set; } = firstName;
        public string? LastName { get; set; } = lastName;
        public List<string>? OtherNames { get; set; } = otherNames;
        public string? Email { get; set; } = email;
        public string? Email1 { get; set; } = email1;
        public string? Email2 { get; private set; } = email2;
        public PhoneNumber? PhoneNumber { get; set; } = phoneNumber;
        public PhoneNumber? PhoneNumber1 { get; set; } = phoneNumber1;
        public PhoneNumber? PhoneNumber2 { get; set; } = phoneNumber2;

        public string FullName => $"{FirstName} {LastName}";
    }
}
