using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    public class StudentListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public Student ChangedObject { get; set; }

        public StudentListHandlerEventArgs(string _collectionName, string _changeType, Student _changedObject)
        {
            ChangedObject = _changedObject;
            CollectionName = _collectionName;
            ChangeType = _changeType;
        }
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", CollectionName, ChangeType, ChangedObject.ToString());
        }
    }
}
