using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncriptionAlgorithms
{
    public class CaesarCipher
    {
        private int encriptionKey;
        private const string WHITESPACE = " ";
        private string[] wordSeparator = { WHITESPACE };
        private List<char> alphabet;

        public CaesarCipher(int encriptionKey)
        {
            this.alphabet = GenerateAlphabet();

            this.encriptionKey = encriptionKey;
        }

        public string Encript(string text)
        {
            return Translate(text, encriptionKey);
        }

        public string Decript(string text)
        {
            int decriptKey = -encriptionKey;

            return Translate(text, decriptKey);
        }

        private string Translate(string text, int encriptionKey)
        {
            StringBuilder pepe = text.ToUpper()
                                    .Split(wordSeparator, StringSplitOptions.None)
                                    .Aggregate(new StringBuilder(), (acc, x) =>
                                    {
                                        WriteWord(acc, ConvertWord(x, alphabet, encriptionKey));
                                        WriteWhiteSpace(acc);
                                        return acc;
                                    });

            return pepe.ToString().TrimEnd();
        }

        private string ConvertWord(string word, List<char> alphabet, int caesarKey)
        {
            int arrayCorrectorFactor = 1;

            var convertedCharacters = word.Select(x =>
            {
                var characterPosition = alphabet.IndexOf(x);
                var alphabetPosition = characterPosition + caesarKey;
                var absolutePosition = alphabetPosition + arrayCorrectorFactor;

                if (absolutePosition > alphabet.Count)
                {
                    alphabetPosition = alphabet.Count - characterPosition - encriptionKey;
                }
                if (absolutePosition < 0)
                {
                    alphabetPosition = alphabet.Count + characterPosition - encriptionKey;
                }
                return alphabet[Math.Abs(alphabetPosition)];
            });

            return string.Join(string.Empty, convertedCharacters);
        }

        private void WriteWord(StringBuilder acc, string word)
        {
            acc.Append(word);
        }

        private void WriteWhiteSpace(StringBuilder acc)
        {
            acc.Append(WHITESPACE);
        }

        private List<char> GenerateAlphabet()
        {
            return Enumerable.Range('A', 'Z' - 'A' + 1)
                                                 .Select(c => (char)c)
                                                 .ToList();
        }
    }
}