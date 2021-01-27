using HashLibrary;

namespace Skany.Core
{
    public static class CryptHelper
    {
        public static int HashLength = 50;
        public static int SaltLength = 10;

        public static string HashPassword(string password, out string salt)
        {
            var hash = HashedPassword.New(password, hashLength: 50, saltLength: 10);
            salt = hash.Salt;
            return hash.Hash;
        }

        public static bool VerifyPassword(string password, string hashPassword, string salt)
        {
            var hash = new HashedPassword(hashPassword, salt);
            bool matches = hash.Check(password);
            return matches;
        }
    }
}
