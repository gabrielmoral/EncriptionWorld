using EncriptionAlgorithms;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithms.Test
{
    [TestClass]
    public class EncriptionWorkerShould
    {
        [TestMethod]
        public void AcceptMorseEncriptionAlgorithm()
        {
            var configuration = new EntriptionWorker(new MorseCipher());

            string encriptedText = configuration.Encript("some text to encript");

            encriptedText.Should().NotBeNullOrEmpty();
        }
    }
}