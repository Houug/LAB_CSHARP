using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_CSHARP
{
    public delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);
    public class StudentsChangedEventArgs<TKey> : EventArgs
    {
        public string Name { get; set; }
        public Action Action { get; set; }

        public string PropertyName { get; set; }

        public TKey Index { get; set; }
        public StudentsChangedEventArgs(string name, Action action, string propertyName, TKey index)
        {
            Name = name;
            Action = action;
            PropertyName = propertyName;
            Index = index;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.Name, this.Action, this.PropertyName, this.Index);
        }

    }
}