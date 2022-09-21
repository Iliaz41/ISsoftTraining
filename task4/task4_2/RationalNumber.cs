using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_2
{
    public sealed class RationalNumber : IComparable
    {
        private int _n;
        private int _m;

        public int N
        {
            get => _n;
        }

        public int M
        {
            get => _m;
        }

        public RationalNumber(int n, int m)
        {
            if (m <= 0 || m % 1 != 0 || n % 1 != 0 || m == 0)
            {
                throw new ArgumentException();
            }
            _n = n;
            _m = m;
            Reduction();
        }

        private void Reduction()
        {
            int nod = NOD(_n, _m);
            _n /= nod;
            _m /= nod;
        }

        public override string ToString()
        {
            return _n + "/" + _m;
        }

        public override bool Equals(object obj)
        {
            return obj is RationalNumber number &&
                   _n == number._n &&
                   _m == number._m;
        }

        public override int GetHashCode()
        {
            return (_n * _m).GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (this < (obj as RationalNumber))
            {
                return -1;
            }
            else if (this > (obj as RationalNumber))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int NOK(int a, int b)
        {
            return a * b / NOD(a, b);
        }

        public static int NOD(int a, int b)
        {
            int remainder;

            a = (int)Math.Abs(a);
            b = (int)Math.Abs(b);
            if (b > a)
            {
                remainder = a;
                a = b;
                b = remainder;
            }

            do
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }
            while (remainder != 0);
            return a;
        }

        public static bool operator >(RationalNumber first, RationalNumber second)
        {
            if (first._n * NOK(first._m, second._m) / first._m
               > second._n * NOK(first._m, second._m) / second._m)
                return true;
            else return false;
        }

        public static bool operator <(RationalNumber first, RationalNumber second)
        {
            if (first._n * NOK(first._m, second._m) / first._m
               < second._n * NOK(first._m, second._m) / second._m)
                return true;
            else return false;
        }

        public static RationalNumber operator +(RationalNumber first, RationalNumber second)
        {
            var n = first._n * second._m + first._m * second._n;
            var m = first._m * second._m;
            RationalNumber rationalNumber = new RationalNumber(n, m);
            rationalNumber.Reduction();
            return rationalNumber;
        }

        public static RationalNumber operator -(RationalNumber first, RationalNumber second)
        {
            var n = first._n * second._m - first._m * second._n;
            var m = first._m * second._m;
            RationalNumber rationalNumber = new RationalNumber(n, m);
            rationalNumber.Reduction();
            return rationalNumber;
        }

        public static RationalNumber operator *(RationalNumber first, RationalNumber second)
        {
            var n = first._n * second._n;
            var m = first._m * second._m;
            RationalNumber rationalNumber = new RationalNumber(n, m);
            rationalNumber.Reduction();
            return rationalNumber;
        }

        public static RationalNumber operator /(RationalNumber first, RationalNumber second)
        {
            var n = first._n * second._m;
            var m = first._m * second._n;
            RationalNumber rationalNumber = new RationalNumber(n, m);
            rationalNumber.Reduction();
            return rationalNumber;
        }

        public static double ToDouble(RationalNumber rationalNumber)
        {
            return (double)(rationalNumber._n / rationalNumber._m);
        }

        public static RationalNumber ToRational(int number)
        {
            return new RationalNumber(number, 1);
        }
    }
}
