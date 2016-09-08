using System;
using System.Linq;

namespace EncriptionAlgorithms
{
    public class MorseCipher : ICipher
    {
        public string Encript(string text)
        {
            var morseDictionary = new NormalMorseDictionary();

            var codeGenerator = text.Aggregate(new CodeGenerator(),
                                 (generator, code) =>
                                    generator.WriteWord(TranslateCode(code.ToString(), morseDictionary)));

            return codeGenerator.Output();
        }

        public string Decript(string morse)
        {
            string[] wordSeparator = { " / " };

            var morseDictionary = new ReverseMorseDictionary();

            var codeGenerator = morse.Split(wordSeparator, StringSplitOptions.None)
                                   .Aggregate(new CodeGenerator(),
                                               (generator, word) =>
                                                generator.WriteWord(ConvertMorseWord(word, morseDictionary)));

            return codeGenerator.Output();
        }

        private string ConvertMorseWord(string morseWord, MorseDictionaryDefinition morseDictionary)
        {
            string[] wordSeparator = { " " };

            var codeGenerator = morseWord.Split(wordSeparator, StringSplitOptions.None)
                                         .Aggregate(new CodeGenerator(),
                                         (generator, code) =>
                                            generator.Write(TranslateCode(code, morseDictionary)));

            return codeGenerator.Output();
        }

        private string TranslateCode(string character, MorseDictionaryDefinition morseDictionary)
        {
            return morseDictionary.GetTranslation(character);
        }
    }
}