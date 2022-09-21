using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace task5_2
{
    public class Book : IEnumerable<string>
    {
        public readonly string[] _authorsOfBook;
        public readonly string _title;
        public readonly string _dateOfPublication;

        public Book(string title, string dateOfPublication, params string[] autors)
        {
            _authorsOfBook = autors;
            _title = title;
            _dateOfPublication = dateOfPublication;
        }

        public override string ToString()
        {
            string str = "\nTitle: " + _title + "\nAuthors: ";
            foreach (string s in _authorsOfBook)
            {
                str += s;
                str += " ";
            }
            str += "\nDate of publication: " + _dateOfPublication;
            return str;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _authorsOfBook.Select(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
