using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public static class FileConverter
    {
        public static void ConvertToBase64(string inputFilePath, string outputFilePath)
        {
            byte[] fileBytes = File.ReadAllBytes(inputFilePath);
            string base64String = Convert.ToBase64String(fileBytes);
            File.WriteAllText(outputFilePath, base64String);
        }

        public static double CalculateEntropyHartley(Dictionary<char, int> frequencies)
        {
            return Math.Log2(frequencies.Count);
        }

        public static double CalculateReduancy(double entropyS, double entropyCH)
        {
            if (entropyS == 0)
            {
                throw new ArgumentException("Entropy should not be zero.");
            }

            double redundancy = ((entropyCH - entropyS) / entropyCH) * 100;

            return redundancy;
        }
        //

        public static byte[] ConvertAsciiToBytes(string text)
        {
            byte[] bytes = new byte[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                bytes[i] = (byte)text[i];
            }

            return bytes;
        }

        public static string EncodeToBase64(string text)
        {
            string base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

            byte[] bytes = ConvertAsciiToBytes(text);
            StringBuilder base64StringBuilder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i += 3)
            {
                int group = (bytes[i] << 16) | ((i + 1 < bytes.Length ? bytes[i + 1] : 0) << 8) | (i + 2 < bytes.Length ? bytes[i + 2] : 0);

                base64StringBuilder.Append(base64Chars[(group >> 18) & 0x3F]);
                base64StringBuilder.Append(base64Chars[(group >> 12) & 0x3F]);
                base64StringBuilder.Append((i + 1 < bytes.Length) ? base64Chars[(group >> 6) & 0x3F] : '=');
                base64StringBuilder.Append((i + 2 < bytes.Length) ? base64Chars[group & 0x3F] : '=');
            }

            return base64StringBuilder.ToString();
        }

        public static byte[] DecodeFromBase64(string base64Text)
        {
            string base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

            byte[] bytes = new byte[base64Text.Length * 3 / 4];

            for (int i = 0, j = 0; i < base64Text.Length;)
            {
                int sextet_a = base64Text[i] == '=' ? 0 & i++ : base64Chars.IndexOf(base64Text[i++]);
                int sextet_b = base64Text[i] == '=' ? 0 & i++ : base64Chars.IndexOf(base64Text[i++]);
                int sextet_c = base64Text[i] == '=' ? 0 & i++ : base64Chars.IndexOf(base64Text[i++]);
                int sextet_d = base64Text[i] == '=' ? 0 & i++ : base64Chars.IndexOf(base64Text[i++]);

                int triple = (sextet_a << 18) | (sextet_b << 12) | (sextet_c << 6) | (sextet_d);
                bytes[j++] = (byte)((triple >> 16) & 0xFF);
                if (i != base64Text.Length && base64Text[i] != '=') bytes[j++] = (byte)((triple >> 8) & 0xFF);
                if (i != base64Text.Length && base64Text[i] != '=') bytes[j++] = (byte)((triple) & 0xFF);
            }

            Array.Resize(ref bytes, bytes.Length - (base64Text.EndsWith("==") ? 2 : base64Text.EndsWith("=") ? 1 : 0));
            return bytes;
        }

        public static byte[] XorBuffers(byte[] a, byte[] b)
        {
            int length = Math.Min(a.Length, b.Length);
            byte[] result = new byte[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = (byte)(a[i] ^ b[i]);
            }

            return result;
        }

        public static string ToBinaryString(byte[] bytes)
        {
            StringBuilder binaryStringBuilder = new StringBuilder();

            foreach (byte b in bytes)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            return binaryStringBuilder.ToString();
        }

        public static void PerformXorOperationsAndDisplayResults(string nameAscii, string surnameAscii, string nameBase64, string surnameBase64)
        {
            string nameBase = EncodeToBase64(nameBase64);
            string surnameBase = EncodeToBase64(surnameBase64);
            
            int maxAsciiLength = Math.Max(nameAscii.Length, surnameAscii.Length);

            nameAscii = nameAscii.PadRight(maxAsciiLength, '\0');
            surnameAscii = surnameAscii.PadRight(maxAsciiLength, '\0');

            byte[] nameAsciiBytes = ConvertAsciiToBytes(nameAscii);
            byte[] surnameAsciiBytes = ConvertAsciiToBytes(surnameAscii);

            int maxBase64Length = Math.Max(nameBase.Length, surnameBase.Length);

            nameBase64 = nameBase.PadRight(maxBase64Length, '=');
            surnameBase64 = surnameBase.PadRight(maxBase64Length, '=');

            byte[] nameBase64Bytes = DecodeFromBase64(nameBase64);
            byte[] surnameBase64Bytes = DecodeFromBase64(surnameBase64);

            byte[] xorResultAscii = XorBuffers(nameAsciiBytes, surnameAsciiBytes);
            byte[] xorAscii = XorBuffers(xorResultAscii, surnameBase64Bytes);

            byte[] xorResultBase64 = XorBuffers(nameBase64Bytes, surnameBase64Bytes);
            byte[] xorBase = XorBuffers(xorResultBase64, surnameBase64Bytes);

            Console.WriteLine("Name (ASCII) in binary: " + ToBinaryString(nameAsciiBytes));
            Console.WriteLine("Surname (ASCII) in binary: " + ToBinaryString(surnameAsciiBytes));
            Console.WriteLine("Name XOR Surname (ASCII) in binary: " + ToBinaryString(xorResultAscii));
            Console.WriteLine("Name XOR Surname XOR Surname: " + ToBinaryString(xorAscii));
            Console.WriteLine("\nName (Base64) in binary: " + ToBinaryString(nameBase64Bytes));
            Console.WriteLine("Surname (Base64) in binary: " + ToBinaryString(surnameBase64Bytes));
            Console.WriteLine("Name XOR Surname (Base64) in binary: " + ToBinaryString(xorResultBase64));
            Console.WriteLine("Name XOR Surname XOR Surname: " + ToBinaryString(xorBase));
        }

        //Lab1
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

            foreach (var item in frequencies)
            {
                double probability = (double)item.Value / totalCharecters;
                entropy -= probability * Math.Log(probability, 2);
            }
            return entropy;
        }

        public static double GetInformation(double entropy, string sourceText)
        {
            return entropy * sourceText.Length;
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
            string path = "D:\\Univer\\6sem\\IS\\Lab02\\Lab02\\";
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
