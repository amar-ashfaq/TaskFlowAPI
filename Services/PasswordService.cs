using System.Security.Cryptography;
using System.Text;

namespace TaskFlowAPI.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly int keySize = 64;
        private readonly int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        
        public string HashPassword(string password, out byte[] passwordSalt)
        {
            passwordSalt = RandomNumberGenerator.GetBytes(keySize);

            var hashedPassword = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password), 
                passwordSalt, 
                iterations, 
                hashAlgorithm, 
                keySize);

            return Convert.ToHexString(hashedPassword);
        }
    }
}
