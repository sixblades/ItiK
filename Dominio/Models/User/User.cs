using Dominio.Models.Shared;
using Dominio.Models.Tickets;
using Dominio.Models.User.ValueObjects;
using Dominio.Primitives;

namespace Dominio.Models.User
{
    public class User : AggregateRoot
    {
        public Guid Id { get; }
        public Dni Dni { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber Phone { get; private set; }
        public List<Ticket> Tickets { get; private set; }

        // Constructor para la creación de un nuevo usuario
        private User(Dni dni, Name name, Address address, PhoneNumber phone)
        {
            // Puedes generar un Id único para el usuario
            Id = Guid.NewGuid();

            // Validaciones adicionales según tus requisitos


            if (address == null)
            {
                throw new ArgumentException("La dirección no puede estar vacía o ser nula.", nameof(address));
            }

            // Puedes agregar más validaciones según tus requisitos

            Dni = dni; //TO-DO Cambiar por NIF, un usuario podra ser español DNI, extranjero NIE o incluso una empresa
            Name = name;
            Address = address;
            Phone = phone;
            Tickets = new List<Ticket>();
        }

        public User Create(Dni dni, Name name, Address address, PhoneNumber phone, Ticket ticket)
        {
            var NewUser = new User(dni, name, address, phone);
            NewUser.AddTicket(ticket);
            return NewUser;
        }

        // Método para agregar un ticket al usuario
        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }
    }
}
