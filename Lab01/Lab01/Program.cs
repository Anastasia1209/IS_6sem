using Lab01;
using System;

class Program
{
    static void Main(string[] args)
    {
        string rusText = Entropy.ReadFromFile("rus.txt");
        string rusLetters = Entropy.GetLetters(rusText);
        Dictionary<char, int> rusLettersFrequency = Entropy.CountFrequancies(rusLetters);
        Entropy.ShowDictionary(rusLettersFrequency);

        double rusEntropy = Entropy.CalculateEntropy(rusLetters);
        Console.WriteLine($"Энтропия русского алфавита(кирилица): {rusEntropy}");

        string engText = Entropy.ReadFromFile("eng.txt");
        string engLetters = Entropy.GetLetters(engText);
        double engEntropy = Entropy.CalculateEntropy(engLetters);
        Console.WriteLine($"Энтропия английского алфавита(латиница): {engEntropy}\n");

        string rusBinText = Entropy.ReadFromFile("rusBin.txt");
        string rusBinLetters = Entropy.GetLetters(rusBinText);
        double rusBinEntropy = Entropy.CalculateEntropy(rusBinLetters);
        Console.WriteLine($"Энтропия русского алфавита в бинарном представлении: {rusBinEntropy}");

        string engBinText = Entropy.ReadFromFile("engBin.txt");
        string engBinLetters = Entropy.GetLetters(engBinText);
        double engBinEntropy = Entropy.CalculateEntropy( engBinLetters);
        Console.WriteLine($"Энтропия английского алфавита в бинарном представлении: {engBinEntropy}\n");

        string rusFIO = Entropy.ReadFromFile("fio.txt");
        double infoNum = Entropy.GetInformation(rusEntropy, rusFIO);
        Console.WriteLine($"Количество информации в ФИО на русском: {infoNum}");

        string rusBinFIO = Entropy.ReadFromFile("fioBin.txt");
        double infoBinNum = Entropy.GetInformation(rusBinEntropy, rusBinFIO);
        Console.WriteLine($"Количество информации в ФИО в бинарном формате: {infoBinNum}\n");


        double effectiveEntropyWithProb = Entropy.CalculateEffectiveEntropy(0.1, rusBinEntropy, true);
        Console.WriteLine($"Количество информации при 0.1 вероятности ошибки в бинарном формате : {Entropy.GetInformation(effectiveEntropyWithProb, rusBinFIO)}");

        effectiveEntropyWithProb = Entropy.CalculateEffectiveEntropy(0.1,rusEntropy, false);
        Console.WriteLine($"Количество информации при 0.1 вероятности ошибки в формате русского алфавита: {Entropy.GetInformation(effectiveEntropyWithProb, rusFIO)}\n");

        effectiveEntropyWithProb = Entropy.CalculateEffectiveEntropy(0.5, rusBinEntropy, true);
        Console.WriteLine($"Количество информации при 0.5 вероятности ошибки в двоичном формате : {Entropy.GetInformation(effectiveEntropyWithProb, rusBinFIO)}");

        effectiveEntropyWithProb = Entropy.CalculateEffectiveEntropy(0.5, rusEntropy, false);
        Console.WriteLine($"Количество информации при 0.5 вероятности ошибки в формате русского алфавита: {Entropy.GetInformation(effectiveEntropyWithProb, rusFIO)}\n");

        effectiveEntropyWithProb = Entropy.CalculateEffectiveEntropy(1.0, rusBinEntropy, true);
        Console.WriteLine($"Количество информации при 1.0 вероятности ошибки в двоичном формате : {Entropy.GetInformation(effectiveEntropyWithProb, rusBinFIO)}");

        effectiveEntropyWithProb = Entropy.CalculateEffectiveEntropy(1.0, rusEntropy, false);
        Console.WriteLine($"Количество информации при 1.0 вероятности ошибки в формате русского алфавита: {Entropy.GetInformation(effectiveEntropyWithProb, rusFIO)}\n");

        Dictionary<char, int> engLettersFrequency = Entropy.CountFrequancies(engLetters);


        var dict = Entropy.GetDictionarySymb(engLettersFrequency, engLetters);
        Entropy.ShowDictionary(dict);


    }
}