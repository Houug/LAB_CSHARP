using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    public class StudentsChangedEventArgs<TKey> : EventArgs
    {
        public string CollectionName { get; set; }
        public Action Action { get; set; }
        public string PropertyName { get; set; }
        public TKey Index { get; set; }
        public StudentsChangedEventArgs(string _collectionName, Action _action, string _propertyName, TKey _index)
        {
            CollectionName = _collectionName;
            Action = _action;
            PropertyName = _propertyName;
            Index = _index;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", CollectionName, Action, PropertyName, Index);
        }
    }
}
