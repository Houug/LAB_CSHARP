using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    public class StudentEnumerator : IEnumerator
    {
        private string[] _array;
        private int _position = -1;

        public StudentEnumerator(Student student)
        {
            foreach (Exam i in student.PassedExams)
            {
                foreach (Test j in student.PassedTests)
                {
                    if (j.Name == i.NameOfDiscipline)
                    {
                        string[] temp;
                        if (_array == null)
                        {
                            temp = new string[1];
                            temp[0] = j.Name;
                        }
                        else
                        {
                            temp = new string[_array.Length + 1];

                            for (int k = 0; k < _array.Length; k++)
                            {
                                temp[k] = _array[k];
                            }
                            temp[_array.Length] = j.Name;
                        }
                        
                        
                        _array = temp;
                    }
                    
                }
            }   
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _array.Length);
        }
            
        public void Reset()
        {
            _position = -1;
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
                    return _array[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
