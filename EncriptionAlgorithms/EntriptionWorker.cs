namespace EncriptionAlgorithms
{
    public class EntriptionWorker
    {
        private ICipher cipher;

        public EntriptionWorker(ICipher morseAlgorithm)
        {
            this.cipher = morseAlgorithm;
        }

        public string Encript(string text)
        {
            return this.cipher.Encript(text);
        }
    }
}