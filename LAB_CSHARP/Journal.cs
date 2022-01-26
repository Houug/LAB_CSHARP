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

        public Journal(StudentCollection<string> _studentCollection)
        {
            _studentCollection.StudentsChanged += AddLog;
        }
        private void AddLog(object sender, StudentsChangedEventArgs<string> eventArgs)
        {
            _journalEntries.Add(new JournalEntry(eventArgs.CollectionName, eventArgs.Action, eventArgs.PropertyName, eventArgs.Index));
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (JournalEntry journalEntry in _journalEntries)
            {
                result += journalEntry.ToString();
            }
            return result;
        }
    }
}
