using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LAB_CSHARP
{
    delegate TKey KeySelector<TKey>(Student st);
    class StudentCollection<TKey> : IComparer<Student>
    {
        private Dictionary<TKey, Student> _dictStudent;
        private KeySelector<TKey> _selector;

        public StudentCollection(KeySelector<TKey> selector)
        {
            _selector = selector;
            _dictStudent = new Dictionary<TKey, Student>();
        }

        public void AddDefaults()
        {
            for (int i = 0; i < 10; i++)
            {
                Student student = new Student(new Person("Artem", "test", DateTime.Now), Education.Specialist, 20);
                _dictStudent.Add(_selector(student), student);
            }
        }
        public void AddStudents(Student[] students)
        {
            foreach (Student student in students)
                _dictStudent.Add(_selector(student), student);
        }

        public void Add(Student student)
        {
            _dictStudent.Add(_selector(student), student);
        }

        public int Compare(Student a, Student b)
        {
            return a.AverageMark.CompareTo(b.AverageMark);
        } 


        public override string ToString()
        {
            string str = "";
            foreach (KeyValuePair<TKey, Student> keyValuePair in _dictStudent)
            {
                str += keyValuePair.Value.ToString() + '\n';
            }
            return str;
        }
        public string ToShortString()
        {
            string str = "";
            foreach (KeyValuePair<TKey, Student> keyValuePair in _dictStudent)
            {
                str += keyValuePair.Value.ToShortString() + '\n';
            }
            return str;
        }

        public double MaxAverageMark
        {
            get
            {
                return _dictStudent.Max(kv => kv.Value.AverageMark);
            }
        }

        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value)
        {
            return _dictStudent.Where(kv => kv.Value[value]);
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByFormatOfEducation
        {
            get
            {
                return _dictStudent.GroupBy(kv => kv.Value.FormatOfEducation);
            }
        }
    }
}