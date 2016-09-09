using EncriptionAlgorithms.Ciphers;
using EncriptionAlgorithms.Web.Models;
using System;
using System.Collections.Generic;

namespace EncriptionAlgorithms.Web.Controllers
{
    public class Commands
    {
        private static IDictionary<string, Func<EncriptionModel, string>> commands = new Dictionary<string, Func<EncriptionModel, string>>
        {
            ["Encript"] = (m) => Encript(m),
            ["Decript"] = (m) => Decript(m),
            ["Reverse"] = (m) => Reverse(m)
        };

        public static string Execute(string command, EncriptionModel encriptionModel)
        {
            return commands[command](encriptionModel);
        }

        private static string Encript(EncriptionModel m)
        {
            return GenerateCipher(m.Cipher, m.CaesarEncriptionKey).Encript(m.Text);
        }

        private static string Decript(EncriptionModel m)
        {
            return GenerateCipher(m.Cipher, m.CaesarEncriptionKey).Decript(m.Text);
        }

        private static string Reverse(EncriptionModel m)
        {
            ICipher cipher = GenerateCipher(m.Cipher, m.CaesarEncriptionKey);

            return ReverseCipherFactory.CreateReverseCipher(cipher)
                                       .Reverse(m.Text);
        }

        private static ICipher GenerateCipher(Models.Ciphers cipherType, int encriptionKey)
        {
            if (cipherType == Models.Ciphers.Morse)
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