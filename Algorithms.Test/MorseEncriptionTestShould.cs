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

            morse.Should().Be(".... . .-.. .-.. --- / .-- --- .-. .-.. -..");
        }
    }
}