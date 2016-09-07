using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncriptionAlgorithms
{
    internal abstract class MorseDictionaryDefinition
    {
        protected Dictionary<string, string> codes = new Dictionary<string, string>();

        public MorseDictionaryDefinition()
        {
            AddCode("A", ".-");
            AddCode("B", "-...");
            AddCode("C", "-.-.");
            AddCode("D", "-..");
            AddCode("E", ".");
            AddCode("F", "..-.");
            AddCode("G", "--.");
            AddCode("H", "....");
            AddCode("I", "..");
            AddCode("J", ".---");
            AddCode("K", "-.-");
            AddCode("L", ".-..");
            AddCode("M", "--");
            AddCode("N", "-.");
            AddCode("O", "---");
            AddCode("P", ".--.");
            AddCode("Q", "--.-");
            AddCode("R", ".-.");
            AddCode("S", "...");
            AddCode("T", "-");
            AddCode("U", "..-");
            AddCode("V", "...-");
            AddCode("W", ".--");
            AddCode("X", "-..-");
            AddCode("Y", "-.--");
            AddCode("Z", "--..");
            AddCode("1", ".----");
            AddCode("2", "..---");
            AddCode("3", "...--");
            AddCode("4", "....-");
            AddCode("5", ".....");
            AddCode("6", "-....");
            AddCode("7", "--...");
            AddCode("8", "---..");
            AddCode("9", "----.");
            AddCode("0", "-----");
            AddCode(" ", "/");
        }

        protected abstract void AddCode(string v1, string v2);

        public string GetTranslation(string code)
        {
            return codes[code.ToUpper()];
        }
    }
}