using System;

namespace task4_1
{
    public class MatrixTracker<T>
    {
        private DiagonalMatrix<T> _diagonalMatrix;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            _diagonalMatrix = new DiagonalMatrix<T>(diagonalMatrix.Size);
            for (int i = 0; i < diagonalMatrix.Size; i++)
            {
                _diagonalMatrix[i, i] = diagonalMatrix[i, i];
            }
        }

        public void Undo()
        {

        }
    }
}
