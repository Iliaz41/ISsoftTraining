using System;

public static class MatrixExtension
{
    public static Matrix CreateMatrix(Matrix matrix1, Matrix matrix2)
    {
        int[] array1 = matrix1.Elements;
        int[] array2 = matrix2.Elements;
        int totalSize = Math.Max(matrix1.Size, matrix2.Size);
        int[] result = new int[totalSize];
        if (array1.Length < totalSize)
        {
            Array.Resize(ref array1, array1.Length + (totalSize - array1.Length));
            for (int i = 0; i < array1.Length; i++) 
            {
                array1[array1.Length - totalSize + array1.Length - 1] = 0;
            }
        }
        if (array2.Length < totalSize)
        {
            Array.Resize(ref array2, array2.Length + (totalSize - array2.Length));
            for (int i = 0; i < array2.Length; i++) 
            {
                array2[array2.Length - totalSize + array2.Length - 1] = 0;
            }
        }
        for(int i=0; i < totalSize; i++)
        {
            result[i] = array1[i] + array2[i];
        }
        return new Matrix(result);
    }
}

