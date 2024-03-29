﻿using Domain.Models.Tickets.ValueObjects;
using Domain.Primitives;

namespace Domain.Models.Tickets
{
    // Clase para representar un ítem en el ticket
    public class TicketItem : AggregateRoot
    {
        public Guid ItemId { get; }
        public Guid TicketId { get; }
        public Description Description { get; private set; }
        public decimal Price { get; private set; }

        public TicketItem() { }
        // Constructor para la creación de un nuevo objeto TicketItem
        private TicketItem(Description description, decimal price)
        {
            // Puedes generar un Id único para el item
            ItemId = Guid.NewGuid();

            // Validaciones adicionales según tus requisitos
            if (description == null)
            {
                throw new ArgumentException("La descripción del item no puede estar vacía o ser nula.", nameof(description));
            }

            if (price < 0)
            {
                throw new ArgumentException("El precio del item no puede ser negativo.", nameof(price));
            }

            // Puedes agregar más validaciones según tus requisitos

            Description = description;
            Price = price;
        }
        public TicketItem Create(Description description, decimal price)
        {
            return new TicketItem(description, price);
        }
    }
}
