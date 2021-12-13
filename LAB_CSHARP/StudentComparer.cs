using System;
using System.Collections.Generic;

namespace LAB_CSHARP
{
    public class StudentComparer: IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.AverageMark == y.AverageMark) return 0;
            if (x.AverageMark > y.AverageMark) return 1;
            if (x.AverageMark < y.AverageMark) return -1;
            
            throw new Exception("Что-то пошло не так!");
        }
    }
}