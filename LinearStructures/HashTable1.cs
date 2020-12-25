using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinearStructures
{
    public class HashTable1
    {
        private Entry[] _entries;
        private int _count;

        public HashTable1(int size)
        {
            _entries = new Entry[size];
        }

        public void Put(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.Value = value;
                return;
            }

            if (IsFull())
                throw new InvalidOperationException("The HashTable is full.");

            _entries[GetIndex(key)] = new Entry { Key = key, Value = value };
            _count++;
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);

            return entry != null ? entry.Value : null;
        }

        public void Remove(int key)
        {
            var index = GetIndex(key);
            if (index == -1 || _entries[index] == null)
                return;

            _entries[index] = null;
            _count--;
        }

        public int Size()
        {
            return _count;
        }

        private Entry GetEntry(int key)
        {
            var index = GetIndex(key);
            return index >= 0 ? _entries[index] : null;
        }

        private int GetIndex(int key)
        {
            int steps = 0;

            while (steps < _entries.Length)
            {
                var index = Index(key, steps++);
                var entry = _entries[index];
                if (entry == null || entry.Key == key)
                    return index;
            }

            return -1;
        }

        private int Index(int key, int i)
        {
            return (Hash(key) + i) % _entries.Length;
        }

        private int Hash(int key)
        {
            return key % _entries.Length;
        }

        private bool IsFull()
        {
            return _count == _entries.Length;
        }

        private class Entry
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }
    }
}
