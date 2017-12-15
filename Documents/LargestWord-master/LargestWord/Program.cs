using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LongestWordFromWords
{
    internal class Program
    {
        public static string FindLongestWords(string[] listOfWords)
        {
            if (listOfWords == null) throw new ArgumentException("listOfWords");
            var sortedWords = listOfWords.OrderByDescending(word => word.Length).ToList();
            var dict = new HashSet<String>(sortedWords);
            foreach (var word in sortedWords)
            {
                if (isMadeOfWords(word, dict))
                {
                    return word;
                }
            }
            return null;
        }

        private static bool isMadeOfWords(string word, HashSet<string> dict)
        {
            if (String.IsNullOrEmpty(word)) return false;
            if (word.Length == 1)
            {
                if (dict.Contains(word)) return true;
                else return false;
            }
            foreach (var pair in generatePairs(word))
            {
                if (dict.Contains(pair.Item1))
                {
                    if (dict.Contains(pair.Item2))
                    {
                        return true;
                    }
                    else
                    {
                        return isMadeOfWords(pair.Item2, dict);
                    }
                }
            }
            return false;
        }



        private static List<Tuple<string, string>> generatePairs(string word)
        {
            var output = new List<Tuple<string, string>>();
            for (int i = 1; i < word.Length; i++)
            {
                output.Add(Tuple.Create(word.Substring(0, i), word.Substring(i)));
            }
            return output;
        }

        private static string[] ReadWordFile()
        {
            List<string> words = new List<string>();
            System.IO.StreamReader file = new System.IO.StreamReader("Wordlist.txt");
            string line = string.Empty;
            var ReadAllLines = System.IO.File.ReadAllLines("Wordlist.txt");

            for (int i = 0; i <= ReadAllLines.Length - 1; i++)
            {
                if (!String.IsNullOrEmpty(ReadAllLines[i]))
                {
                    words.Add(ReadAllLines[i]);
                }
            }
               
            return words.ToArray();
        }

        private static int isMadeOfWordsCount(string word, HashSet<string> dict)
        {
            int count = 0;
            foreach (var pair in generatePairs(word))
            {
                if (dict.Contains(pair.Item1))
                {
                    if (dict.Contains(pair.Item2))
                    {
                         count++;
                    }
                    else
                    {
                        isMadeOfWords(pair.Item2, dict);
                    }
                }
            }
            return count;
        }

        private static void Main(string[] args)
        {

            string[] wordsArray = ReadWordFile();
            Console.WriteLine(wordsArray.Length);
            string LongestWord = FindLongestWords(wordsArray);
            Console.WriteLine("Longest word Concatenated by short words is:{0}", LongestWord);

            string[] secondLargestWord = wordsArray.Where(x => x != LongestWord).ToArray();
            Console.WriteLine("Second Longest word Concatenated by short words is:{0}", FindLongestWords(secondLargestWord));

            var sortedWords = wordsArray.OrderByDescending(word => word.Length).ToList();
            var dict = new HashSet<String>(sortedWords);
            int NumberOfWords = 0;
            foreach(var word in sortedWords)
            {
                NumberOfWords += isMadeOfWordsCount(word, dict);
            }
            Console.WriteLine("Total count of how many of the words in the list can be constructed with other:{0}", NumberOfWords);
            Console.ReadLine();
        }
    }
}