using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace RubinPortfolio.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// This method will hash the password given to method.
        /// </summary>
        /// <param name="pass">A plaintext password.</param>
        /// <returns>A hashed password.</returns>
        public string GetHash(string pass)
        {
            // Generate a 128-bit salt using a sequence of
            // cryptographically strong random bytes.
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: pass,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        }
    }
}
