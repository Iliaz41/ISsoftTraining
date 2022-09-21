using System;

Matrix matrix1 = new Matrix(5, 2, 3, 6, 8);
Console.WriteLine("First matrix:\n" + matrix1.ToString());
Console.WriteLine("Sum of elements: " + matrix1.Track());
Console.WriteLine("Element [1][1]: " + matrix1[1,1]);
Matrix matrix2 = new Matrix(9, 9, 8, 10, 11, 15);
Console.WriteLine("Second matrix:\n" + matrix2.ToString());
Console.WriteLine("Sum of elements: " + matrix2.Track());
Console.WriteLine("Element [2][1]: " + matrix2[2, 1]);
Console.WriteLine("New matrix:\n" + MatrixExtension.CreateMatrix(matrix1, matrix2).ToString());
Console.WriteLine("Result of compare two matrix: " + matrix1.Equals(matrix2));