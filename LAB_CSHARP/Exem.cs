using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    class Exem : IDateAndCopy
    {
        public string NameOfDiscipline { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }

        public Exem(string NameOfDisciplineValue, int MarkValue, DateTime DateValue)
        {
            NameOfDiscipline = NameOfDisciplineValue;
            Mark = MarkValue;
            Date = DateValue;
        }
        public Exem()
        {
            NameOfDiscipline = "NAN";
            Mark = -1;
            Date = new DateTime(1901, 1, 1);
        }

        public object DeepCopy()
        {
            return new Exem(NameOfDiscipline, Mark, Date);
        }

        public override string ToString()
        {
            return string.Format("Название: {0}, Оценка: {1}, Дата: {2}.{3}.{4}", NameOfDiscipline, Mark, Date.Day, Date.Month, Date.Year);
        }
    }
}
