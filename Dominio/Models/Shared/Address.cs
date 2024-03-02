namespace Dominio.Models.Shared
{
    public class Address
    {
        public string Street { get; }
        public string Number { get; }
        public string ZipCode { get; }
        public string Floor { get; }
        public string Letter { get; }
        public string City { get; }
        public string CountryCode { get; }

        // Constructor para la creación de un nuevo objeto Address
        public Address(string street, string number, string zipCode, string floor, string letter, string city, string countryCode)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            Floor = floor;
            Letter = letter;
            City = city;
            CountryCode = countryCode;
        }
    }

}
