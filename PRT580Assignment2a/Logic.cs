using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PRT580Assignment2a
{
    public class Logic
    {
        public Logic() { }

        public static (List<int> Primes, List<int> NonPrimes) SeperatePrimes(List<int> mixedNumbers)
        {
            return SplitPrimes(mixedNumbers);
        }

        public static List<int> FindPrimes(List<int> mixedNumbers)
        {
            return SplitPrimes(mixedNumbers).Primes;
        }

        public static List<int> FindComposites(List<int> mixedNumbers)
        {
            return SplitPrimes(mixedNumbers).NonPrimes;
        }

        public static List<int> Partition_P_NP(List<int> A)
        {
            var splitLists = SplitPrimes(A);
            var response = new List<int>();
            response.AddRange(splitLists.Primes);
            response.AddRange(splitLists.NonPrimes);
            return response;
        }

        private static (List<int> Primes, List<int> NonPrimes) SplitPrimes(List<int> mixedNumbers)
        {
            var primes = new List<int>();
            var nonPrimes = new List<int>();

            foreach(var number in mixedNumbers)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
                else
                {
                    nonPrimes.Add(number);
                }
            }

            return (Primes: primes, NonPrimes: nonPrimes);
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;

            for (var i = 2; i <= number; i++)
            {
                if (number % i == 0)
                {
                    return number == i;
                }
            }

            throw new Exception("Number was not divisable by itself somehow.");
        }
    }
}
