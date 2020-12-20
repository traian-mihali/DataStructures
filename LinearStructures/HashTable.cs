using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinearStructures
{
    public class HashTable
    {
        LinkedList<Entry>[] entries;

        public HashTable(int size)
        {
            entries = new LinkedList<Entry>[size];
        }
        public void Put(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.Value = value;
                return;
            }

            GetOrCreateBucket(key).AddLast(new Entry { Key = key, Value = value });
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);

            return entry != null ? entry.Value : null;
        }

        public void Remove(int key)   
        {
            var entry = GetEntry(key);
            if (entry == null)
                throw new InvalidOperationException();

            GetBucket(key).Remove(entry);
        }


        private LinkedList<Entry> GetBucket(int key)
        {
            return entries[Hash(key)];
        }

        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            var index = Hash(key);
            if (entries[index] == null)
                entries[index] = new LinkedList<Entry>();

            return entries[index];
        }

        private Entry GetEntry(int key)
        {
            var bucket = GetBucket(key);
            if (bucket != null)
            {
                foreach (Entry entry in bucket)
                {
                    if (entry.Key == key)
                        return entry;
                }
            }

            return null;
        }

        private int Hash(int key)
        {
            return key % entries.Length;
        }

        private class Entry
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }
    }
}
