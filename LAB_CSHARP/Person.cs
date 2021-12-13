using System;
using System.Collections.Generic;

namespace LAB_CSHARP
{
    public class Person : IDateAndCopy, IComparable, IComparer<Person>
    {
        private string _name;
        private string _surname;

        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            _name = nameValue;
            _surname = surnameValue;
            Date = birthdayValue;
        }

        public Person()
        {
            _name = "Artem";
            _surname = "Romanov";
            Date = new DateTime(new Random().Next(1900,2020), new Random().Next(1,12), new Random().Next(1,31));
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }

            set
            {
                _surname = value;
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
            return $"{_surname} {_name} {Date.Day}.{Date.Month}.{Date.Year}";
        }

        public virtual string ToShortString()
        {
            return $"{_surname} {_name}";
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

            if (x.Date > y.Date)
            {
                return 1;
            }

            if (x.Date < y.Date)
            {
                return -1;
            }

            throw new Exception("Что-то пошло не так!");
        }
    }
}
