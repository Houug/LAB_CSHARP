using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    class Person : IDateAndCopy, IComparable, IComparer<Person>
    {
        protected string name;
        protected string surname;

        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            Date = birthdayValue;
        }

        public Person()
        {
            name = "Artem";
            surname = "Romanov";
            Date = new DateTime(2002, 02, 28);
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

        public DateTime Date { get; set; }

        public virtual object DeepCopy()
        {
            return new Person(Name, Surname, Date);
        }

        public int BirthdayYear
        {
            get
            {
                return Date.Year;
            }

            set
            {
                Date = new DateTime(value, Date.Month, Date.Day);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}.{3}.{4}", surname, name, Date.Day, Date.Month, Date.Year);
        }

        public virtual string ToShortString()
        {
            return string.Format("{0} {1}", surname, name);
        }

        public static bool operator ==(Person obj1, Person obj2)
        {
            return obj1.Name == obj2.Name & obj1.Surname == obj2.Surname & obj1.Date == obj2.Date;
        }

        public static bool operator !=(Person obj1, Person obj2)
        {
            return !(obj1 == obj2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return (Person)obj == this;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return Surname.CompareTo(obj);
        }

        public int Compare(Person x, Person y)
        {
            if (x.Date == y.Date)
            {
                return 0;
            }
            else if (x.Date > y.Date)
            {
                return 1;
            }
            else if (x.Date < y.Date)
            {
                return -1;
            }
            else throw new Exception("Что-то пошло не так!");
        }
    }
}
