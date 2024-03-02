using System.Text.RegularExpressions;
namespace Dominio.Models.Shared
{
    public class PhoneNumber : IEquatable<PhoneNumber>
    {
        // Propiedad para almacenar el número de teléfono
        public string Number { get; private set; }

        // Constructor para inicializar el número de teléfono
        public PhoneNumber(string number)
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

        // Sobrescribir el método Equals para la comparación de igualdad
        public override bool Equals(object obj)
        {
            return Equals(obj as PhoneNumber);
        }

        public bool Equals(PhoneNumber other)
        {
            return other != null && Number == other.Number;
        }

        // Sobrescribir el método GetHashCode para cumplir con las recomendaciones de igualdad
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        // Sobrescribir el método ToString para obtener una representación legible del objeto
        public override string ToString()
        {
            return Number;
        }
    }
}

