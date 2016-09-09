namespace EncriptionAlgorithms.Ciphers
{
    public class ReverseCipherFactory
    {
        private static ICipher currentCipher;
        private static ReverserCipher reverserCipher;

        public static ReverserCipher CreateReverseCipher(ICipher cipher)
        {
            if (cipher.GetType() == currentCipher?.GetType())
            {
                return reverserCipher;
            }

            currentCipher = cipher;
            reverserCipher = new ReverserCipher(cipher);

            return reverserCipher;
        }
    }
}