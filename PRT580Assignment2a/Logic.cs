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

        /// <summary>
        /// Return 2 seperated lists containing all prime and composite numbers contained in the input list.
        /// </summary>
        public static (List<int> Primes, List<int> NonPrimes) SeperatePrimes(List<int> mixedNumbers)
        {
            return SplitPrimes(mixedNumbers);
        }

        /// <summary>
        /// Return all prime numbers in the imput list
        /// </summary>
        public static List<int> FindPrimes(List<int> mixedNumbers)
        {
            return SplitPrimes(mixedNumbers).Primes;
        }

        /// <summary>
        /// Return all composite numbers in the input list
        /// </summary>
        public static List<int> FindComposites(List<int> mixedNumbers)
        {
            return SplitPrimes(mixedNumbers).NonPrimes;
        }

        /// <summary>
        /// Return a lst containing all prime and then all comosite number in the input list in the order they were otherwise provided
        /// </summary>
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
            //1, 0, and all negative integers are composite.
            if (number <= 1) return false;
            //Exception for the only even prime number.
            if (number == 2) return true;

            //Upper bound is square root of number as,
            //For all n: all unique divisors of n are numbers less than or equal to √n, so we need not search past that.
            for (var i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
