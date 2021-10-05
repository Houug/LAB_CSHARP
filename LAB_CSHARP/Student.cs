using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    class Student : Person
    {
        private Education formatOfEducation;
        private int groupNumber;
        private System.Collections.ArrayList passedExems;
        private System.Collections.ArrayList passedTests;

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
            Exem[] tempArray = new Exem[passedExems.Length + newExems.Length];
            int i = 0;
            foreach (Exem item in passedExems)
            {
                tempArray[i] = item;
                i++;
            }

            foreach (Exem item in newExems)
            {
                tempArray[i] = item;
                i++;
            }

            passedExems = tempArray;
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
                    exemsStr += string.Format("{0}.{1}.{2} - {3} - {4}\n", item.Date.Day, item.Date.Month, item.Date.Year, item.NameOfDiscipline, item.Mark);
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
                "Имя: {0}\nФамилия: {1}\nДата рождения: {2}.{3}.{4}\nФорма обучения: {5}\nНомер группы: {6}\nЭказмены: \n{7}",
                personData.Name,
                personData.Surname,
                personData.Birthday.Day,
                personData.Birthday.Month,
                personData.Birthday.Year,
                education,
                groupNumber,
                exemsStr
                );
        }

        public virtual string ToShortString()
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
                personData.Name,
                personData.Surname,
                personData.Birthday.Day,
                personData.Birthday.Month,
                personData.Birthday.Year,
                education,
                groupNumber,
                AverageMark
                );
        }
    }
}
