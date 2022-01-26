using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }
        public Action Action { get; set; }
        public string PropertyName { get; set; }
        public string ChangedKey { get; set; }
        public JournalEntry(string _collectionName, Action _action, string _propertyName, string _changedKey)
        {
            CollectionName = _collectionName;
            Action = _action;
            PropertyName = _propertyName;
            ChangedKey = _changedKey;
        }
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", CollectionName, Action, PropertyName, ChangedKey);
        }
    }
}
