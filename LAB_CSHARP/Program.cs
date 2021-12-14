using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace LAB_CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("1 ==================");
            TestCollections testCollections;
            Int32 size;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите положительное число: ");
                    size = Convert.ToInt32(Console.ReadLine());
                    testCollections = new TestCollections(size);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var firstElement = testCollections.DictionaryPersonStudent.First().Value;
            var lastElement = testCollections.DictionaryPersonStudent.Last().Value;
            var middleElement = testCollections.DictionaryPersonStudent.ElementAt(size / 2).Value;
            var outsideElement = new Student();

            testCollections.StopwatchTime(firstElement,lastElement,middleElement,outsideElement);
            
            Console.WriteLine("2 ==================");

            StudentCollection studentCollection = new StudentCollection();
            Student[] students =
            {
                new Student(new Person("Vova", "Popov", new DateTime()), Education.Specialist, 201),
                new Student(new Person("Ed", "Mapov", new DateTime(2000,9,7)), Education.Specialist, 201),
                new Student(new Person("Jora", "Durov", new DateTime()), Education.Specialist, 201),
                new Student(new Person("Mira", "Wolow", new DateTime()), Education.Вachelor, 103),
                new Student(new Person("Dora", "True", new DateTime()), Education.Specialist, 103),
                new Student(new Person("Artem", "Popov", new DateTime()), Education.Specialist, 201)
            };
            studentCollection.AddStudents(students);
            Console.WriteLine(studentCollection.ToShortString());
            studentCollection.SortBySurname();
            Console.WriteLine(studentCollection.ToShortString());
            studentCollection.SortByBirthdayDate();
            Console.WriteLine(studentCollection.ToShortString());
            studentCollection.SortByAveragePoints();
            Console.WriteLine(studentCollection.ToShortString());
            
            Console.WriteLine("3 ==================");
            Console.WriteLine(studentCollection.MaxAveragePoints);
            foreach (Student s in studentCollection.OnlySpecialist)
            {
                Console.WriteLine(s.ToShortString());
            }
            
            
            foreach (Student s in studentCollection.AverageMarkGroup(10))
            {
                Console.WriteLine(s.ToShortString());
            }


        }
    }
}