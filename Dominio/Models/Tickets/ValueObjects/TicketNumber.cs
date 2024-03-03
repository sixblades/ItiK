namespace Domain.Models.Tickets.ValueObjects
{
    public class TicketNumber
    {
        private const int MaxLength = 5;

        public string Value { get; set; }

        // Constructor para la creación de un nuevo objeto Nombre
        public TicketNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El numero de ticket es requerido.", nameof(value));
            }

            if (value.Length > MaxLength)
            {
                throw new ArgumentException($"El numero de ticket no puede tener más de {MaxLength} caracteres.", nameof(value));
            }

            Value = value;
        }
    }

}
