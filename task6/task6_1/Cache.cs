using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task6_1
{
    public class Cache : IEnumerable
    {
        private Dictionary<string, (object, DateTime)> _cache;
        private int _size;

        public Cache(int size)
        {
            CheckSize(size);
            _size = size;
            _cache = new Dictionary<string, (object, DateTime)>();
        }

        public void Set(string key, object obj)
        {
            if (key == null || key.Length == 0 || obj == null)
            {
                throw new ArgumentNullException();
            }
            if (_cache.Count > _size)
            {
                throw new ArgumentException();
            }
            else if (_cache.Count == _size)  
            {
                if(_cache.ContainsKey(key))
                {
                    _cache[key] = (obj, DateTime.Now);
                }
                else
                {
                    var minElement = DateTime.Now;
                    string el = "";
                    foreach (var item in _cache)
                    {
                        int result = DateTime.Compare(minElement, item.Value.Item2);
                        if (result >= 0) 
                        {
                            minElement = item.Value.Item2;
                            el = item.Key;
                        }
                    }
                    Remove(el);
                    _cache.Add(key, (obj, DateTime.Now));
                }

            }
            else
            {
                if(_cache.ContainsKey(key))
                {
                    _cache[key] = (obj, DateTime.Now);
                }
                else
                {
                    _cache.Add(key, (obj, DateTime.Now));
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var elements in _cache)
            {
                yield return elements;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public object Get(string key)
        {
            if (key == null || key.Length == 0)
            {
                throw new ArgumentNullException();
            }
            if(_cache.ContainsKey(key))
            {
                foreach (var item in _cache)
                {
                    if (key == item.Key)
                    {
                        var element = item.Value.Item1;
                        _cache[key] = (element, DateTime.Now);
                    }
                }
                return _cache[key];
            }
            else
            {
                return null;
            }
        }

        public bool Remove(string key)
        {
            if(_cache.ContainsKey(key))
            {
                _cache.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Monitor()
        {
            Thread myThread = new Thread(Func);
            myThread.Start();
        }

        public void Func()
        {
            List<string> lst = new List<string>();
            foreach(var item in _cache)
            {
                if (DateTime.Now.Subtract(item.Value.Item2).TotalMinutes == 0 && DateTime.Now.Subtract(item.Value.Item2).TotalSeconds > 10)
                {
                    lst.Add(item.Key);
                }
            }
            foreach(var el in lst)
            {
                Remove(el);
            }
            Thread.Sleep(1000);
        }

        public void CheckSize(int size)
        {
            if (size <= 0 || size % 1 != 0) 
            {
                throw new ArgumentException();
            }
        }
    }
}
