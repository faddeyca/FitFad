using PhoneNumbers;

namespace FitFad.Domain.Values
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
        PhoneNumber? phoneNumber2 = null) : AbstractValue<Contact>
    {
        public string? FirstName { get; private set; } = firstName;
        public string? LastName { get; private set; } = lastName;
        public List<string>? OtherNames { get; private set; } = otherNames;
        public string? Email { get; private set; } = email;
        public string? Email1 { get; private set; } = email1;
        public string? Email2 { get; private set; } = email2;
        public PhoneNumber? PhoneNumber { get; private set; } = phoneNumber;
        public PhoneNumber? PhoneNumber1 { get; private set; } = phoneNumber1;
        public PhoneNumber? PhoneNumber2 { get; private set; } = phoneNumber2;

        public Contact WithFirstName(string firstName)
        {
            return CopyAndSet(copy => copy.FirstName = firstName);
        }

        public Contact WithLastName(string lastName)
        {
            return CopyAndSet(copy => copy.LastName = lastName);
        }

        public Contact WithOtherNames(List<string> otherNames)
        {
            return CopyAndSet(copy => copy.OtherNames = otherNames);
        }

        public Contact WithEmail(string email)
        {
            return CopyAndSet(copy => copy.Email = email);
        }

        public Contact WithEmail1(string email1)
        {
            return CopyAndSet(copy => copy.Email1 = email1);
        }

        public Contact WithEmail2(string email2)
        {
            return CopyAndSet(copy => copy.Email2 = email2);
        }

        public Contact WithPhoneNumber(PhoneNumber phoneNumber)
        {
            return CopyAndSet(copy => copy.PhoneNumber = phoneNumber);
        }

        public Contact WithPhoneNumber1(PhoneNumber phoneNumber1)
        {
            return CopyAndSet(copy => copy.PhoneNumber1 = phoneNumber1);
        }

        public Contact WithPhoneNumber2(PhoneNumber phoneNumber2)
        {
            return CopyAndSet(copy => copy.PhoneNumber2 = phoneNumber2);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
