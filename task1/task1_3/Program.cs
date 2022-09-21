using System;

namespace task1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount;
            for (; ; )
            {
                Console.WriteLine("Enter the amount of array elements:");
                amount = int.Parse(Console.ReadLine());
                if (amount > 1)
                    break;
            }
            int[] array = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("Enter the element of array:");
                array[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Element {i} of array: {array[i]}");
            }
            int a = MinIndex(array);
            int b = MaxIndex(array);
            if (a > b) 
            {
                int temp;
                temp = a;
                a = b;
                b = temp;
            }
            int sum = 0;
            for (int i = a; i <= b; i++)
            {
                sum += array[i];
            }
            Console.WriteLine($"Sum = {sum}");
        }

        public static int MinIndex(int[] array)
        {
            int minElement = array[0];
            int minIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (minElement > array[i])
                {
                    minElement = array[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public static int MaxIndex(int[] array)
        {
            int maxElement = array[0];
            int maxIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (maxElement <= array[i])
                {
                    maxElement = array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
    }
}
