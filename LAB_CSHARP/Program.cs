using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace LAB_CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Maykl", "Norrel", new DateTime(1993, 1, 12));
            Exam exam_1 = new Exam();
            Student student = new Student();
            student.Info = person;
            student.AddTests(new Test { Name = "Geometry", Status = true });
            student.AddExams(new Exam { NameOfDiscipline = "Algebra", Date = new DateTime(2020, 11, 1), Mark = 4 });
            student.GroupNumber = 411;
            student.FormatOfEducation = Education.SecondEducation;
            student.GroupNumber = 502;
            Person person_1 = new Person("Mark", "Arnest", new DateTime(1991, 5, 8));
            Exam exam_2 = new Exam();
            Student student_2 = new Student();
            student_2.Info = person_1;
            student_2.AddTests(new Test { Name = "Biology", Status = false });
            student_2.AddExams(new Exam { NameOfDiscipline = "Java", Date = new DateTime(2018, 5, 8), Mark = 5 });
            student_2.GroupNumber = 412;
            student_2.FormatOfEducation = Education.Specialist;
            student_2.GroupNumber = 502;

            Console.WriteLine("Real object");
            Console.WriteLine(student.ToString());
            Console.WriteLine("Copy");
            Console.WriteLine(student.DeepCopy().ToString());

            Console.WriteLine("Введите имя файла");
            string fileName = Console.ReadLine();
            FileInfo file = new FileInfo(fileName);
            if (File.Exists(fileName))
            {
                Console.WriteLine("File exist");
                student.Load(fileName);
            }
            else
            {
                Console.WriteLine("File does not exist.");
                file.Create().Close();

            }

            Console.WriteLine("Объект, проинициализированный с помощью Load, если файл существовал");
            Console.WriteLine(student.ToString());

            student.AddFromConsole();
            student.Save(fileName);
            Console.WriteLine("Объект, в который добавлен экзамен");
            Console.WriteLine(student.ToString());

            Student.Load(fileName, student);
            student.AddFromConsole();
            Student.Save(fileName, student);

            Console.WriteLine("Финальный объект");
            Console.WriteLine(student.ToString());

        }
    }
}