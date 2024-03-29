using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = "lab5.txt";
            string textWrite = "lab5_2.txt";
            int rows = 10;

            string text = Encryption.ReadFromFile(textPath);

       
            Console.WriteLine("Исходный текст: \n" + text);
            Console.WriteLine("____________________________________________________________________");

            string encryptedText = Encryption.Encrypt(text, rows);
            Encryption.WriteToFile(textWrite, encryptedText);

            string encrText = Encryption.ReadFromFile(textWrite);

            string decrLetters = Encryption.GetLetters(text);
            string encrLetters = Encryption.GetLetters(encrText);

            Dictionary<char, int> encrFreq = Encryption.CountFrequancies(encrLetters);
            Dictionary<char, int> decrFreq = Encryption.CountFrequancies(decrLetters);


            Console.WriteLine("Текст зашифрован: \n" + encryptedText);

            Console.WriteLine("\nЧастота появления символов");

            var dictEncr = Encryption.GetDictionarySymb(encrFreq, encrLetters);
            Encryption.ShowDictionary(dictEncr);

            Console.WriteLine("____________________________________________________________________");


            string decryptedText = Encryption.Decrypt(encryptedText, rows);

            Console.WriteLine("Текст расшифрован: \n" + text);
            Console.WriteLine("\nЧастота появления символов");

            var dictDecr = Encryption.GetDictionarySymb(decrFreq, decrLetters);
            Encryption.ShowDictionary(dictDecr);

            Console.WriteLine("____________________________________________________________________");


            ///////////
            string key1 = "Golodok";
            string key2 = "Anastasia";

            string to_encr = "lab5_4.txt";
            string to_decr = "lab5_5.txt";



            var encryptedTable = EncrTransition.EncryptMultiple(key1, key2);

            EncrTransition.WriteToFile(encryptedTable, to_encr);
            Console.WriteLine("Текст зашифрован: \n" + Encryption.ReadFromFile(to_encr));

            Console.WriteLine("\nЧастота появления символов");
            string encrText2 = Encryption.ReadFromFile(to_encr);
            string encrLetters2 = Encryption.GetLetters(encrText2);
            Dictionary<char, int> encrFreq2 = Encryption.CountFrequancies(encrLetters2);

            var dictEncr2 = Encryption.GetDictionarySymb(encrFreq2, encrLetters2);
            Encryption.ShowDictionary(dictEncr2);

            Console.WriteLine("____________________________________________________________________");

            var decryptedTable = EncrTransition.DecryptMultiple(key1, key2, encryptedTable);
            EncrTransition.WriteToFile(decryptedTable, to_decr);

            Console.WriteLine("Текст расшифрован: \n" + Encryption.ReadFromFile(to_decr));

        }
    }
}
