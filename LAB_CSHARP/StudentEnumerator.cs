using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    class StudentEnumerator : IEnumerator
    {
        private string[] array;
        private int position = -1;

        public StudentEnumerator(Student student)
        {
            string[] temp;
            foreach (Exem i in student.PassedExems)
            {
                foreach (Test j in student.PassedTests)
                {
                    if (j.Name == i.NameOfDiscipline)
                    {
                        if (array == null)
                        {
                            temp = new string[1];
                            temp[0] = j.Name;
                        }
                        else
                        {
                            temp = new string[array.Length + 1];

                            for (int k = 0; k < array.Length; k++)
                            {
                                temp[k] = array[k];
                            }
                            temp[array.Length] = j.Name;
                        }
                        
                        
                        array = temp;
                    }
                    
                }
            }   
        }

        public bool MoveNext()
        {
            position++;
            return (position < array.Length);
        }
            
        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public object Current
        {
            get
            {
                try
                {
                    return array[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
