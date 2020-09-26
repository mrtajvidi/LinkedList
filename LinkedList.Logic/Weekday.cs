using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.Logic
{
    public class Weekday
    {
        public string Day { get; set; }
        public Weekday Next { get; set; }

        public Weekday(string day)
        {
            Day = day;
        }
    }
}
