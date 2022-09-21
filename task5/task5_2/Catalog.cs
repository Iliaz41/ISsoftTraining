using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace task5_2
{
    public class Catalog : IEnumerable<Book>
    {
        private Dictionary<string, Book> _books = new Dictionary<string, Book>();

        public Book this[string ISBNkey]
        {
            get
            {
                var isbnKey = Check(ISBNkey);
                return _books[isbnKey];
            }
            set
            {
                var isbnKey = Check(ISBNkey);
                _books[isbnKey] = value;
            }
        }

        private string Check(string input)
        {
            Regex firstRegex = new Regex(@"\d{3}-\d{1}-\d{2}-\d{6}-\d{1}");
            Regex secondRegex = new Regex(@"\d{13}");
            if (firstRegex.IsMatch(input))
            {
                return input.Replace("-", "");
            }
            else if (secondRegex.IsMatch(input) && input.Length == 13)
            {
                return input;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<(string, int)> GetAmountOfBooks()
        {
            var groupElements = this.SelectMany(b => b._authorsOfBook)
                                               .GroupBy(i => i)
                                               .Select(i => (i.Key, i.Count())).ToArray();
            return groupElements;
        }

        public IEnumerable<string> SortOfTitles()
        {
            List<string> list = new List<string>();
            var groupElements = from item in _books
                                orderby item.Value._title
                                select item;

            foreach (var element in groupElements)
            {
                list.Add(element.Value._title);
            }
            return list;
        }

        public IEnumerable<Book> FindBooks(string authorName)
        {
            List<Book> list = new List<Book>();
            var groupElements = from item in _books
                                from author in item.Value._authorsOfBook
                                where author == authorName
                                orderby item.Value._dateOfPublication
                                select item;
            foreach (var element in groupElements)
            {
                list.Add(element.Value);
            }
            return list;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return _books.Select(x => x.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
