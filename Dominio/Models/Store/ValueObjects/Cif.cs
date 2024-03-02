namespace Dominio.Models.Store.ValueObjects
{
    public class Cif
    {
        public string Number { get; }

        // Constructor para la creación de un nuevo objeto Dni
        public Cif(string number)
        {
            if (!CifValidate(number))
            {
                throw new ArgumentException("El DNI no es válido en España.", nameof(Number));
            }

            Number = number;
        }

        // Método para validar que el DNI es correcto según las reglas en España
        private bool CifValidate(string Number)
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
            char letra = char.ToUpper(Number[8]);
            if (!IsLetter(letra))
            {
                return false;
            }

            // Verificar que la letra corresponde a los primeros 8 dígitos
            int resto = int.Parse(Number.Substring(0, 8)) % 23;
            char letraCalculada = GetCifLetter(resto);

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
        private char GetCifLetter(int Number)
        {
            // Array con las letras posibles en un DNI
            char[] letters = "TRWAGMYFPDXBNJZSQVHLCKE".ToCharArray();

            return letters[Number];
        }
    }

}
