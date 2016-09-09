using EncriptionAlgorithms.Web.Controllers;
using EncriptionAlgorithms.Web.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace EncriptionAlgorithms.Web.Test
{
    [TestClass]
    public class ControllerTestsShould
    {
        private string encriptCommand = "Encript";
        private string decriptCommand = "Decript";

        [TestMethod]
        public void ReturnEncriptedDataWithTheView()
        {
            var controller = new HomeController();

            var model = new EncriptionModel
            {
                Cipher = Ciphers.Morse,
                Text = "hello world"
            };
            ViewResult result = (ViewResult)controller.Action(model, encriptCommand);

            EncriptionModel returnedModel = (EncriptionModel)result.ViewData.Model;

            returnedModel.ResultText.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void ReturnDecriptedDataWithTheView()
        {
            var controller = new HomeController();

            var model = new EncriptionModel
            {
                Cipher = Ciphers.Morse,
                Text = ".... . .-.. .-.. --- / .-- --- .-. .-.. -.."
            };
            ViewResult result = (ViewResult)controller.Action(model, decriptCommand);

            EncriptionModel returnedModel = (EncriptionModel)result.ViewData.Model;

            returnedModel.ResultText.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void ReturnInvalidModelWithTheView()
        {
            var controller = new HomeController();

            var model = new EncriptionModel
            {
                Cipher = Ciphers.Morse,
                Text = ".... . .-.. .-.. --- / .-- --- .-. .-.. -.."
            };
            ViewResult result = (ViewResult)controller.Action(model, encriptCommand);

            controller.ModelState.IsValid.Should().BeFalse();
        }
    }
}