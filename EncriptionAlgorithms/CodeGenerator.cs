using System.Text;

namespace EncriptionAlgorithms
{
    public class CodeGenerator
    {
        private const string WHITESPACE = " ";

        private StringBuilder builder = new StringBuilder();

        public CodeGenerator WriteWord(string word)
        {
            builder.Append(word);
            builder.Append(WHITESPACE);

            return this;
        }

        public CodeGenerator Write(string word)
        {
            builder.Append(word);

            return this;
        }

        public string Output()
        {
            return builder.ToString().TrimEnd();
        }
    }
}