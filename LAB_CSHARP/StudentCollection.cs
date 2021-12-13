using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LAB_CSHARP
{
    public class StudentCollection
    {
        private List<Student> _listStudent = new List<Student>();

        public void AddDefaults(int count)
        {
            if (count <= 0) throw new Exception("Число должно быть положительным");

            for (int i = 0; i < count; i++)
            {
                _listStudent.Add(new Student());
            }
        }

        public void AddStudents(params Student[] students)
        {
            foreach (var student in students)
            {
                _listStudent.Add(student);
            }
        }

        public override string ToString()
        {
            var str = "";
            foreach (var student in _listStudent)
            {
                str += "\n" + student;
            }

            return str;
        }

        public string ToShortString()
        {
            var str = "";
            foreach (var student in _listStudent)
            {
                str += "\n" + student.ToShortString();
            }

            return str;
        }

        public void SortBySurname()
        {
            _listStudent.Sort();
        }

        public void SortByBirthdayDate()
        {
            _listStudent.Sort(new Person());
        }

        public void SortByAveragePoints()
        {
            _listStudent.Sort(new StudentComparer());
        }
        
        
        public double MaxAveragePoints
        {
            get
            {
                try
                {
                    return _listStudent.Max(x => x.AverageMark);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public IEnumerable<Student> OnlySpecialist
        {
            get
            {
                return _listStudent.Where(x => x.FormatOfEducation == Education.Specialist);
            }
        }

        public List<Student> AverageMarkGroup(double value)
        {
            return _listStudent.Where(x => x.AverageMark == value).ToList();
        }
    }
}