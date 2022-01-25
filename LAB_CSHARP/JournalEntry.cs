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
        public string ChangeType { get; set; }
        public string StudentInfo { get; set; }

        public JournalEntry(string _collectionName, string _changeType, string _studentInfo)
        {
            CollectionName = _collectionName;
            ChangeType = _changeType;
            StudentInfo = _studentInfo;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", CollectionName, ChangeType, StudentInfo);
        }
    }
}
