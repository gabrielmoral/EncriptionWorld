using System;

namespace EncriptionAlgorithms
{
    [Serializable]
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}