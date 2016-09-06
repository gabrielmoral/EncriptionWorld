using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithms.Test
{
    [TestClass]
    public class MorseEncriptionTestShould
    {
        [TestMethod]
        public void EncriptTextToMorse()
        {
            MorseAlgorithm algorithm = new MorseAlgorithm();

            string morse = algorithm.EncriptText("hello world");

            morse.Should().BeEquivalentTo(".... . .-.. .-.. --- / .-- --- .-. .-.. -..");
        }

        [TestMethod]
        public void EncriptMorseToText()
        {
            MorseAlgorithm algorithm = new MorseAlgorithm();

            string text = algorithm.DecriptMorse(".... . .-.. .-.. --- / .-- --- .-. .-.. -..");

            text.Should().BeEquivalentTo("hello world");
        }
    }
}