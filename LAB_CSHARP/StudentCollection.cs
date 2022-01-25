using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LAB_CSHARP
{
    public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
    public class StudentCollection
    {
        private List<Student> _listStudent = new List<Student>();
        public event StudentListHandler StudentsCountChanged;
        public event StudentListHandler StudentReferenceChanged;

        public void AddDefaults(int count)
        {
            if (count <= 0) throw new Exception("Число должно быть положительным");

            for (int i = 0; i < count; i++)
            {
                _listStudent.Add(new Student());
                var size = _listStudent.Count;
                StudentsCountChanged(this, new StudentListHandlerEventArgs("List", "Student", _listStudent.ElementAt(size-1)));
            }
        }

        public void AddStudents(params Student[] students)
        {
            foreach (var student in students)
            {
                _listStudent.Add(student);
                var size = _listStudent.Count;
                StudentsCountChanged(this, new StudentListHandlerEventArgs("List", "Student", _listStudent.ElementAt(size-1)));
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
            _listStudent.Sort(new Student());
        }

        public void SortByBirthdayDate()
        {
            _listStudent.Sort(new Person());
        }

        public void SortByAveragePoints()
        {
            try
            {
                _listStudent.Sort(new StudentComparer());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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

        public string CollectionName { get; set; }
        public bool Remove(int j)
        {
            try
            {
                Student removedObject = _listStudent[j];
                _listStudent.RemoveAt(j);
                StudentsCountChanged(this, new StudentListHandlerEventArgs("List", "Student", removedObject));
                return true;
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
        public Student this[int index]
        {
            get { return _listStudent[index]; }
            set
            {
                try
                {
                    _listStudent[index] = value;
                    StudentReferenceChanged(this, new StudentListHandlerEventArgs("List", "Student", _listStudent[index]));
                }catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        

    }
}