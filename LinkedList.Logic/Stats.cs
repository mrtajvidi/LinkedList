using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Logic
{
    public class Stats
    {
        // Total number of words in the document
        public int NumberOfAllWords { get; set; }

        // Returns number of words that contain only digits, e.g. 13455, 98374
        public int NumberOfWordsThatContainOnlyDigits { get; set; }

        // Returns number of words that start with a lowercase letter, e.g. a, d, z
        public int NumberOfWordsStartingWithSmallLetter { get; set; }

        // Returns number of words that start with a capital letter, e.g. A, D, Z
        public int NumberOfWordsStartingWithCapitalLetter { get; set; }

        // Returns the longest word in the document
        public string TheLongestWord { get; set; }

        // Returns the shortest word in the document
        public string TheShortestWord { get; set; }

    }
}
