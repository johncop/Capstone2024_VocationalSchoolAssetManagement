using System.Security.Cryptography;

namespace ASM.Application.Helper
{
    public class CommonHelper
    {
        private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";
        private const string SpecialCharacters = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        public static string GenerateRandomPassword(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("Password length must be greater than zero.", nameof(length));
            }

            // Combine all characters for the password
            string allCharacters = UppercaseLetters + LowercaseLetters + Digits + SpecialCharacters;

            // Create a byte array to hold random values
            byte[] randomNumber = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }

            // Build the password
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                // Use modulo to select a character from the array
                password[i] = allCharacters[randomNumber[i] % allCharacters.Length];
            }

            return new string(password);
        }
    }
}
