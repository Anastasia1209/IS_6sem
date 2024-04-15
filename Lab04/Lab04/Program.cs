using System;
using System.Drawing;
using Lab04;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            string keywordSurname = "Golodok";
            string textPath = "lab4.txt";
            string textPath2 = "lab4_3.txt";
            string textWrite = "lab4_2.txt";
            string textWrite2 = "lab4_4.txt";

            string text = Encryption.ReadFromFile(textPath);
            string encrText = Encryption.ReadFromFile(textWrite);

            string text2 = Encryption.ReadFromFile(textPath2);
            string encrText2 = Encryption.ReadFromFile(textWrite2);



            string encrLetters = Encryption.GetLetters(encrText);
            string decrLetters = Encryption.GetLetters(text);
            Dictionary<char, int> encrFreq = Encryption.CountFrequancies(encrLetters);
            Dictionary<char, int> decrFreq = Encryption.CountFrequancies(decrLetters);

            string encrLetters2 = Encryption.GetLetters(encrText2);
            Dictionary<char, int> encrFreq2 = Encryption.CountFrequancies(encrLetters2);




            Console.WriteLine("Исходный текст: \n" + text);
            Console.WriteLine("____________________________________________________________________");
                      
            string encrCaesarText = Encryption.EncryptCaesar(text, keywordSurname);
            Console.WriteLine("\nЗашифрованный текст: \n" + encrCaesarText);
            Encryption.WriteToFile(textWrite, encrCaesarText);
            Console.WriteLine("\nЧастота появления символов");

            var dictEncr = Encryption.GetDictionarySymb(encrFreq, encrLetters);
            Encryption.ShowDictionary(dictEncr);

            Console.WriteLine("____________________________________________________________________");


            string decrCaesarText = Encryption.DecryptCaesar(encrCaesarText, keywordSurname);
            Console.WriteLine("\nРасшифрованный текст: \n" + decrCaesarText);

            Console.WriteLine("\nЧастота появления символов");

            var dictDecr = Encryption.GetDictionarySymb(decrFreq, decrLetters);
            Encryption.ShowDictionary(dictDecr);

            Console.WriteLine("____________________________________________________________________");

            string encrTrisText = Encryption.EncryptTrithemius(text2);
            Console.WriteLine("\nЗашифрованный текст: \n" + encrTrisText);
            Encryption.WriteToFile(textWrite2, encrTrisText);
            Console.WriteLine("\nЧастота появления символов");

            var dictEncr2 = Encryption.GetDictionarySymb(encrFreq2, encrLetters2);
            Encryption.ShowDictionary(dictEncr2);

            Console.WriteLine("____________________________________________________________________");

            string decrTrisText = new string(Encryption.DecryptTrithemius(encrTrisText));
            Console.WriteLine("\nРасшифрованный текст: \n" + text);

        }
    }
}