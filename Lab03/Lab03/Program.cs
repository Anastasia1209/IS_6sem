using Lab03;
using System;

class Program
{
    static void Main(string[] args)
    {
        int num1 = 49;
        int num2 = 70;
        int gcdTwo = Calculations.CalculateGCD(num1, num2);
        Console.WriteLine($"НОД чисел {num1} и {num2} равен {gcdTwo}");

        int num3 = 84;
        int gcdThree = Calculations.CalculateGCD(num1, num2, num3);
        Console.WriteLine($"НОД чисел {num1}, {num2} и {num3} равен {gcdThree}");
        //////////////

        Console.Write("Введите верхнюю границу для поиска простых чисел: ");
        int a = int.Parse(Console.ReadLine());
        int b = 2;
        var (primes, count) = Calculations.FindPrimes(a, b);
        Console.WriteLine($"Количество простых чисел: {count}");
        Console.WriteLine($"Простые числа до {a}: {string.Join(", ", primes)}");
        ///////////////

        double expCount = a / Math.Log(a);
        Console.WriteLine($"Ожидаемое количество простых чисел: {expCount}");
        /////////////

        Console.WriteLine("------------------------------------");

        int n = 401, m = 367;
        var (primesn, countn) = Calculations.FindPrimes(n, m);
        Console.WriteLine($"Количество простых чисел от 367 до 401: {countn}");
        Console.WriteLine($"Простые числа до {n}: {string.Join(", ", primesn)}");
        ///////////////

        double expCountn = n / Math.Log(n) - m / Math.Log(m);
        Console.WriteLine($"Ожидаемое количество простых чисел: {expCountn}");

        string numCanon = Calculations.CanonForm(num1);
        string mCanon = Calculations.CanonForm(m);
        string nCanon = Calculations.CanonForm(n);
        Console.WriteLine($"Каноническая форма записи числа m: {numCanon}");
        Console.WriteLine($"Каноническая форма записи числа m: {mCanon}");
        Console.WriteLine($"Каноническая форма записи числа n: {nCanon}");
        /////////////
        
        if (Calculations.IsConcatenatedNumberPrime(m, n))
        {
            Console.WriteLine($"Число, состоящее из конкатенации цифр {m} и {n}, является простым.");
        }
        else
        {
            Console.WriteLine($"Число, состоящее из конкатенации цифр {m} и {n}, не является простым.");
        }
        ////////////
        int gcd = Calculations.CalculateGCD(n, m);
        Console.WriteLine($"НОД чисел {n} и {m} равен {gcd}");

    }
}
