using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;

        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;
        }

        public Person()
        {
            name = "Artem";
            surname = "Romanov";
            birthday = new DateTime(2002, 02, 28);
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }

        public int BirthdayYear
        {
            get
            {
                return birthday.Year;
            }

            set
            {
                birthday = new DateTime(value, birthday.Month, birthday.Day);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}.{3}.{4}", surname, name, birthday.Day, birthday.Month, birthday.Year);
        }

        public virtual string ToShortString()
        {
            return string.Format("{0} {1}", surname, name);
        }
    }
}
