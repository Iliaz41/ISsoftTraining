using System;
using System.Collections.Generic;

namespace task8_2
{
    class SimpleBinder
    {
        private static SimpleBinder instance;

        private SimpleBinder()
        {

        }

        public static SimpleBinder GetInstance()
        {
            if (instance == null)
            {
                instance = new SimpleBinder();
            }
            return instance;
        }

        public dynamic Bind(dynamic varriable, Dictionary<string, string> dictionary)
        {
            var type = varriable.GetType();
            var entity = Activator.CreateInstance(type);
            var properties = type.GetProperties();
            var fields = type.GetFields();
            List<string> lst = new List<string>();
            foreach (var item in fields)
            {
                if (item.FieldType.ToString().Equals("System.Int32") || item.FieldType.ToString().Equals("System.Double") || item.FieldType.ToString().Equals("System.String"))
                {
                    FindKey(item.Name, lst, dictionary);
                }
            }
            foreach (var item in properties)
            {
                if (item.PropertyType.Name.Equals("Int32") || item.PropertyType.Name.Equals("Double") || item.PropertyType.Name.Equals("String"))
                {
                    FindKey(item.Name, lst, dictionary);
                }
            }
            return lst;
        }

        private void FindKey(string key, List<string> lst, Dictionary<string, string> dictionary)
        {
            if (dictionary.ContainsKey(key))
            {
                lst.Add(dictionary[key]);
            }
            else if (dictionary.ContainsKey(key.ToLower()))
            {
                lst.Add(dictionary[key.ToLower()]);
            }
            else if (dictionary.ContainsKey(key.ToUpper()))
            {
                lst.Add(dictionary[key.ToUpper()]);
            }
        }
    }
}
