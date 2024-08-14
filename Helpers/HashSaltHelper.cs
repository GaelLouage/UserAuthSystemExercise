using System.Security.Cryptography;
using System.Text;

namespace UserAuthenticationSystem.Helpers
{
    public static class HashSaltHelper
    {
        // Generate a random salt
        public static string GenerateSalt(int size = 16)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[size];
                rng.GetBytes(saltBytes);

                // Convert salt to a string for storage
                return Convert.ToBase64String(saltBytes);
            }
        }

        // Hash the password with the salt using SHA-256
        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Combine password and salt
                string saltedPassword = password + salt;
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Convert hash to a string for storage
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
