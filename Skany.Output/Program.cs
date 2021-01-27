using System;

namespace Skany.Output
{
    class Program
    {
        static void Main(string[] args)
        {
            string salt = null;
            var password = "baidu";
            var hashPassword = CryptHelper.HashPassword(password, out salt);
            Console.WriteLine("Password => {0}", password);
            Console.WriteLine("HashPassword => {0}", hashPassword);
            Console.WriteLine("Salt => {0}", salt);


            var matchs = CryptHelper.VerifyPassword(password, hashPassword, salt);
            Console.WriteLine("Matchs: {0}", matchs);
            Console.ReadLine();
        }
    }
}
