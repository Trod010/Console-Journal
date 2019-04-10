using System;
using System.Collections.Generic;
using System.Text;

namespace Journal
{
    class Database
    {
        private List<Entry> entries;

        public Database()
        {
            entries = new List<Entry>();
        }

        public void AddEntry(DateTime occurs, string text)
        {
            entries.Add(new Entry(occurs, text));
        }

        public List<Entry> FindEntries(DateTime date, bool byTime)
        {
            List<Entry> found = new List<Entry>();
            foreach(Entry entry in entries)
            {
                if (((byTime) && (entry.Occurs == date)) // filters by date and time
                    ||
                    ((!byTime) && (entry.Occurs.Date == date.Date))) found.Add(entry); // this filters by date
            }
            return found;
        }

        public void DeleteEntries(DateTime date)
        {
            List<Entry> found = FindEntries(date, true);
            foreach (Entry entry in found)
                entries.Remove(entry);
        }
    }
}
