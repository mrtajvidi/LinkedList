using System;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LinkedList.Logic
{
    public class DocumentProcessor : IDocumentProcessor
    {
        /// <summary>
        /// Analyzes the document and returns statistics.
        /// </summary>
        /// <exception cref="ArgumentNullException">document is null</exception>
        public Stats Analyze(string document)
        {
            if (document == null)
                throw new ArgumentNullException();




            if (document.Length == 0)
            {
                return new Stats()
                {
                    NumberOfWordsThatContainOnlyDigits = 0,
                    NumberOfAllWords = 0,
                    NumberOfWordsStartingWithCapitalLetter = 0,
                    NumberOfWordsStartingWithSmallLetter = 0
                };
            }
            var words = document.Trim().Split(' ');
            var stats = new Stats();

            stats.NumberOfAllWords = words.Length;
            ///var onlyNumbers = @"^-?[0-9][0-9,\.]+$";
            var onlyNumbers = @"^\d+$";

            foreach (var word in words)
            {
                if (Regex.Match(word, onlyNumbers, RegexOptions.IgnoreCase).Success)
                {
                    stats.NumberOfWordsThatContainOnlyDigits++;
                }

                if (char.IsUpper(word[0]))
                {
                    stats.NumberOfWordsStartingWithCapitalLetter++;
                }

                else if (char.IsUpper(word[0]))
                {
                    stats.NumberOfWordsStartingWithCapitalLetter++;
                }

                else if (char.IsLower(word[0]))
                {
                    stats.NumberOfWordsStartingWithSmallLetter++;
                }
            }

            stats.TheLongestWord = words.OrderByDescending(s => s.Length).First();
            stats.TheShortestWord = words.OrderBy(s => s.Length).First();

            return stats;
        }

        private void Abbas()
        {
            throw new ArgumentNullException();
        }
    }
}