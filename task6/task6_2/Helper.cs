using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task6
{
    public static class Helper
    {
        public static List<BigInteger> Factorization(BigInteger n)
        {
            if (n < 2)
            {
                throw new ArgumentException();
            }
            List<BigInteger> resultList = new List<BigInteger>();
            BigInteger div = 2;
            while (n > 1)
            {
                if (n % div == 0)
                {
                    resultList.Add(div);
                    n /= div;
                }
                else
                {
                    div++;
                }
            }
            return resultList;
        }

        public static async Task<List<BigInteger>> FactorizationAsync(BigInteger n)
        {
            return await Task.Run(() => Factorization(n));
        }

        public static async Task<BigInteger> GcdAsync(BigInteger a, BigInteger b)
        {
            var listA = FactorizationAsync(a).Result;
            var listB = FactorizationAsync(b).Result;
            BigInteger gcd = 1;
            BigInteger minElement = a < b ? a : b;
            int div = 2;
            while (div < minElement)
            {
                int min = Math.Min(listA.Count(x => x.Equals(div)), listB.Count(x => x.Equals(div)));
                if (min != 0)
                {
                    gcd *= Convert.ToInt64(Math.Pow(div, min));
                }
                div++;
            }
            return await Task.FromResult(gcd);
        }
    }
}
