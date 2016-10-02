using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic
{
    class MyArray
    {
        string[] _arrayElements = new string[short.MaxValue];
        
        public object this[int index]
        {
            set
            {                   
                // Save the object in the corresponding spot.        
                _arrayElements[index] = (string)value;
            }
            get { return _arrayElements[index]; }
        }
    }
    public class mycollections
    {
        public static void test()
        {
            // Three-dimensional array.
            int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                 { { 7, 8, 9 }, { 10, 11, 12 } } };

            var list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.ForEach(Console.WriteLine);
            list.RemoveAt(1);
            list.ForEach(Console.WriteLine);

            Console.WriteLine("Converted from string to int");
            list.Select(x => { int a; Int32.TryParse(x, out a); return a; }).ToList().ForEach(Console.WriteLine);

            var arr = new[] { 1, 2, 3, 4 };
            arr.ToList().ForEach(Console.WriteLine);

            var dic = new Dictionary<string, string>();
            dic.Add("test", "test");
            dic.Add("1", "2");
            dic.Select(x => "[" + x.Key + " " + x.Value + "]").ToList().ForEach(Console.WriteLine);
            foreach (KeyValuePair<string, string> k in dic) { Console.WriteLine(k); };
            Dictionary<string, string>.KeyCollection keys = dic.Keys; foreach (string key in keys) { Console.WriteLine("Key: " + key); }
            Dictionary<string, string>.ValueCollection values = dic.Values; foreach (string value in values) { Console.WriteLine("Value: " + value); }
        }
        

    }
}
