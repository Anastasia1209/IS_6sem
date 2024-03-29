using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class Encryption
    {
        public static string ReadFromFile(string fileName)
        {
            string path = "D:\\Univer\\6sem\\IS\\Lab05\\";
            string filePath = Path.Combine(path, fileName);

            var reader = new StreamReader(filePath);
            string text = reader.ReadToEnd().ToLower();

            return text;
        }

        public static string WriteToFile(string fileName, string text)
        {
            string path = "D:\\Univer\\6sem\\IS\\Lab05\\";
            string filePath = Path.Combine(path, fileName);
            File.WriteAllText(filePath, text);
            return filePath;
        }


        //////////////////////////////////////////////////////////////// 

        public static string Encrypt(string text, int rows)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            char[,] encryptedText = new char[rows, text.Length];
            int direction = -1;
            int row = 0;
            int col = 0;

            foreach (char c in text)
            {
                encryptedText[row, col] = c;
                col++;

                if (col == text.Length)
                {
                    row++;
                    col = 0;
                }

                if (row == 0 || row == rows - 1)
                    direction *= -1;

                row += direction;
            }

            stopWatch.Stop();
            Console.WriteLine($"\nВремя выполнения операции: {stopWatch.Elapsed}");

            string result = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    result += encryptedText[i, j];
                }
            }

            return result;
        }


        public static string Decrypt(string text, int rows)
        {
            if (string.IsNullOrEmpty(text))
                return ""; 

            int textLength = text.Length;
            char[,] decryptedText = new char[rows, textLength];
            int direction = -1;
            int row = 0;
            int col = 0;

            foreach (char c in text)
            {
                decryptedText[row, col] = ' ';
                col++;

                if (col == textLength)
                {
                    row++;
                    col = 0;
                }

                if (row == 0 || row == rows - 1)
                    direction *= -1;

                row += direction;
            }

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < textLength; j++)
                {
                    if (decryptedText[i, j] == ' ')
                        decryptedText[i, j] = text[index++];
                }
            }

            StringBuilder decryptedBuilder = new StringBuilder();
            row = 0;
            col = 0;
            direction = -1;
            for (int i = 0; i < textLength; i++)
            {
                decryptedBuilder.Append(decryptedText[row, col]);
                col++;

                if (col == textLength)
                {
                    row++;
                    col = 0;
                }

                if (row == 0 || row == rows - 1)
                    direction *= -1;

                row += direction;
            }

            return decryptedBuilder.ToString();
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
/*
        public static string Encrypt(string text, int rows)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            string[] encryptedText = new string[rows];
            int direction = -1; // Начинаем движение вверх
            int row = 0;

            foreach (char c in text)
            {
                encryptedText[row] += c;
                if (row == 0 || row == rows - 1)
                    direction *= -1; // Меняем направление движения
                row += direction;
            }

            stopWatch.Stop();
            Console.WriteLine($"\nВремя выполнения операции: {stopWatch.Elapsed}");

            return string.Concat(encryptedText);
        }


        public static string Decrypt(string text, int rows)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int textLength = text.Length;
            char[,] decryptedText = new char[rows, textLength]; // Определяем размер массива на основе длины текста
            int direction = -1;
            int row = 0;
            int index = 0;

            foreach (char c in text)
            {
                decryptedText[row, index++] = c;
                if (row == 0 || row == rows - 1)
                    direction *= -1;

                if (row == 0)
                    index++;
                else if (row == rows - 1)
                    index--;

                row += direction;

                           }

            // Создаем строку на основе расшифрованного текста с учетом размера массива
            string result = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < textLength; j++)
                {
                    if (decryptedText[i, j] != '\0')
                        result += decryptedText[i, j];
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"\nВремя выполнения операции: {stopWatch.Elapsed}");
            return result;
        }*/