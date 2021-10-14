using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    class Test
    {
        public string Name { get; set; }
        public bool Status { get; set; }

        public Test(string nameValue, bool statusValue)
        {
            Name = nameValue;
            Status = statusValue;
        }

        public Test()
        {
            Name = "NAN";
            Status = false;
        }

        public object DeepCopy()
        {
            return new Test(Name, Status);
        }

        public override string ToString()
        {
            if (Status)
            {
                return string.Format("{0} - сдано\n", Name);
            }
            else
            {
                return string.Format("{0} - не сдано\n", Name);
            }
        }
    }
}
