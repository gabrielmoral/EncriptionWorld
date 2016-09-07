using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncriptionAlgorithms
{
    public class MorseAlgorithm
    {
        private const string WHITESPACE = " ";

        public string EncriptText(string text)
        {
            var morseDictionary = new NormalMorseDictionary();

            StringBuilder sb = text.Aggregate(new StringBuilder(),
                                 (acc, code) =>
                                 {
                                     string convertedCode = TranslateCode(code.ToString(), morseDictionary);
                                     WriteCode(acc, convertedCode);
                                     WriteWhitespace(acc);

                                     return acc;
                                 });

            return sb.ToString().TrimEnd();
        }

        public string DecriptMorse(string morse)
        {
            string[] wordSeparator = { " / " };

            var morseDictionary = new ReverseMorseDictionary();

            StringBuilder sb = morse.Split(wordSeparator, StringSplitOptions.None)
                                   .Aggregate(new StringBuilder(),
                                               (acc, word) =>
                                               {
                                                   string convertedWord = ConvertMorseWord(word, morseDictionary);
                                                   WriteCode(acc, convertedWord);
                                                   WriteWhitespace(acc);
                                                   return acc;
                                               });

            return sb.ToString().TrimEnd();
        }

        private string ConvertMorseWord(string morseWord, MorseDictionaryDefinition morseDictionary)
        {
            string[] wordSeparator = { WHITESPACE };

            var codeAcumulator = morseWord.Split(wordSeparator, StringSplitOptions.None)
                                         .Aggregate(new StringBuilder(), (acc, code) =>
                                         {
                                             string convertedCode = TranslateCode(code, morseDictionary);
                                             WriteCode(acc, convertedCode);
                                             return acc;
                                         });

            return codeAcumulator.ToString();
        }

        private string TranslateCode(string character, MorseDictionaryDefinition morseDictionary)
        {
            return morseDictionary.GetTranslation(character);
        }

        private void WriteCode(StringBuilder acc, string character)
        {
            acc.Append(character);
        }

        private void WriteWhitespace(StringBuilder acc)
        {
            acc.Append(WHITESPACE);
        }
    }
}