using Lab02;
using System;
using System.Drawing;


namespace Lab02 { 
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName = "D:\\Univer\\6sem\\IS\\Lab02\\Lab02\\eng.txt";
            string outputFilePath = "D:\\Univer\\6sem\\IS\\Lab02\\Lab02\\fileB.txt"; 

            FileConverter.ConvertToBase64(fileName, outputFilePath);

            Console.WriteLine("Файл успешно сконвертирован в формат base64 и сохранен.");

            string textA = FileConverter.ReadFromFile(fileName);
            string textB = FileConverter.ReadFromFile(outputFilePath);

            string lettersA = FileConverter.GetLetters(textA);
            string lettersB = FileConverter.GetLetters(textB);


            Dictionary<char, int> frequenciesA = FileConverter.CountFrequancies(lettersA);
            Dictionary<char, int> frequenciesB = FileConverter.CountFrequancies(lettersB);

            double entropyHartleyA = FileConverter.CalculateEntropyHartley(frequenciesA);
            double entropyHartleyB = FileConverter.CalculateEntropyHartley(frequenciesB);

            double entropyShannonA = FileConverter.CalculateEntropy(lettersA);
            double entropyShannonB = FileConverter.CalculateEntropy(lettersB);

            double redundancyA = FileConverter.CalculateReduancy(entropyShannonA, entropyHartleyA);
            double redundancyB = FileConverter.CalculateReduancy(entropyShannonB, entropyHartleyB);


            Console.WriteLine("Для документа (а):");
            //FileConverter.ShowDictionary(frequenciesA);
            Console.WriteLine($"Энтропия Хартли: {entropyHartleyA}");
            Console.WriteLine($"Энтропия Шеннона: {entropyShannonA}");
            Console.WriteLine($"Избыточность: {redundancyA}");

            Console.WriteLine("\nДля документа (б):");
            //FileConverter.ShowDictionary(frequenciesB);
            Console.WriteLine($"Энтропия Хартли: {entropyHartleyB}");
            Console.WriteLine($"Энтропия Шеннона: {entropyShannonB}");
            Console.WriteLine($"Избыточность: {redundancyB}");


            string name = "Anastasiya";
            string surname = "Golodok";

            string nameBase64 = FileConverter.EncodeToBase64(name);
            string surnameBase64 = FileConverter.EncodeToBase64(surname);

            // Вызов функции для выполнения операций XOR и вывода результатов
            FileConverter.PerformXorOperationsAndDisplayResults(name, surname, nameBase64, surnameBase64);

        }
    }
}