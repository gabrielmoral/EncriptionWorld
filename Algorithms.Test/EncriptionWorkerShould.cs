using EncriptionAlgorithms;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Test
{
    [TestClass]
    public class EncriptionWorkerShould
    {
        [TestMethod]
        public void AcceptMorseCipher()
        {
            var configuration = new EntriptionWorker(new MorseCipher());

            string encriptedText = configuration.Encript("some text to encript");

            encriptedText.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void AcceptCaesarCipher()
        {
            var configuration = new EntriptionWorker(new CaesarCipher(1));

            string encriptedText = configuration.Encript("some text to encript");

            encriptedText.Should().NotBeNullOrEmpty();
        }
    }
}