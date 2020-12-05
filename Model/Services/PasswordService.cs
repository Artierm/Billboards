using System;

namespace BillboardProject.Models
{
    public class PasswordService
    {
        protected PasswordService() { }
        public static string CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            char[] hexArray = new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] hexChars = new char[bytes.Length * 2]; // Each byte has two hex characters (nibbles)
            int v;
            for (int j = 0; j < bytes.Length; j++)
            {
                v = bytes[j] & 0xFF; // Cast bytes[j] to int, treating as unsigned value
                hexChars[j * 2] = hexArray[v >> 4]; // Select hex character from upper nibble
                hexChars[j * 2 + 1] = hexArray[v & 0x0F]; // Select hex character from lower nibble
            }
            return new string(hexChars);
        }

        public static string GenerateSHAHash256(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            return ByteArrayToHexString(hash);
        }
    }
}
