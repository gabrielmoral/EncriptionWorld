using EncriptionAlgorithms;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Test
{
    [TestClass]
    public class MorseEncriptionTestShould
    {
        [TestMethod]
        public void EncriptTextToMorse()
        {
            MorseCipher cipher = new MorseCipher();

            string morse = cipher.Encript("hello world");

            morse.Should().BeEquivalentTo(".... . .-.. .-.. --- / .-- --- .-. .-.. -..");
        }

        [TestMethod]
        public void EncriptMorseToText()
        {
            MorseCipher cipher = new MorseCipher();

            string text = cipher.Decript(".... . .-.. .-.. --- / .-- --- .-. .-.. -..");

            text.Should().BeEquivalentTo("hello world");
        }

        [TestMethod]
        public void ThrowExceptionIfInvalidCharacter()
        {
            MorseCipher cipher = new MorseCipher();

            cipher.Invoking(c => c.Encript(".... . .-.. .-.. --- / .-- --- .-. .-.. -.."))
                  .ShouldThrow<InvalidInputException>();
        }
    }
}