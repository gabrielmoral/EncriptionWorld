using EncriptionAlgorithms.Ciphers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EncriptionAlgorithms.Test
{
    [TestClass]
    public class ReverseCipherTestShould
    {
        [TestMethod]
        public void ReverseCipherActions()
        {
            var reverseCipher = ReverseCipherFactory.CreateReverseCipher(new MorseCipher());

            reverseCipher.Reverse("hello world")
                        .Should()
                        .BeEquivalentTo(".... . .-.. .-.. --- / .-- --- .-. .-.. -..");

            reverseCipher.Reverse("hello world")
                        .Should()
                        .BeEquivalentTo("hello world");
        }
    }
}