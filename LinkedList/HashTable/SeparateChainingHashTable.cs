using System;
using System.Collections.Generic;

namespace HashTable
{
    public class SeparateChainingHashTable<T1, T2>
    {
        private const int DEFAULT_INITIAL_SIZE = 1000;
        private const int EXPANSION_FACTOR = 10;
        private const double EXPANSION_THRESHOLD = 0.9999;

        private List<KeyValuePair<T1, T2>>[] _entries;
        private int _currentSize;
        private int _totalEntries;

        public SeparateChainingHashTable(int size = DEFAULT_INITIAL_SIZE) {
            _entries = new List<KeyValuePair<T1, T2>>[size];
            _currentSize = size;
            _totalEntries = 0;
        }

        public void Add(T1 key, T2 value)
        {
            Add(new KeyValuePair<T1, T2>(key, value));
        }

        public void Add(KeyValuePair<T1, T2> kvp)
        {
            var hash = Hash(kvp.Key);
            if (_entries[hash] == null)
            {
                _entries[hash] = new List<KeyValuePair<T1, T2>> { kvp };
            } else
            {
                _entries[hash].Add(kvp);
            }
            Increment();
        }

        public T2 Get(T1 key)
        {
            var hash = Hash(key);
            if (_entries[hash] == null)
            {
                return default;
            }
            else
            {
                foreach (var kvp in _entries[hash])
                {
                    if (key.Equals(kvp.Key))
                        return kvp.Value;
                }
                return default;
            }
        }

        public T2 Remove(T1 key)
        {
            var hash = Hash(key);
            if (_entries[hash] == null)
            {
                return default;
            }
            else
            {
                foreach (var kvp in _entries[hash])
                {
                    if (key.Equals(kvp.Key))
                    {
                        _entries[hash].Remove(kvp); // I don't care if an empty list is left.
                        _totalEntries--;
                        return kvp.Value;
                    }
                }
                return default;
            }
        }

        private void Increment()
        {
            _totalEntries++;
            if (_totalEntries > _currentSize*EXPANSION_THRESHOLD)
            {
                _currentSize = _currentSize * EXPANSION_FACTOR;
                Rehash();
            }
        }

        private int Hash(T1 key)
        {
            return Math.Abs(key.GetHashCode()) % _currentSize;
        }

        private void Rehash()
        {
            var oldTable = _entries;
            _entries = new List<KeyValuePair<T1, T2>>[_currentSize];
            _totalEntries = 0;

            foreach (var bucket in oldTable)
            {
                if (bucket?.Count > 0)
                {
                    foreach (var kvp in bucket)
                    {
                        Add(kvp);
                    }
                }
            }
        }

    }
}
