using System;
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
            // 1
            Console.WriteLine("1 ==================");
            TestCollections testCollections;
            Int32 size;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите положительное число: ");
                    size = Convert.ToInt32(Console.ReadLine());
                    testCollections = new TestCollections(size);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var firstElement = testCollections.DictionaryPersonStudent.First().Value;
            var lastElement = testCollections.DictionaryPersonStudent.Last().Value;
            var middleElement = testCollections.DictionaryPersonStudent.ElementAt(size / 2).Value;
            var outsideElement = new Student();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            Console.WriteLine("Листы");
            Console.WriteLine("\nFirstElement");
            stopwatch.Restart();
            testCollections.ListPerson.Contains(firstElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.ListString.Contains(firstElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nLastElement");
            stopwatch.Restart();
            testCollections.ListPerson.Contains(lastElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.ListString.Contains(lastElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            Console.WriteLine("\nMiddleElement");
            stopwatch.Restart();
            testCollections.ListPerson.Contains(middleElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.ListString.Contains(middleElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nOutsideElement");
            stopwatch.Restart();
            testCollections.ListPerson.Contains(outsideElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.ListString.Contains(outsideElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("Словари Key");
            Console.WriteLine("\nFirstElement");
            stopwatch.Restart();
            testCollections.DictionaryPersonStudent.ContainsKey(firstElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.DictionaryStringStudent.ContainsKey(firstElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nLastElement");
            stopwatch.Restart();
            testCollections.DictionaryPersonStudent.ContainsKey(lastElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.DictionaryStringStudent.ContainsKey(lastElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            Console.WriteLine("\nMiddleElement");
            stopwatch.Restart();
            testCollections.DictionaryPersonStudent.ContainsKey(middleElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.DictionaryStringStudent.ContainsKey(middleElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nOutsideElement");
            stopwatch.Restart();
            testCollections.DictionaryPersonStudent.ContainsKey(outsideElement.Info);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.DictionaryStringStudent.ContainsKey(outsideElement.Info.ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("Словари Value");
            Console.WriteLine("\nFirstElement");
            stopwatch.Restart();
            testCollections.DictionaryPersonStudent.ContainsValue(firstElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.DictionaryStringStudent.ContainsValue(firstElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nLastElement");
            stopwatch.Restart();
            testCollections.DictionaryPersonStudent.ContainsValue(lastElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.DictionaryStringStudent.ContainsValue(lastElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            Console.WriteLine("\nMiddleElement");
            stopwatch.Restart();
            testCollections.DictionaryPersonStudent.ContainsValue(middleElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.DictionaryStringStudent.ContainsValue(middleElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("\nOutsideElement");
            stopwatch.Restart();
            testCollections.DictionaryPersonStudent.ContainsValue(outsideElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            testCollections.DictionaryStringStudent.ContainsValue(outsideElement);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            Console.WriteLine("2 ==================");
        }
    }
}