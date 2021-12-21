using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    public class Exam : IDateAndCopy, IComparable , IComparer<Exam>
    {
        public string NameOfDiscipline { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }

        public Exam(string nameOfDisciplineValue, int markValue, DateTime dateValue)
        {
            NameOfDiscipline = nameOfDisciplineValue;
            Mark = markValue;
            Date = dateValue;
        }
        public Exam()
        {
            NameOfDiscipline = "NAN";
            Mark = -1;
            Date = new DateTime(1901, 1, 1);
        }

        public object DeepCopy()
        {
            return new Exam(NameOfDiscipline, Mark, Date);
        }

        public int Compare(Exam x, Exam y)
        {
            return x.Mark.CompareTo(y.Mark);
        }

        public override string ToString()
        {
            return $"Название: {NameOfDiscipline}, Оценка: {Mark}, Дата: {Date.Day}.{Date.Month}.{Date.Year}\n";
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Exam ex = (Exam) obj ;
            return NameOfDiscipline.CompareTo(ex.NameOfDiscipline);
        }
    }
}
