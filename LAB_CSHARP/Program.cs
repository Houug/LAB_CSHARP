﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace LAB_CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection<string> col1 = new StudentCollection<string>(delegate (Student s)
            {
                return s.Info.Name.GetHashCode().ToString();
            });
            StudentCollection<string> col2 = new StudentCollection<string>(delegate (Student s)
            {
                return s.Info.Name.GetHashCode().ToString();
            });

            Journal j1 = new Journal(col1);
            Journal j2 = new Journal(col2);
            Student[] students =
            {
                new Student(new Person("Vova", "Popov", new DateTime()), Education.Specialist, 201),
                new Student(new Person("Ed", "Mapov", new DateTime(2000,9,7)), Education.Specialist, 201),
                new Student(new Person("Jora", "Durov", new DateTime()), Education.Specialist, 201),
                new Student(new Person("Mira", "Wolow", new DateTime()), Education.Вachelor, 103),
                new Student(new Person("Dora", "True", new DateTime()), Education.Specialist, 103),
                new Student(new Person("Artem", "Popov", new DateTime()), Education.Specialist, 201)
            };
            col1.AddStudents(students);
            col2.AddStudents(students);

            col1.Remove(new Student(new Person("Vova", "Popov", new DateTime()), Education.Specialist, 201));
            col2.AddDefaults();

            Console.WriteLine(j1.ToString());
            Console.WriteLine(j2.ToString());
            Console.ReadKey();
        }
    }
}