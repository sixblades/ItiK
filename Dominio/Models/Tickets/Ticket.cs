using Dominio.Models.Shared;

namespace Dominio.Models.Tickets
{
    public class Ticket
    {
        public Guid Id { get; }
        public TicketNumber TicketNumber { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid UserId { get; private set; }
        public List<TicketItem> Items { get; private set; }

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
            Items = new List<TicketItem>();
        }

        public Ticket Create(TicketNumber ticketNumber, Guid CustomerId, Guid UserId, TicketItem item)
        {
            var NewTicket = new Ticket(ticketNumber, CustomerId, UserId);
            NewTicket.AddItem(item);
            return NewTicket;
        }

        // Método para agregar un item al ticket
        public void AddItem(TicketItem item)
        {
            Items.Add(item);
        }
    }

}
