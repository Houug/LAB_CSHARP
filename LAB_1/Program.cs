using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LAB_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student firstStudent = new Student();
            Console.WriteLine(firstStudent.ToShortString());

            Console.WriteLine(firstStudent[Education.Вachelor].ToString());
            Console.WriteLine(firstStudent[Education.Specialist].ToString());
            Console.WriteLine(firstStudent[Education.SecondEducation].ToString());

            firstStudent.FormatOfEducation = Education.Вachelor;
            firstStudent.GroupNumber = 13;
            firstStudent.PassedExems = new Exem[] { new Exem("Физика", 40, new DateTime(2021, 4, 6)) };
            firstStudent.PersonData = new Person("Иван", "Иванов", new DateTime(2001, 1, 3));

            Console.WriteLine(firstStudent.ToString());

            firstStudent.AddExems(new Exem("МА", 30, new DateTime(2021, 5, 3)));
            firstStudent.AddExems(new Exem("C++", 30, new DateTime(2021, 4, 7)), new Exem("C#", 10, new DateTime(2021, 2, 1)));
            Console.WriteLine(firstStudent.ToString());


            // Блок с массивами
            Console.WriteLine("Введите кол-во строк и колонок в формате row*column или row/column");
            string[] answer = Console.ReadLine().Split('*', '/');
            int row = Convert.ToInt32(answer[0]);
            int column = Convert.ToInt32(answer[1]);
            long totalSize = row * column;

            Exem[] exems1 = new Exem[totalSize];
            Exem[,] exems2 = new Exem[row,column];
            Exem[][] exems3 = new Exem[4][];

            long firstSize = totalSize / 3;
            exems3[0] = new Exem[firstSize];

            long secondSize = firstSize / 2;
            exems3[1] = new Exem[secondSize];

            long thirdSize = secondSize / 2;
            exems3[2] = new Exem[thirdSize];

            long fourthSize = totalSize - firstSize - secondSize - thirdSize;
            exems3[3] = new Exem[fourthSize];


            //Инициализация

            for (int i = 0; i < exems1.Length; i++)
            {
                exems1[i] = new Exem();
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    exems2[i, j] = new Exem();
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < exems3[i].Length; j++)

                {
                    exems3[i][j] = new Exem();
                }
            }

            Stopwatch sw = new Stopwatch();


            //одномерный массив
            sw.Start();
            foreach (Exem item in exems1)
            {
                item.Mark = 10;
            }
            sw.Stop();

            Console.WriteLine(sw.Elapsed + " - одномерный массив " + exems1.Length);
            sw.Reset();


            //двумерный прямоугольный массив
            sw.Start();
            foreach (Exem item in exems2)
            {
                item.Mark = 10;
            }
            sw.Stop();

            Console.WriteLine(sw.Elapsed + " - двумерный прямоугольный массив "+exems2.Length);
            sw.Reset();


            //двумерный ступенчатый массив
            sw.Start();
            foreach (Exem[] item in exems3)
            {
                foreach (Exem innerItem in item)
                {
                    innerItem.Mark = 10;
                }
            }
            sw.Stop();
            
            Console.WriteLine(sw.Elapsed + " - двумерный ступенчатый массив " + (exems3[0].Length+exems3[1].Length+exems3[2].Length+exems3[3].Length));
            sw.Reset();

            Console.ReadKey();
        }
    }
}
