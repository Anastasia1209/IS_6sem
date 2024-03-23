using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class Entropy
    {
        public static Dictionary<char, int> CountFrequancies(string fileName)
        {
            var frequancies = new Dictionary<char, int>();

            foreach (var item in fileName)
            {
                if (frequancies.ContainsKey(item))
                {
                    frequancies[item] += 1;
                }
                else
                {
                    frequancies.Add(item, 1);
                }
            }
            return frequancies;
        }

        public static double CalculateEntropy(string fileName)
        {
            Dictionary<char, int> frequencies = CountFrequancies(fileName);
            int totalCharecters = frequencies.Sum(item => item.Value);
            double entropy = 0;

            foreach(var item in frequencies)
            {
                double probability = (double)item.Value / totalCharecters; 
                entropy -= probability * Math.Log(probability, 2);
            }
            return entropy;
        }

        public static double GetInformation(double entropy, string fileName)
        {
            return entropy * fileName.Length;
        }
         
        public static double CalculateEffectiveEntropy(double p, double entropy, bool isBinary)
        {
            var q = 1 - p;
            double result;

            if (isBinary && (p == 1 || p == 0))
                return 1;
            if (isBinary)
                entropy = 1;
            if (!isBinary && p == 1)
                return 0;

            result = (-p * Math.Log2(p)) - q * Math.Log2(q);

            return entropy - result;
        }

        public static string ReadFromFile(string fileName)
        {
            string path = "D:\\Univer\\6sem\\IS\\Lab01\\Lab01";
            string filePath = Path.Combine(path, fileName);

            var reader = new StreamReader(filePath);
            string text = reader.ReadToEnd().ToLower();

            return text;
        }

        public static string GetLetters(string text)
        {
            var nonLet = new HashSet<char>() { ',', '.', '/', '?', '!', '=', '+', '-', '\'', '\"', '(', ')', ':', ';', '\n', '\0', '/', '\t', ' ', '«', '»', '—', '\r', '’', '☻', '–' };

            StringBuilder newText = new StringBuilder();

            foreach (char c in text)
            {
                if (!nonLet.Contains(c))
                {
                    newText.Append(c);
                }
            }

            return newText.ToString();
        }

        public static void ShowDictionary(Dictionary<char, int> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}, {item.Value} | ");
            }
        }

        public static void ShowDictionary(Dictionary<char, double> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}, {item.Value} | ");
            }
        }

        public static Dictionary<char, double> GetDictionarySymb(Dictionary<char, int> dict, string sourceText)
        {
            var dictionaryProb = new Dictionary<char, double>();

            foreach (var item in dict)
            {
                dictionaryProb.Add(item.Key, (double)item.Value / (double)sourceText.Length);
            }
            return dictionaryProb;
        }
    }
}
