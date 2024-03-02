namespace Dominio.Models.User.ValueObjects
{
    public class Dni
    {
        public string Number { get; }

        // Constructor para la creación de un nuevo objeto Dni
        public Dni(string number)
        {
            if (!DniValidate(number))
            {
                throw new ArgumentException("El DNI no es válido en España.", nameof(Number));
            }

            Number = number;
        }

        // Método para validar que el DNI es correcto según las reglas en España
        private bool DniValidate(string Number)
        {
            // Verificar la longitud del DNI
            if (Number.Length != 9)
            {
                return false;
            }

            // Verificar que los primeros 8 caracteres son dígitos
            if (!IsNumber(Number.Substring(0, 8)))
            {
                return false;
            }

            // Verificar que el último caracter es una letra
            char letra = Char.ToUpper(Number[8]);
            if (!IsLetter(letra))
            {
                return false;
            }

            // Verificar que la letra corresponde a los primeros 8 dígitos
            int resto = int.Parse(Number.Substring(0, 8)) % 23;
            char letraCalculada = GetDniLetter(resto);

            return letra == letraCalculada;
        }

        // Método para verificar si una cadena es un número
        private bool IsNumber(string str)
        {
            return int.TryParse(str, out _);
        }

        // Método para verificar si un caracter es una letra
        private bool IsLetter(char letter)
        {
            return letter >= 'A' && letter <= 'Z';
        }

        // Método para obtener la letra correspondiente a un número
        private char GetDniLetter(int Number)
        {
            // Array con las letras posibles en un DNI
            char[] letters = "TRWAGMYFPDXBNJZSQVHLCKE".ToCharArray();

            return letters[Number];
        }
    }

}
