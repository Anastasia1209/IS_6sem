using System;
using System.IO;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {

            string key = "golodoka";
            Console.WriteLine("Ключ: " + key);


            string fileName = "D:\\Univer\\6sem\\IS\\Lab07\\lab7.txt";
            string fileName2 = "lab7_2.txt";

            byte[] data = File.ReadAllBytes(fileName);

            string encryptedText = Encryption.EncryptFile(key, data);
            Console.WriteLine("Зашифрованный текст: \n" + encryptedText);

            Encryption.WriteToFile(fileName2, encryptedText);

            string decryptedText = Encryption.DecryptFile(key, Convert.FromBase64String(encryptedText));
            
            Console.WriteLine("Расшифрованный текст: \n" + decryptedText);

            

        }
    }
}