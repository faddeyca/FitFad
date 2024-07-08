namespace FitFad.Domain.Values
{
    public class Address(
        string? streetNumber = null,
        string? streetName = null,
        string? city = null,
        string? suburb = null,
        string? postalCode = null,
        string? country = null) : AbstractValue<Address>
    {
        public string? StreetNumber { get; private set; } = streetNumber;
        public string? StreetName { get; private set; } = streetName;
        public string? City { get; private set; } = city;
        public string? Suburb { get; private set; } = suburb;
        public string? PostalCode { get; private set; } = postalCode;
        public string? Country { get; private set; } = country;

        public Address WithStreetNumber(string streetNumber)
        {
            return CopyAndSet(copy => copy.StreetNumber = streetNumber);
        }

        public Address WithStreetName(string streetName)
        {
            return CopyAndSet(copy => copy.StreetName = streetName);
        }

        public Address WithCity(string city)
        {
            return CopyAndSet(copy => copy.City = city);
        }

        public Address WithSuburb(string suburb)
        {
            return CopyAndSet(copy => copy.Suburb = suburb);
        }

        public Address WithPostalCode(string postalCode)
        {
            return CopyAndSet(copy => copy.PostalCode = postalCode);
        }

        public Address WithCountry(string country)
        {
            return CopyAndSet(copy => copy.Country = country);
        }

        public override string ToString()
        {
            return $"{StreetNumber} {StreetName}, {Suburb}, {City}, {PostalCode}, {Country}";
        }
    }
}
