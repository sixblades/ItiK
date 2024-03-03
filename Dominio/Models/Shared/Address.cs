using Domain.Primitives;

namespace Domain.Models.Shared
{
    public class Address : AggregateRoot
    {
        public Guid Id { get; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string ZipCode { get; private set; }
        public string Floor { get; private set; }
        public string Letter { get; private set; }
        public string City { get; private set; }
        public string CountryCode { get; private set; }

        private Address(string street, string number, string zipCode, string floor, string letter, string city, string countryCode)
        {
            Id = Guid.NewGuid();
            Street = street;
            Number = number;
            ZipCode = zipCode;
            Floor = floor;
            Letter = letter;
            City = city;
            CountryCode = countryCode;
        }

        public static Address Create(string street, string number, string zipCode, string floor, string letter, string city, string countryCode)
        {
            return new Address(street, number, zipCode, floor, letter, city, countryCode);
        }
    }

}
