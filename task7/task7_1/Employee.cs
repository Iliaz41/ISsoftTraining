using System;
using System.Collections.Generic;
using System.Linq;

namespace task7_1
{
    public class Employee
    {
        private List<(string, TimeSpan)> lst;

        public Employee()
        {
            lst = new List<(string, TimeSpan)>();
        }

        public void Add(string name, DateTime from, DateTime to)
        {
            var duration = (to - from).Duration();
            if (duration != TimeSpan.Zero) 
            {
                lst.Add((name, duration));
            }
        }

        public TimeSpan AverageDuration()
        {
            List<TimeSpan> timeSpans = CreateTimeSpans();
            double doubleAverageTicks = timeSpans.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);
            return new TimeSpan(longAverageTicks);
        }

        public List<(string, TimeSpan)> AverageEmployeeDuration()
        {
            List<string> names = new List<string>();
            bool start = true;
            foreach(var element in lst)
            {
                if (start)
                {
                    names.Add(element.Item1);
                    start = false;
                }
                if (!names.Contains(element.Item1))
                {
                    names.Add(element.Item1);
                }
            }
            TimeSpan time = TimeSpan.Zero;
            List<(string, TimeSpan)> durationLst = new List<(string, TimeSpan)>();
            foreach(var name in names)
            {
                time = TimeSpan.Zero;
                var groupElements = from item in lst
                                    where name == item.Item1
                                    select item;
                foreach (var element in groupElements)
                {
                    time += element.Item2;
                }
                time /= groupElements.Count();
                durationLst.Add((name, time));
            }
            return durationLst;
        }

        private List<TimeSpan> CreateTimeSpans()
        {
            List<TimeSpan> timeSpans = new List<TimeSpan>();
            foreach(var element in lst)
            {
                timeSpans.Add(element.Item2);
            }
            return timeSpans;
        }

        public List<(string, TimeSpan)> GetList()
        {
            return lst;
        }

        public override string ToString()
        {
            string str = string.Empty;
            foreach(var element in lst)
            {
                str += element;
                str += "\n";
            }
            return str;
        }
    }
}
