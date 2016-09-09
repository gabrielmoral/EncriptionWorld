using EncriptionAlgorithms.Web.Models;
using System;
using System.Collections.Generic;

namespace EncriptionAlgorithms.Web.Controllers
{
    public class Commands
    {
        private static IDictionary<Ciphers, ICipher> ciphers = new Dictionary<Ciphers, ICipher>
        {
            [Ciphers.Morse] = new MorseCipher(),
            [Ciphers.Caesar] = new CaesarCipher(1)
        };

        private static IDictionary<string, Func<EncriptionModel, string>> commands = new Dictionary<string, Func<EncriptionModel, string>>
        {
            ["Encript"] = (m) => ciphers[m.Cipher].Encript(m.Text),
            ["Decript"] = (m) => ciphers[m.Cipher].Decript(m.Text)
        };

        public static string Execute(string command, EncriptionModel encriptionModel)
        {
            return commands[command](encriptionModel);
        }
    }
}