using System;

namespace task4_1
{
    public static class DiagonalMatrixExtension<T>
    {
        public delegate T Func(T a, T b);

        public static DiagonalMatrix<T> AddMatrix(Func func, DiagonalMatrix<T> a, DiagonalMatrix<T> b)
        {
            a ??= new DiagonalMatrix<T>(0);
            b ??= new DiagonalMatrix<T>(0);
            func = CreateAdding;
            if (a.Size < b.Size)
            {
                var tmp = a;
                a = b;
                b = tmp;
            }

            var data = new T[a.Size];
            for (var i = 0; i < b.Size; i++)
            {
                data[i] = func(a[i, i], b[i, i]);
            }

            for (var i = b.Size; i < a.Size; i++)
            {
                data[i] = a[i, i];
            }

            DiagonalMatrix<T> diagonalMatrix = new DiagonalMatrix<T>(data.Length);
            for (var i = 0; i < diagonalMatrix.Size; i++)
            {
                diagonalMatrix[i, i] = data[i];
            }

            return diagonalMatrix;
        }

        public static T CreateAdding(T a, T b)
        {
            dynamic da = a, db = b;
            return da + db;
        }
    }
}
