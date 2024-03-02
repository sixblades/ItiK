namespace Dominio.Models.Shared
{
    public class TicketNumber
    {
        private const int MaxLength = 5;

        public string Value { get; }

        // Constructor para la creación de un nuevo objeto Nombre
        private TicketNumber(string value)
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
        public TicketNumber Create(String value)
        {
            return new TicketNumber(value);
        }
    }

}
