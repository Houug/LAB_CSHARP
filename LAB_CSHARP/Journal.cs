using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_CSHARP
{
    public class Journal
    {
        private List<JournalEntry> _journalEntries = new List<JournalEntry>();
        public Journal(StudentCollection _studentCollection)
        {
            _studentCollection.StudentsCountChanged += AddLog;
            _studentCollection.StudentReferenceChanged += AddLog;
        }
        private void AddLog(object source, StudentListHandlerEventArgs args)
        {
            _journalEntries.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.ChangedObject.ToString()));
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (JournalEntry entry in _journalEntries)
            {
                result += string.Format("{0},{1},{2}\n", entry.CollectionName, entry.ChangeType, entry.StudentInfo);
            }
            return result;
        }

    }
}
