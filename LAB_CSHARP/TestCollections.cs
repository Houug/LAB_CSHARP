using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    class TestCollections
    {
        List<Person> personList;
        List<string> stringList;
        Dictionary<Person, Student> dictPersonStudent;
        Dictionary<string, Student> dictStringStudent;
        
        public TestCollections(int size)
        {
            if (size <= 0)
            {
                throw new Exception("Число должно быть положительным");
            }

            personList = new List<Person>(size);
            dictPersonStudent = new Dictionary<Person, Student>(size);
            stringList = new List<string>(size);
            dictStringStudent = new Dictionary<string, Student>(size);

            Student student; 
            for (int i = 0; i < size; i++)
            {
                student = GenerateStudent(new Random().Next(100, 598));
                personList.Add(student.Info);
                dictPersonStudent.Add(student.Info, student);
                stringList.Add(student.Info.ToString());
                dictStringStudent.Add(student.Info.ToString(), student);
            }
        }

        static public Student GenerateStudent(int value)
        {
            return new Student(new Person(), Education.Вachelor, value);
        }
    }
}
