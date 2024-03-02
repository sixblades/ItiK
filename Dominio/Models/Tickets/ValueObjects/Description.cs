namespace Dominio.Models.Tickets.ValueObjects
{
    using System;

    public class Description
    {
        private const int MaxLength = 140;

        public string Value { get; }

        // Constructor para la creación de un nuevo objeto Description
        public Description(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("La descripcion es requerida.", nameof(value));
            }

            if (value.Length > MaxLength)
            {
                throw new ArgumentException($"La descripcion no puede tener más de {MaxLength} caracteres.", nameof(value));
            }

            Value = value;
        }
    }

}
