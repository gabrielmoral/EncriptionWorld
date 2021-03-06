﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EncriptionAlgorithms
{
    public class CaesarCipher : ICipher
    {
        private int encriptionKey;
        private string[] wordSeparator = { " " };
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
            CodeGenerator codeGenerator = text.ToUpper()
                                    .Split(wordSeparator, StringSplitOptions.None)
                                    .Aggregate(new CodeGenerator(),
                                        (generator, word) =>
                                        generator.WriteWord(ConvertWord(word, alphabet, encriptionKey)));

            return codeGenerator.Output();
        }

        private string ConvertWord(string word, List<char> alphabet, int caesarKey)
        {
            int arrayCorrectorFactor = 1;

            var convertedCharacters = word.Select(character =>
            {
                ExistsCharacter(alphabet, character);

                var characterPosition = alphabet.IndexOf(character);
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
                return Translate(alphabet, alphabetPosition);
            });

            return string.Join(string.Empty, convertedCharacters);
        }

        private static char Translate(List<char> alphabet, int alphabetPosition)
        {
            return alphabet[Math.Abs(alphabetPosition)];
        }

        private List<char> GenerateAlphabet()
        {
            return Enumerable.Range('A', 'Z' - 'A' + 1)
                                                 .Select(c => (char)c)
                                                 .ToList();
        }

        private static void ExistsCharacter(List<char> alphabet, char character)
        {
            if (alphabet.Contains(character)) return;

            throw new InvalidInputException($"Invalid input text");
        }
    }
}