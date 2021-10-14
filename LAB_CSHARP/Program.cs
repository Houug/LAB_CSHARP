using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LAB_CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("1 ==================");
            Person first_tester = new Person();
            Person second_tester = new Person();

            Console.WriteLine(ReferenceEquals(first_tester, second_tester));
            Console.WriteLine(first_tester.GetHashCode());
            Console.WriteLine(second_tester.GetHashCode());

            Console.WriteLine("2 ==================");
            // 2
            Student student = new Student();
            Exem[] exems = new Exem[2];
            exems[0] = new Exem("дифур", 2, new DateTime());
            exems[1] = new Exem("матан", 4, new DateTime());
            student.AddExems(exems);

            Test[] tests = new Test[2];
            tests[0] = new Test("дифур", false);
            tests[1] = new Test("матан", true);
            student.AddTests(tests);
            Console.WriteLine(student);

            // 3
            Console.WriteLine("3 ==================");
            Console.WriteLine(student.Info);

            // 4
            Console.WriteLine("4 ==================");
            Student copied_student = (Student)student.DeepCopy();
            exems = new Exem[1];
            exems[0] = new Exem("физра", 3, new DateTime());
            copied_student.AddExems(exems);
            Console.WriteLine(student);
            Console.WriteLine(copied_student);

            // 5

            Console.WriteLine("5 ==================");
            try
            {
                student.GroupNumber = 9;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 6
            Console.WriteLine("6 ==================");
            foreach (object i in student.GetAllControlEvents())
            {
                Console.Write(i);
            }

            // 7
            Console.WriteLine("7 ==================");
            foreach (object i in student.GetExemsBetterThen(3))
            {
                Console.Write(i);
            }

            // 8
            Console.WriteLine("8 ==================");
            foreach (object i in student)
            {
                Console.WriteLine(i);
            }

            // 9

            Console.WriteLine("9 ==================");
            foreach (object i in student.GetPassedExems())
            {
                Console.WriteLine(i);
            }

            // 10

            Console.WriteLine("10 ==================");
            foreach (object i in student.GetPassedTests())
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
