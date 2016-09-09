using EncriptionAlgorithms.Web.Models;
using System;
using System.Collections.Generic;

namespace EncriptionAlgorithms.Web.Controllers
{
    public class Commands
    {
        private static IDictionary<string, Func<EncriptionModel, string>> commands = new Dictionary<string, Func<EncriptionModel, string>>
        {
            ["Encript"] = (m) => GenerateCipher(m.Cipher).Encript(m.Text),
            ["Decript"] = (m) => GenerateCipher(m.Cipher, m.CaesarEncriptionKey).Decript(m.Text)
        };

        public static string Execute(string command, EncriptionModel encriptionModel)
        {
            return commands[command](encriptionModel);
        }

        private static ICipher GenerateCipher(Ciphers cipherType, int encriptionKey = 0)
        {
            if (cipherType == Ciphers.Morse)
            {
                return new MorseCipher();
            }
            else
            {
                return new CaesarCipher(encriptionKey);
            }
        }
    }
}