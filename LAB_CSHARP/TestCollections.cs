using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    class TestCollections
    {
        private List<Person> _personList;
        private List<string> _stringList;
        private Dictionary<Person, Student> _dictPersonStudent;
        private Dictionary<string, Student> _dictStringStudent;

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
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
    }
}