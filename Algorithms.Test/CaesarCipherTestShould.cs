using EncriptionAlgorithms;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Test
{
    [TestClass]
    public class CaesarCipherTestShould
    {
        [TestMethod]
        public void EncriptTextUsingThreeAsEncriptionKey()
        {
            const int encriptionKey = 3;
            var cipher = new CaesarCipher(encriptionKey);

            string caesar = cipher.Encript("hello world");

            caesar.Should().BeEquivalentTo("khoor zruog");
        }

        [TestMethod]
        public void EncriptTextUsingFourAsEncriptionKey()
        {
            const int encriptionKey = 4;
            var cipher = new CaesarCipher(encriptionKey);

            string caesar = cipher.Encript("hello world");

            caesar.Should().BeEquivalentTo("lipps asvph");
        }

        [TestMethod]
        public void DecriptTextUsingFourAsEncriptionKey()
        {
            const int encriptionKey = 4;
            var cipher = new CaesarCipher(encriptionKey);

            string caesar = cipher.Decript("lipps asvph");

            caesar.Should().BeEquivalentTo("hello world");
        }

        [TestMethod]
        public void ThrowExceptionIfInvalidCharacter()
        {
            const int encriptionKey = 4;
            var cipher = new CaesarCipher(encriptionKey);

            cipher.Invoking(c => c.Encript("hello ···"))
                  .ShouldThrow<InvalidInputException>();
        }
    }
}