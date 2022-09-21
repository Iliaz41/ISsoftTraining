using System;

namespace task4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(4);
            diagonalMatrix[0, 0] = 5;
            diagonalMatrix[1, 1] = 1;
            diagonalMatrix[2, 2] = 3;
            diagonalMatrix[3, 3] = 4;

            diagonalMatrix.ElementChanged += (_, e) => Console.WriteLine($"Old = {e.Old}, New = {e.New}");
            Console.WriteLine(diagonalMatrix.ToString());
            diagonalMatrix[0, 0] = 5;
            diagonalMatrix[1, 1] = 9;
            Console.WriteLine(diagonalMatrix.ToString());

            DiagonalMatrix<int> diagonalMatrix2 = new DiagonalMatrix<int>(3);
            diagonalMatrix2[0, 0] = 2;
            diagonalMatrix2[1, 1] = 2;
            diagonalMatrix2[2, 2] = 2;


            Console.WriteLine(diagonalMatrix2.ToString());
            DiagonalMatrixExtension<int>.Func func = null;
            Console.WriteLine(DiagonalMatrixExtension<int>.AddMatrix(func, diagonalMatrix, diagonalMatrix2));
        }
    }
}
