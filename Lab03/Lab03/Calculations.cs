using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    public class Calculations
    {
        public static int CalculateGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static int CalculateGCD(int a, int b, int c)
        {
            return CalculateGCD(a, CalculateGCD(b, c));
        }

        public static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num <= 3) return true;
            if (num % 2 == 0 || num % 3 == 0) return false;
            for (int i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                    return false;
            }
            return true;
        }

        public static (List<int>, int) FindPrimes(int n, int m)
        {
            List<int> primes = new List<int>();
            int count = 0;
            for (int i = m; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                    count++;
                }
            }
            return (primes, count);
        }

        public static List<int> PrimeFactors(int num)
        {
            List<int> factors = new List<int>();
            int divisor = 2;
            while (num > 1)
            {
                while (num % divisor == 0)
                {
                    factors.Add(divisor);
                    num /= divisor;
                }
                divisor++;
            }
            return factors;
        }

        public static string CanonForm(int num)
        {
            List<int> factors = PrimeFactors(num);
            return $"{num} = {string.Join(" * ", factors)}";
        }

        public static bool IsConcatenatedNumberPrime(int m, int n)
        {
            int mLength = m.ToString().Length;
            int nLength = n.ToString().Length;

            int concatenatedNumber = m * (int)Math.Pow(10, nLength) + n;

            return IsPrime(concatenatedNumber);
        }

    }
}
