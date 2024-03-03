namespace Domain.Models.Shared
{
    public class Name
    {
        private const int MaxLength = 40;

        public string Value { get; private set; }

        // Constructor para la creación de un nuevo objeto Nombre
        private Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El nombre es requerido.", nameof(value));
            }

            if (value.Length > MaxLength)
            {
                throw new ArgumentException($"El nombre no puede tener más de {MaxLength} caracteres.", nameof(value));
            }

            Value = value;
        }

        public static Name Create(string name)
        {
            return new Name(name);
        }


    }

}
