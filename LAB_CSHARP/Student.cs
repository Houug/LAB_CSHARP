using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LAB_CSHARP
{
    [Serializable]
    public class Student : Person, IEnumerable, IComparer<Student>
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

        public int Compare(Student x, Student y)
        {
            return x.Info.Surname.CompareTo(y.Info.Surname);
        }

        public Student DeepCopy()
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                IFormatter format = new BinaryFormatter();
                format.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return (Student)format.Deserialize(stream);
            }
            catch
            {
                Console.WriteLine("ERROR");
                return new Student();
            }
        }
        public bool Save(string fileName)
        {
            bool result = true;
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
                format.Serialize(file, this);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public bool Load(string fileName)
        {
            bool result = true;
            Student oldStudent = new Student();
            oldStudent.Info = Info;
            oldStudent.FormatOfEducation = FormatOfEducation;
            oldStudent.PassedExams = PassedExams;
            oldStudent.PassedTests = PassedTests;
            oldStudent.GroupNumber = GroupNumber;
            Console.WriteLine(oldStudent.ToString());
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
                Student newStudent = (Student)format.Deserialize(file);

                Info = newStudent.Info;
                FormatOfEducation = newStudent.FormatOfEducation;
                PassedExams = newStudent.PassedExams;
                PassedTests = newStudent.PassedTests;
                GroupNumber = newStudent.GroupNumber;
            }
            catch
            {
                Info = oldStudent.Info;
                FormatOfEducation = oldStudent.FormatOfEducation;
                PassedExams = oldStudent.PassedExams;
                PassedTests = oldStudent.PassedTests;
                GroupNumber = oldStudent.GroupNumber;
                result = false;
            }
            return result;
        }
        static public bool Save(string fileName, Student obj)
        {
            bool result = true;
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);

                format.Serialize(file, obj);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool Load(string fileName, Student obj)
        {
            bool result = true;
            Student oldStudent = new Student();
            oldStudent.Info = obj.Info;
            oldStudent.FormatOfEducation = obj.FormatOfEducation;
            oldStudent.PassedExams = obj.PassedExams;
            oldStudent.PassedTests = obj.PassedTests;
            oldStudent.GroupNumber = obj.GroupNumber;

            try
            {
                BinaryFormatter format = new BinaryFormatter();
                FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
                Student newStudent = (Student)format.Deserialize(file);

                obj.Info = newStudent.Info;
                obj.FormatOfEducation = newStudent.FormatOfEducation;
                obj.PassedExams = newStudent.PassedExams;
                obj.PassedTests = newStudent.PassedTests;
                obj.GroupNumber = newStudent.GroupNumber;
            }
            catch
            {
                obj.Info = oldStudent.Info;
                obj.FormatOfEducation = oldStudent.FormatOfEducation;
                obj.PassedExams = oldStudent.PassedExams;
                obj.PassedTests = oldStudent.PassedTests;
                obj.GroupNumber = oldStudent.GroupNumber;
                result = false;

            }
            return result;
        }
        public bool AddFromConsole()
        {
            bool result = true;
            try
            {
                Console.WriteLine("Название предмета");
                string newSubject = Console.ReadLine();

                Console.WriteLine("Оценка");
                var newString = Console.ReadLine();
                int newMark;
                (int.TryParse(newString, out newMark);

                Console.WriteLine("Формат ввода даты \n" +
                    "Год сдачи экзамена.Месяц сдачи экзамена.День сдачи экзамена");
                var newString1 = Console.ReadLine();
                DateTime newDate = new DateTime(2020, 12, 30);
                DateTime.TryParse(newString1, out newDate);

                Console.WriteLine(newDate.ToString("D"));
                Exam newExam = new Exam(newSubject, newMark, newDate);
                PassedExams.Add(newExam);
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
