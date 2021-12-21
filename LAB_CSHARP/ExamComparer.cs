using System.Collections.Generic;

namespace LAB_CSHARP
{
    public class ExamComparer: IComparer<Exam>
    {
        public int Compare(Exam x, Exam y)
        {
            return x.Date.CompareTo(y.Date);
        }

    }
}