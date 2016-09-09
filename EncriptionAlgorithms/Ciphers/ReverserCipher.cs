namespace EncriptionAlgorithms.Ciphers
{
    public class ReverserCipher
    {
        private string oldText;
        private ICipher cipher;

        public ReverserCipher(ICipher cipher)
        {
            this.cipher = cipher;
        }

        public string Reverse(string text)
        {
            if (string.IsNullOrEmpty(oldText))
            {
                oldText = cipher.Encript(text);
                return oldText;
            }
            else
            {
                var decriptedText = cipher.Decript(oldText);
                oldText = string.Empty;
                return decriptedText;
            }
        }
    }
}