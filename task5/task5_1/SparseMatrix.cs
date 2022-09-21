using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace task5_1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private Dictionary<KeyValuePair<int, int>, long> _matrix;
        private int _rows;
        private int _columns;

        public SparseMatrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException();
            }
            _rows = rows;
            _columns = columns;
            _matrix = new Dictionary<KeyValuePair<int, int>, long>();
        }

        public long this[int i, int j]
        {
            get
            {
                Check(i, j);
                KeyValuePair<int, int> keyValuePair = new(i, j);
                return _matrix.ContainsKey(keyValuePair) ? _matrix[keyValuePair] : default;
            }
            set
            {
                Check(i, j);
                KeyValuePair<int, int> keyValuePair = new(i, j);
                _matrix.Add(keyValuePair, value);
            }
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    var element = this[i, j];
                    result += $"{(element == null ? "null" : element.ToString()),-10}";
                }
                result += Environment.NewLine;
            }
            return result;
        }

        public void Check(int rows, int columns)
        {
            if (rows < 0 || rows >= _rows || columns < 0 || columns >= _columns)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    KeyValuePair<int, int> keyValuePair = new(i, j);
                    if (_matrix.ContainsKey(keyValuePair))
                    {
                        yield return _matrix[keyValuePair];
                    }
                    else
                    {
                        yield return default;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int GetCount(long number)
        {
            int counter = 0;
            foreach (var element in _matrix.Values)
            {
                counter = (element == number) ? counter + 1 : counter;
            }
            return (number == 0) ? (counter + _rows * _columns - _matrix.Count()) : counter;
        }

        public IEnumerable<(int, int, long)> GetNonzeroElements()
        {
            List<(int, int, long)> list = new List<(int, int, long)>();
            var sortedElements = from item in _matrix
                                 orderby item.Key.Value, item.Key.Key
                                 select item;
            foreach (var number in sortedElements)
            {
                list.Add((number.Key.Key, number.Key.Value, number.Value));
            }
            return list;
        }
    }
}
