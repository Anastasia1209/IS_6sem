using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    public class Encryption
    {
        public static string ReadFromFile(string fileName)
        {
            string path = "D:\\Univer\\6sem\\IS\\Lab04\\";
            string filePath = Path.Combine(path, fileName);

            var reader = new StreamReader(filePath);
            string text = reader.ReadToEnd().ToLower();

            return text;
        }

        public static string WriteToFile(string fileName, string text)
        {
            string path = "D:\\Univer\\6sem\\IS\\Lab04\\";
            string filePath = Path.Combine(path, fileName);
            File.WriteAllText(filePath, text);
            return filePath;
        }

        //////////////
        public static string EncryptCaesar(string text, string keyword)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            string result = "";
            int keywordIndex = 0;

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    char offset = char.IsUpper(symbol) ? 'A' : 'a';
                    int shift = keyword[keywordIndex % keyword.Length] - offset;

                    char encryptedSymbol = (char)((symbol + shift - offset + 26) % 26 + offset);
                    result += encryptedSymbol;

                    keywordIndex++;
                }
                else
                {
                    result += symbol;
                }
            }
            stopWatch.Stop();
            Console.WriteLine($"\nВремя выполнения операции: {stopWatch.Elapsed}");


            return result;
        }

        public static string DecryptCaesar(string text, string keyword)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            string result = "";
            int keywordIndex = 0;

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    char offset = char.IsUpper(symbol) ? 'A' : 'a';
                    int shift = keyword[keywordIndex % keyword.Length] - offset;

                    char decryptedSymbol = (char)((symbol - shift - offset + 26) % 26 + offset);
                    result += decryptedSymbol;

                    keywordIndex++;
                }
                else
                {
                    result += symbol;
                }
            }
            stopWatch.Stop();
            Console.WriteLine($"\nВремя выполнения операции: {stopWatch.Elapsed}");


            return result;
        }
        /// //////////////////////////////////////////////////////////////

        public static char[,] GenerateTable(string keyword)
        {
            const int rows = 4;
            const int columns = 8;
            char[,] table = new char[rows, columns];
            var index = 0;

            keyword = keyword.ToLower();

            foreach (var c in keyword.Distinct())
            {
                table[index / columns, index % columns] = c;
                index++;
            }

            for (char c = 'a'; c <= 'z'; c++)
            {
                if (index >= rows * columns)
                    break;
                if (!keyword.Contains(c))
                {
                    table[index / columns, index % columns] = c;
                    index++;
                }
            }

            return table;
        }


        public static string EncryptTrithemius(string text)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            const int rows = 4;
            const int columns = 8;
            char[,] table = GenerateTable("Anastasiya"); 

            StringBuilder encryptedText = new StringBuilder();

            foreach (char symbol in text.ToLower()) 
            {
                if (char.IsLetter(symbol))
                {
                    int row = -1, column = -1;

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (table[i, j] == symbol)
                            {
                                row = i;
                                column = j;
                                break;
                            }
                        }
                        if (row != -1) 
                            break;
                    }

                    if (row != -1 && column != -1)
                    {
                        char encryptedSymbol = table[(row + 1) % rows, column];
                        encryptedText.Append(encryptedSymbol);
                    }
                    else
                    {
                        encryptedText.Append(symbol);
                    }
                }
                else
                {
                    encryptedText.Append(symbol);
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"\nВремя выполнения операции: {stopWatch.Elapsed}");

            return encryptedText.ToString();
        }



        public static string DecryptTrithemius(string fileName)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            const int rows = 4;
            const int columns = 8;
            char[,] table = GenerateTable("Anastasiya"); 

            StringBuilder decryptedText = new StringBuilder();

            foreach (char symbol in fileName.ToLower()) 
            {
                if (char.IsLetter(symbol))
                {
                    int row = -1, column = -1;

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (table[i, j] == symbol)
                            {
                                row = i;
                                column = j;
                                break;
                            }
                        }
                        if (row != -1) 
                            break;
                    }

                    if (row != -1 && column != -1)
                    {
                        char decryptedSymbol = table[(row - 1 + rows) % rows, column];
                        decryptedText.Append(decryptedSymbol);
                    }
                    else
                    {
                        decryptedText.Append(symbol);
                    }
                }
                else
                {
                    decryptedText.Append(symbol);
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"\nВремя выполнения операции: {stopWatch.Elapsed}");

            return decryptedText.ToString();
        }



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
