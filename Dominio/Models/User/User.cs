﻿using Dominio.Models.Shared;
using Dominio.Models.Tickets;
using Dominio.Primitives;

namespace Dominio.Models.User
{
    public class User : AggregateRoot
    {
        public Guid Id { get; }
        public FiscalTypeEnum FiscalType { get; private set; }
        public FiscalNumber FiscalNumber { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber Phone { get; private set; }
        public List<Ticket> Tickets { get; private set; }

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

            // Puedes agregar más validaciones según tus requisitos

            FiscalType = fiscalType;
            FiscalNumber = fiscalNumber;
            Name = name;
            Address = address;
            Phone = phone;
            Tickets = new List<Ticket>();
        }

        public User Create(FiscalTypeEnum fiscalType, FiscalNumber fiscalNumber, Name name, Address address, PhoneNumber phone, Ticket ticket)
        {
            var NewUser = new User(fiscalType, fiscalNumber, name, address, phone);
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
