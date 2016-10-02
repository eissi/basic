using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic
{
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double GradePointAverage { get; set; }
    }
    class myOOP
    {
        public void test()
        {
            Student randal = new Student
            {
                Name = "Randal Sphar",
                Address = "123 Elm Street, Truth or Consequences, NM 00000",
                GradePointAverage = 3.51
            };

        }
    }
}
