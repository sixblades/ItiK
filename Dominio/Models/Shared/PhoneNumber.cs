using System.Text.RegularExpressions;
namespace Domain.Models.Shared
{
    public class PhoneNumber
    {
        // Propiedad para almacenar el número de teléfono
        public string Number { get; private set; }

        // Constructor para inicializar el número de teléfono
        private PhoneNumber(string number)
        {
            //validaciones
            if (string.IsNullOrWhiteSpace(Number))
            {
                throw new ArgumentException("El número de teléfono no puede estar vacío o ser nulo.", nameof(Number));
            }
            if (!IsNumberValid(Number))
            {
                throw new ArgumentException("El número de teléfono no es válido para España.", nameof(Number));
            }
            Number = number;
        }
        private bool IsNumberValid(string numero)
        {
            // Expresión regular para validar números de teléfono en España
            string patron = @"^(?:(?:(?:\+|00)34[\s\.\-]?)?(?:[689]\d{2}[\s\.\-]?\d{6}|[79]\d{1}[\s\.\-]?(?:\d{2}[\s\.\-]?\d{2}[\s\.\-]?\d{2}[\s\.\-]?\d{2})))$";

            // Verificar si el número coincide con el patrón
            return Regex.IsMatch(numero, patron);
        }

        public static PhoneNumber Create(string number)
        {
            return new PhoneNumber(number);
        }

    }
}

