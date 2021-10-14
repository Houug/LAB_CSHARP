using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    class Student : Person, IEnumerable
    {
        private Education formatOfEducation;
        private int groupNumber;
        private ArrayList passedExems = new ArrayList();
        private ArrayList passedTests = new ArrayList();

        public Student(Person personDataValue, Education formatOfEducationValue, int groupNumberValue)
        {
            Name = personDataValue.Name;
            Surname = personDataValue.Surname;
            Date = personDataValue.Date;
            formatOfEducation = formatOfEducationValue;
            groupNumber = groupNumberValue;
        }

        public Student()
        {
            Person temp = new Person();
            Name = temp.Name;
            Surname = temp.Surname;
            Date = temp.Date;
            formatOfEducation = Education.Вachelor;
            groupNumber = 10;
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
                return formatOfEducation;
            }
            set
            {
                formatOfEducation = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return groupNumber;
            }
            set
            {
                if (value <= 100 | value > 599)
                {
                    throw new Exception("Номер группы должен быть в интервале от 100 до 599");
                }
                groupNumber = value;
            }
        }

        public ArrayList PassedExems
        {
            get
            {
                return passedExems;
            }
            set
            {
                passedExems = value;
            }
        }

        public ArrayList PassedTests
        {
            get
            {
                return passedTests;
            }
            set
            {
                passedTests = value;
            }
        }

        public override object DeepCopy()
        {
            Student newStudent = new Student(new Person(Name, Surname, Date), FormatOfEducation, GroupNumber);

            foreach (Exem item in PassedExems)
            {
                newStudent.PassedExems.Add(item.DeepCopy());
            }
            foreach (Test item in passedTests)
            {
                newStudent.passedTests.Add(item.DeepCopy());
            }

            return newStudent;
        }

        public double AverageMark
        {
            get
            {
                double result = 0;
                if (passedExems == null)
                {
                    return result;
                }
                else
                {
                    foreach (Exem item in passedExems)
                    {
                        result += item.Mark;
                    }
                    return result / passedExems.Count;
                }
            }
        }

        public bool this[Education value]
        {
            get
            {
                return value == formatOfEducation;
            }
        }

        public void AddExems(params Exem[] newExems)
        {
            foreach (Exem ex in newExems)
            {
                passedExems.Add(ex);
            }
        }

        public void AddTests(params Test[] newTests)
        {
            foreach (Test ts in newTests)
            {
                passedTests.Add(ts);
            }
        }

        public IEnumerable GetAllControlEvents()
        {
            foreach (object test in passedTests)
            {
                yield return test;
            }

            foreach (object exem in passedExems)
            {
                yield return exem;
            }
        }

        public IEnumerable GetExemsBetterThen(int markValue)
        {
            foreach (Exem exem in passedExems)
            {
                if (exem.Mark > markValue)
                {
                    yield return exem;
                }
            }
        }

        public IEnumerable GetPassedExems()
        {
            foreach (Exem exem in passedExems)
            {
                if (exem.Mark > 2)
                {
                    yield return exem;
                }
            }
        }

        public IEnumerable GetPassedTests()
        {
            foreach (Test test in passedTests)
            {
                if (test.Status)
                {
                    yield return test;
                }
            }
        }

        public override string ToString()
        {
            string exemsStr = "";
            if (passedExems == null)
            {
                exemsStr = "Ни один эказмен не был сдан!";
            }
            else
            {
                foreach (Exem item in passedExems)
                {
                    exemsStr += item.ToString();
                }
            }

            string testsStr = "";
            if (passedTests == null)
            {
                testsStr = "Ни один эказмен не был сдан!";
            }
            else
            {
                foreach (Test item in passedTests)
                {
                    testsStr += item.ToString();
                }
            }

            string education = null;

            switch (formatOfEducation)
            {
                case Education.Вachelor: education = "Бакалавриат"; break;
                case Education.Specialist: education = "Специалитет"; break;
                case Education.SecondEducation: education = "Второе высшее"; break;
            }
                
            
            return string.Format(
                "Имя: {0}\nФамилия: {1}\nДата рождения: {2}.{3}.{4}\nФорма обучения: {5}\nНомер группы: {6}\nЭказмены: \n{7}\nТесты: \n{8}",
                Name,
                Surname,
                Date.Day,
                Date.Month,
                Date.Year,
                education,
                groupNumber,
                exemsStr,
                testsStr
                );
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StudentEnumerator(this); ;
        }

        public override string ToShortString()
        {

            string education = null;

            switch (formatOfEducation)
            {
                case Education.Вachelor: education = "Бакалавриат"; break;
                case Education.Specialist: education = "Специалитет"; break;
                case Education.SecondEducation: education = "Второе высшее"; break;
            }


            return string.Format(
                "Имя: {0}\nФамилия: {1}\nДата рождения: {2}.{3}.{4}\nФорма обучения: {5}\nНомер группы: {6}\nСредний балл за экзамены: {7}\n",
                Name,
                Surname,
                Date.Day,
                Date.Month,
                Date.Year,
                education,
                groupNumber,
                AverageMark
                );
        }
    }
}
