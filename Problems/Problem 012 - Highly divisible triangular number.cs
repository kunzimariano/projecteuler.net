﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Problems
{
    //The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

    //1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

    //Let us list the factors of the first seven triangle numbers:

    //     1: 1
    //     3: 1,3
    //     6: 1,2,3,6
    //    10: 1,2,5,10
    //    15: 1,3,5,15
    //    21: 1,3,7,21
    //    28: 1,2,4,7,14,28

    //We can see that 28 is the first triangle number to have over five divisors.

    //What is the value of the first triangle number to have over five hundred divisors?

    public class Problem12
    {
        readonly List<int> _firstNPrimes = Helpers.Math.GetFirstNPrimes(500);

        public void First()
        {
            long triangle = 1;
            for (int i = 1; true; i++)
            {
                triangle = GetNextTriangle(triangle, i);
                int factors = CountFactors(triangle);
                if (500 < factors)
                    break;
            }
            System.Diagnostics.Debug.Print("Triangle {0}", triangle);
        }

        private long GetNextTriangle(long previousTriangle, long previousNatural)
        {
            return previousTriangle + previousNatural + 1;
        }

        private int CountFactors(long n)
        {
            var primeFactorsCount = new Dictionary<int, int>();

            int count = 1;

            foreach (int prime in _firstNPrimes)
            {
                if (n == 1) break;

                int divisionTimes = CountDivisionTimes(n, prime);
                if (0 < divisionTimes)
                {
                    primeFactorsCount.Add(prime, divisionTimes);
                    var foo = (int)Math.Pow(prime, divisionTimes);
                    n = n / foo;
                }
            }

            foreach (KeyValuePair<int, int> valuePair in primeFactorsCount)
            {
                count *= (valuePair.Value + 1);
            }

            return count;
        }

        private int CountDivisionTimes(long n, long divisor)
        {
            int result = 0;

            while (Helpers.Math.IsFactor(n, divisor))
            {
                result++;
                n = n / divisor;
            }

            return result;
        }



    }


}
