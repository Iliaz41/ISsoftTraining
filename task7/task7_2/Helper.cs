using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace task7_2
{
    public class Helper
    {
        public static void СomputeAlgorithm()
        {
            for(int i=0; i < 10; i++)
            {
                Algorithm();
            }
        }

        private static void Algorithm()
        {
            Point[] points = ReadFile();
            double x = GenerateAsync().Result.Item1;
            double y = GenerateAsync().Result.Item2;
            int k = GenerateAsync().Result.Item3;
            List<Point> lst = new List<Point>();
            for (int i = 0; i < points.Length; i++) 
            {
                points[i].Distance = Math.Sqrt(Math.Pow(points[i].X - x, 2) + Math.Pow(points[i].Y - y, 2));
            }
            var group = from element in points
                        orderby element.Distance
                        select element;
            int num = 0;
            foreach(var el in group)
            {
                if (num == k)
                {
                    break;
                }
                lst.Add(el);
                num++;
            }
            Console.WriteLine(new Point(lst.GroupBy(x => x.Name).OrderByDescending(g => g.Count()).First().Key, x, y));
        }

        private static Point[] ReadFile()
        {
            List<Point> lst = new List<Point>();
            foreach (string item in File.ReadLines("data.txt"))
            {
                char[] delchar = { ',', ',' };
                string[] ch = item.Split(delchar);
                string name = ch[0];
                double x = Convert.ToDouble(ch[1].Replace(".", ","));
                double y = Convert.ToDouble(ch[2].Replace(".", ","));
                Point point = new Point(name, x, y);
                lst.Add(point);
            }
            return lst.ToArray();
        }

        private static (double, double, int) Generate()
        {
            Random random = new Random();
            return (random.Next(0, 10), random.Next(0, 15), random.Next(1, 20));
        }

        private static async Task<(double, double, int)> GenerateAsync()
        {
            Task task = Task.Delay(300);
            await task;
            return await Task.Run(() => Generate());
        }
    }
}
