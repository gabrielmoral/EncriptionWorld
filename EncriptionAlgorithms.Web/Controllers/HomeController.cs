using EncriptionAlgorithms.Web.Models;
using System.Web.Mvc;

namespace EncriptionAlgorithms.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new EncriptionModel());
        }

        public ActionResult Action(EncriptionModel encriptionModel, string command)
        {
            if (!ModelState.IsValid) return View("Index", encriptionModel);

            EncriptionModel model = encriptionModel;

            try
            {
                string resultText = Commands.Execute(command, encriptionModel);

                model = new EncriptionModel
                {
                    Text = encriptionModel.Text,
                    ResultText = resultText
                };
            }
            catch (InvalidInputException ex)
            {
                ModelState.AddModelError("Text", ex);
            }

            return View("Index", model);
        }
    }
}