using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string consumerKey = "jUKRj9Wd98fawW8fpzddvJDIe";
            string consumerSecret = "zwO9V1Bf6cHyQrilVpkVBfckpHEgbLJ8lgMh7pXcCHrNpyqZw7";
            string accessToken = "299655316-Aw44Yhlv9YRQQvKNzu8lg6yMzvnlqBmcCzBXqiM1";
            string accessTokenSecret = "9R8zwZqnKN1aROEBZ6ALKAAbH9TUibj23i1DTQiW3kb8A";
            AuthenticationHandler auth = new AuthenticationHandler(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            auth.setCredentials();
            Console.WriteLine("Please input filter term to start stream");
            string filter = Console.ReadLine();
            if (!string.IsNullOrEmpty(filter))
            {
                StreamProvider.CreateFilteredStream(filter);
            }

        }
    }
}
