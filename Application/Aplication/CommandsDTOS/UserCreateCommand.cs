using MediatR;

namespace Application.Aplication.CommandsDTOS
{
    public class UserCreateCommand : IRequest
    {
        public Guid Id { get; }
        public string FiscalType { get; set; }
        public string FiscalNumber { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string Floor { get; set; }
        public string Letter { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
    }
}
