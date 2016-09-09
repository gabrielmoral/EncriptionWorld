using EncriptionAlgorithms.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EncriptionAlgorithms.Web.Controllers
{
    public class HomeController : Controller
    {
        private static IDictionary<Ciphers, ICipher> ciphers = new Dictionary<Ciphers, ICipher>
        {
            [Ciphers.Morse] = new MorseCipher(),
            [Ciphers.Caesar] = new CaesarCipher(1)
        };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Action(EncriptionModel encriptionModel, string command)
        {
            Dictionary<string, Func<EncriptionModel, string>> commands = DefineCommands();

            string resultText = commands[command](encriptionModel);

            var model = new EncriptionModel
            {
                Text = encriptionModel.Text,
                ResultText = resultText
            };

            return View("Index", model);
        }

        private static Dictionary<string, Func<EncriptionModel, string>> DefineCommands()
        {
            return new Dictionary<string, Func<EncriptionModel, string>>
            {
                ["Encript"] = (m) => ciphers[m.Cipher].Encript(m.Text),
                ["Decript"] = (m) => ciphers[m.Cipher].Decript(m.Text)
            };
        }
    }
}