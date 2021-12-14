using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    public class TestCollections
    {
        private List<Person> _personList;
        private List<string> _stringList;
        private Dictionary<Person, Student> _dictPersonStudent;
        private Dictionary<string, Student> _dictStringStudent;
        
        public TestCollections(int size)
        {
            if (size <= 0)
            {
                throw new Exception("Число должно быть положительным");
            }

            _personList = new List<Person>(size);
            _dictPersonStudent = new Dictionary<Person, Student>(size);
            _stringList = new List<string>(size);
            _dictStringStudent = new Dictionary<string, Student>(size);

            for (int i = 0; i < size; i++)
            {
                while (true)
                {
                    try
                    {
                        var student = GenerateStudent(new Random().Next(100, 598));
                        _personList.Add(student.Info);
                        _dictPersonStudent.Add(student.Info, student);
                        _stringList.Add(student.Info.ToString());
                        _dictStringStudent.Add(student.Info.ToString(), student);
                        break;
                    }
                    catch (Exception e)
                    {
                        // ignored
                    }
                }
            }
        }

        private static Student GenerateStudent(int value)
        {
            return new Student(new Person(), Education.Вachelor, value);
        }

        public List<Person> ListPerson
        {
            get { return _personList; }
        }

        public List<string> ListString
        {
            get { return _stringList; }
        }

        public Dictionary<Person, Student> DictionaryPersonStudent
        {
            get { return _dictPersonStudent; }
        }

        public Dictionary<string, Student> DictionaryStringStudent
        {
            get { return _dictStringStudent; }
        }

        public void StopwatchTime(Student firstElement,Student lastElement,Student middleElement,Student outsideElement)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            Console.WriteLine("Листы");
            Console.WriteLine("\nFirstElement");
            stopwatch.Restart();
            ListPerson.Contains(firstElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            ListString.Contains(firstElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nLastElement");
            stopwatch.Restart();
            ListPerson.Contains(lastElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            ListString.Contains(lastElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            Console.WriteLine("\nMiddleElement");
            stopwatch.Restart();
            ListPerson.Contains(middleElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            ListString.Contains(middleElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nOutsideElement");
            stopwatch.Restart();
            ListPerson.Contains(outsideElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            ListString.Contains(outsideElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("Словари Key");
            Console.WriteLine("\nFirstElement");
            stopwatch.Restart();
            DictionaryPersonStudent.ContainsKey(firstElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            DictionaryStringStudent.ContainsKey(firstElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nLastElement");
            stopwatch.Restart();
            DictionaryPersonStudent.ContainsKey(lastElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            DictionaryStringStudent.ContainsKey(lastElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            Console.WriteLine("\nMiddleElement");
            stopwatch.Restart();
            DictionaryPersonStudent.ContainsKey(middleElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            DictionaryStringStudent.ContainsKey(middleElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nOutsideElement");
            stopwatch.Restart();
            DictionaryPersonStudent.ContainsKey(outsideElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            DictionaryStringStudent.ContainsKey(outsideElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("Словари Value");
            Console.WriteLine("\nFirstElement");
            stopwatch.Restart();
            DictionaryPersonStudent.ContainsValue(firstElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            DictionaryStringStudent.ContainsValue(firstElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nLastElement");
            stopwatch.Restart();
            DictionaryPersonStudent.ContainsValue(lastElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            DictionaryStringStudent.ContainsValue(lastElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            Console.WriteLine("\nMiddleElement");
            stopwatch.Restart();
            DictionaryPersonStudent.ContainsValue(middleElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            DictionaryStringStudent.ContainsValue(middleElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nOutsideElement");
            stopwatch.Restart();
            DictionaryPersonStudent.ContainsValue(outsideElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            DictionaryStringStudent.ContainsValue(outsideElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}