using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyLib
{
    public class Logger
    {
        private string _fileName;
        public Logger(string fileName)
        {
            _fileName = fileName;
        }

        public void Track(User user)
        {
            Type tp = typeof(User);
            object[] attr = tp.GetCustomAttributes(false);
            foreach (object o in attr)
            {
                if (!o.GetType().Name.Equals("TrackingEntity"))
                {
                    return;
                }
            }
            GetAttribute(tp, user);
        }

        public void GetAttribute(Type t, User user)
        {
            List<(string, string)> lst = new List<(string, string)>();
            var properties = t.GetProperties();
            var fields = t.GetFields();
            string name = string.Empty;
            string value = string.Empty;
            foreach (var item in fields)
            {
                if (item.GetCustomAttributes(typeof(TrackingProperty)).Any())
                {
                    foreach (var el in item.GetCustomAttributes(typeof(TrackingProperty)))
                    {
                        name = el.GetType().GetProperties()[0].GetValue(el).ToString();
                        if (name.Equals(string.Empty))
                        {
                            name = item.Name;
                        }
                        var fld = t.GetField(item.Name);
                        value = fld.GetValue(user).ToString();
                        lst.Add((name, value));
                    }
                }
            }
            foreach (var item in properties)
            {
                if (item.GetCustomAttributes(typeof(TrackingProperty)).Any())
                {
                    foreach (var el in item.GetCustomAttributes(typeof(TrackingProperty)))
                    {
                        name = el.GetType().GetProperties()[0].GetValue(el).ToString();
                        if (name.Equals(string.Empty))
                        {
                            name = item.Name;
                        }
                        var fld = t.GetProperty(item.Name);
                        value = fld.GetValue(user).ToString();
                        lst.Add((name, value));
                    }
                }
            }
            JsonHelper.SaveJson(_fileName, lst);
        }
    }
}
