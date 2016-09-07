using System;

namespace EncriptionAlgorithms
{
    public class EntriptionWorker
    {
        private MorseCipher morseAlgorithm;

        public EntriptionWorker(MorseCipher morseAlgorithm)
        {
            this.morseAlgorithm = morseAlgorithm;
        }

        public string Encript(string v)
        {
            return this.morseAlgorithm.Encript(v);
        }
    }
}