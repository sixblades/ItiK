using Domain.Models.Tickets.ValueObjects;
using Domain.Primitives;

namespace Domain.Models.Tickets
{
    public class Ticket : AggregateRoot
    {
        public Guid Id { get; }
        public TicketNumber TicketNumber { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid UserId { get; private set; }

        public Ticket() { }

        // Constructor para la creación de un nuevo objeto Ticket
        private Ticket(TicketNumber ticketNumber, Guid customerId, Guid userId)
        {
            // Puedes generar un Id único para el ticket
            Id = Guid.NewGuid();

            // Validaciones adicionales según tus requisitos
            if (ticketNumber == null)
            {
                throw new ArgumentException("El número de ticket no puede estar vacío o ser nulo.", nameof(ticketNumber));
            }

            // Puedes agregar más validaciones según tus requisitos

            TicketNumber = ticketNumber;
            CustomerId = customerId;
            UserId = userId;

        }

        public Ticket Create(TicketNumber ticketNumber, Guid CustomerId, Guid UserId, TicketItem item)
        {
            var NewTicket = new Ticket(ticketNumber, CustomerId, UserId);
            return NewTicket;
        }



    }

}
