using System;

namespace task5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix sparseMatrix = new SparseMatrix(3, 4);

            sparseMatrix[1, 2] = 5;
            sparseMatrix[0, 1] = 4;
            sparseMatrix[2, 2] = 7;
            sparseMatrix[1, 1] = 1;
            sparseMatrix[2, 1] = 2;
            sparseMatrix[0, 0] = 3;

            Console.WriteLine(sparseMatrix.ToString());

            foreach (var item in sparseMatrix)
            {
                Console.WriteLine(item);
            }

            var lst = sparseMatrix.GetNonzeroElements();
            foreach (var i in lst)
            {
                Console.WriteLine($"{i}");
            }

            Console.WriteLine($"{sparseMatrix.GetCount(0)}");
        }
    }
}
