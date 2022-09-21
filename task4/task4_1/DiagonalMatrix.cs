using System;

namespace task4_1
{
    public class DiagonalMatrix<T>
    {
        private readonly T[] _data;

        public int Size => _data.Length;

        public T this[int i, int j]
        {
            get
            {
                if (i == j && IsCorrect(i))
                {
                    return _data[i];
                }
                else if (IsCorrect(i))
                {
                    return _data[i] = default(T);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (i == j && IsCorrect(i))
                {
                    if (_data[i].Equals(value)) return;
                    var oldData = _data[i];
                    _data[i] = value;
                    OnElementChanged(new ElementChangedEventArgs<T>(i, oldData, _data[i]));
                }
            }
        }

        public DiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                _data = new T[size];
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < _data.Length; i++)
            {
                for (int j = 0; j < _data.Length; j++)
                {
                    if (i == j)
                    {
                        str += _data[i];
                        str += " ";
                    }
                    else
                    {
                        str += "0";
                        str += " ";
                    }
                }
                str += "\n";
            }
            return str;
        }

        private bool IsCorrect(int i) => i >= 0 && i < Size;

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }
    }
}
