using System;

namespace task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string firststr;
            for (; ; )
            {
                Console.WriteLine("Enter a string consisting of 9 symbols");
                firststr = Console.ReadLine();
                if (firststr.Length == 9)
                {
                    break;
                }
            }
            int[] code = new int[firststr.Length];
            for (int i = 0; i < firststr.Length; i++)
            {
                code[i] = int.Parse(firststr.Substring(i, 1));
            }
            int remains;
            string ch;
            for (int i = 0; i < 11; i++)
            {
                int numb = 0;
                for (int j = 0; j < code.Length; j++) 
                {
                    numb += (10 - j) * code[j];
                }
                numb = numb + i;
                remains = numb % 11;
                if (remains == 0)
                {
                    string secondstr;
                    if (i == 10)
                    {
                        secondstr = firststr.Insert(9, "X");
                        Console.WriteLine($"ISBN code: {secondstr}");
                    }
                    else
                    {
                        ch = i.ToString();
                        secondstr = firststr.Insert(9, ch);
                        Console.WriteLine($"ISBN code: {secondstr}");
                    }
                }
            }
        }
    }
}
