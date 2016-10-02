using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic
{
    class Program
    {
        static void Main(string[] args)
        {
            myDateTime.Test();

            #region performance metrics
            //PerfMetric.DisaplyCPUUsage();
            #endregion

            //CTRL+K & CTRL+X for code snippet
            //CTRL+K & CTRL+S for surronding

            //truncating 1.9 results in 1. Rounding 1.9 results in 2.
            // The integer equivalent of 37.78 is 37. integer truncation
            //the double is the default in C#.
            //decimal is the right type for banking, it's slower than integer calculation

            //mycollections.test();

            //myarithmetics.test();

            //mystring.test();

            Console.Read();
        }
        class Student { public String Name; }
    }
}
