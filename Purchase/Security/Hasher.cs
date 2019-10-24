using System.Security.Cryptography;

namespace Security
{
    class Hasher
    {
        public static byte[] CreateHash(string password, byte[] salt)
        {
            const int keyLenght = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            return pbkdf2.GetBytes(keyLenght);
        }

        public static byte[] CreateSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }
    }
}
