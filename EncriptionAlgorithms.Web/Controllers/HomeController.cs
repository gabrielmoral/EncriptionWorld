using EncriptionAlgorithms.Web.Models;
using System.Web.Mvc;

namespace EncriptionAlgorithms.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Action(string text, string command)
        {
            string resultText = string.Empty;

            if (command == "Encript")
            {
                resultText = EncriptText(text);
            }
            else if (command == "Decript")
            {
                resultText = DecriptText(text);
            }
            else
            {
            }

            var model = new EncriptionModel { Text = text, ResultText = resultText };
            return View("Index", model);
        }

        private string EncriptText(string text)
        {
            var morseCipher = new MorseCipher();
            return morseCipher.Encript(text);
        }

        private string DecriptText(string text)
        {
            var morseCipher = new MorseCipher();
            return morseCipher.Decript(text);
        }
    }
}