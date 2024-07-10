using PhoneNumbers;

namespace FitFad.Domain.Values
{
    public class Contact : AbstractValue<Contact>
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public List<string>? OtherNames { get; private set; }
        public string? Email { get; private set; }
        public string? Email1 { get; private set; }
        public string? Email2 { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }
        public PhoneNumber? PhoneNumber1 { get; private set; }
        public PhoneNumber? PhoneNumber2 { get; private set; }

        public string FullName => $"{FirstName} {LastName}";

        public Contact() { }

        public Contact(
            string? firstName,
            string? lastName,
            List<string>? otherNames,
            string? email,
            string? email1,
            string? email2,
            PhoneNumber? phoneNumber,
            PhoneNumber? phoneNumber1,
            PhoneNumber? phoneNumber2)
        {
            FirstName = firstName;
            LastName = lastName;
            OtherNames = otherNames;
            Email = email;
            Email1 = email1;
            Email2 = email2;
            PhoneNumber = phoneNumber;
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
        }

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
