using System;

namespace task5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            catalog["1234567894561"] = new Book("Shoe seller Phil Knight", "20.10.21", "author1");
            catalog["1234110009456"] = new Book("Book thief", "10.01.17", "author1", "author2", "author3");
            catalog["123-4-56-789411-1"] = new Book("Conor McGregor. Life without rules", "18.03.12", "author3");

            Console.WriteLine($"{catalog["1234567894111"]}");

            foreach (var item in catalog.GetAmountOfBooks())
            {
                Console.WriteLine($"{item.Item1} - { item.Item2}");
            }

            foreach (var title in catalog.SortOfTitles())
            {
                Console.WriteLine($"{title}");
            }

            foreach (var book in catalog.FindBooks("author1"))
            {
                Console.WriteLine($"{book}");
            }
        }
    }
}
