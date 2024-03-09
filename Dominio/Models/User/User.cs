using Domain.Models.Shared;
using Domain.Models.Tickets;
using Domain.Primitives;

namespace Domain.Models.User
{
    public class User : AggregateRoot
    {
        public Guid Id { get; private set; }
        public FiscalTypeEnum FiscalType { get; private set; }
        public FiscalNumber FiscalNumber { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber Phone { get; private set; }

        public User() { }

        // Constructor para la creación de un nuevo usuario
        private User(FiscalTypeEnum fiscalType, FiscalNumber fiscalNumber, Name name, Address address, PhoneNumber phone)
        {
            // Puedes generar un Id único para el usuario
            Id = Guid.NewGuid();

            // Validaciones adicionales según tus requisitos
            if (address == null)
            {
                throw new ArgumentException("La dirección no puede estar vacía o ser nula.", nameof(address));
            }
            Id = Guid.NewGuid();
            FiscalType = fiscalType;
            FiscalNumber = fiscalNumber;
            Name = name;
            Address = address;
            Phone = phone;
            Tickets = new List<Ticket>();
        }

        public static User Create(FiscalTypeEnum fiscalType, FiscalNumber fiscalNumber, Name name, Address address, PhoneNumber phone)
        {
            var NewUser = new User(fiscalType, fiscalNumber, name, address, phone);
            return NewUser;
        }

        // Método para agregar un ticket al usuario
        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);

        }
    }
}
