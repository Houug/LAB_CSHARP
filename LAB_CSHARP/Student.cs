using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    public class Student : Person, IEnumerable
    {
        private Education _formatOfEducation;
        private int _groupNumber;
        private List<Exam> _passedExams = new List<Exam>();
        private List<Test> _passedTests = new List<Test>();

        public Student(Person personDataValue, Education formatOfEducationValue, int groupNumberValue)
        {
            Name = personDataValue.Name;
            Surname = personDataValue.Surname;
            Date = personDataValue.Date;
            _formatOfEducation = formatOfEducationValue;
            _groupNumber = groupNumberValue;
        }

        public Student()
        {
            Person temp = new Person();
            Name = temp.Name;
            Surname = temp.Surname;
            Date = temp.Date;
            _formatOfEducation = Education.Вachelor;
            _groupNumber = 10;
        }

        public Person Info
        {
            get
            {
                return new Person(Name, Surname, Date);
            }
            set
            {
                Name = value.Name;
                Surname = value.Surname;
                Date = value.Date;
            }
        }

        public Education FormatOfEducation
        {
            get
            {
                return _formatOfEducation;
            }
            set
            {
                _formatOfEducation = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return _groupNumber;
            }
            set
            {
                if (value <= 100 | value > 599)
                {
                    throw new Exception("Номер группы должен быть в интервале от 100 до 599");
                }
                _groupNumber = value;
            }
        }

        public List<Exam> PassedExams
        {
            get
            {
                return _passedExams;
            }
            set
            {
                _passedExams = value;
            }
        }

        public List<Test> PassedTests
        {
            get
            {
                return _passedTests;
            }
            set
            {
                _passedTests = value;
            }
        }

        public override object DeepCopy()
        {
            Student newStudent = new Student(new Person(Name, Surname, Date), FormatOfEducation, GroupNumber);

            foreach (Exam item in PassedExams)
            {
                newStudent.PassedExams.Add((Exam) item.DeepCopy());
            }
            foreach (Test item in _passedTests)
            {
                newStudent._passedTests.Add((Test) item.DeepCopy());
            }

            return newStudent;
        }

        public double AverageMark
        {
            get
            {
                double result = 0;
                if (_passedExams == null)
                {
                    return result;
                }
                else
                {
                    foreach (Exam item in _passedExams)
                    {
                        result += item.Mark;
                    }
                    return result / _passedExams.Count;
                }
            }
        }

        public bool this[Education value]
        {
            get
            {
                return value == _formatOfEducation;
            }
        }

        public void AddExams(params Exam[] newExams)
        {
            foreach (Exam ex in newExams)
            {
                _passedExams.Add(ex);
            }
        }

        public void AddTests(params Test[] newTests)
        {
            foreach (Test ts in newTests)
            {
                _passedTests.Add(ts);
            }
        }

        public IEnumerable GetAllControlEvents()
        {
            foreach (object test in _passedTests)
            {
                yield return test;
            }

            foreach (object exam in _passedExams)
            {
                yield return exam;
            }
        }

        public IEnumerable GetExamsWhatBetterThen(int markValue)
        {
            foreach (Exam exam in _passedExams)
            {
                if (exam.Mark > markValue)
                {
                    yield return exam;
                }
            }
        }

        public IEnumerable GetPassedExams()
        {
            foreach (Exam exam in _passedExams)
            {
                if (exam.Mark > 2)
                {
                    yield return exam;
                }
            }
        }

        public IEnumerable GetPassedTests()
        {
            foreach (Test test in _passedTests)
            {
                if (test.Status)
                {
                    yield return test;
                }
            }
        }
        
        

        public override string ToString()
        {
            string examsStr = "";
            if (_passedExams == null)
            {
                examsStr = "Ни один эказмен не был сдан!";
            }
            else
            {
                foreach (Exam item in _passedExams)
                {
                    examsStr += item.ToString();
                }
            }

            string testsStr = "";
            if (_passedTests == null)
            {
                testsStr = "Ни один эказмен не был сдан!";
            }
            else
            {
                foreach (Test item in _passedTests)
                {
                    testsStr += item.ToString();
                }
            }

            string education = null;

            switch (_formatOfEducation)
            {
                case Education.Вachelor: education = "Бакалавриат"; break;
                case Education.Specialist: education = "Специалитет"; break;
                case Education.SecondEducation: education = "Второе высшее"; break;
            }
                
            
            return
                $"Имя: {Name}\nФамилия: {Surname}\nДата рождения: {Date.Day}.{Date.Month}.{Date.Year}\nФорма обучения: {education}\nНомер группы: {_groupNumber}\nЭказмены: \n{examsStr}\nТесты: \n{testsStr}";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StudentEnumerator(this); ;
        }

        public override string ToShortString()
        {

            string education = null;

            switch (_formatOfEducation)
            {
                case Education.Вachelor: education = "Бакалавриат"; break;
                case Education.Specialist: education = "Специалитет"; break;
                case Education.SecondEducation: education = "Второе высшее"; break;
            }


            return
                $"Имя: {Name}\nФамилия: {Surname}\nДата рождения: {Date.Day}.{Date.Month}.{Date.Year}\nФорма обучения: {education}\nНомер группы: {_groupNumber}\nСредний балл за экзамены: {AverageMark}\n";
        }
    }
}
