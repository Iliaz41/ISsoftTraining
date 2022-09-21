using System;

namespace task4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber rationalNumber = new RationalNumber(2, 4);
            RationalNumber rationalNumber2 = new RationalNumber(5, 6);

            Console.WriteLine(rationalNumber.ToString() + "+" + rationalNumber2.ToString() + "=" + (rationalNumber + rationalNumber2).ToString());
            Console.WriteLine(rationalNumber.ToString() + "-" + rationalNumber2.ToString() + "=" + (rationalNumber - rationalNumber2).ToString());
            Console.WriteLine(rationalNumber.ToString() + "*" + rationalNumber2.ToString() + "=" + (rationalNumber * rationalNumber2).ToString());
            Console.WriteLine(rationalNumber.ToString() + "/" + rationalNumber2.ToString() + "=" + (rationalNumber / rationalNumber2).ToString());

            Console.WriteLine(RationalNumber.ToDouble(rationalNumber));
            Console.WriteLine(RationalNumber.ToRational(5));

            Console.WriteLine(rationalNumber.Equals(rationalNumber2) + " " + rationalNumber.CompareTo(rationalNumber2));
            Console.WriteLine(rationalNumber.Equals(rationalNumber) + " " + rationalNumber.CompareTo(rationalNumber));
        }
    }
}
