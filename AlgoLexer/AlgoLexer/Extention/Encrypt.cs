using AlgoLexerApi.Models;
using BCrypt.Net;
using DevOne.Security.Cryptography.BCrypt;

namespace AlgoLexer.Extention
{
    public static class Encrypt
    {
        public static string ToPassword(this string tocrypt)
        {
            return BCrypt.Net.BCrypt.HashPassword(tocrypt);        
        }

        public static bool CheckPassword(this string passwordHash, string passwordToTest )
        {
            return BCrypt.Net.BCrypt.Verify(passwordToTest,passwordHash);
        }
    }
}
