using System;
using System.Collections.Generic;

namespace HashTable
{
    public class OpenAddressingHashTable<T1, T2>
    {
        private const int DEFAULT_INITIAL_SIZE = 1000;
        private const int EXPANSION_FACTOR = 10;
        private const double EXPANSION_THRESHOLD = 0.975;
        private static readonly KeyValuePair<T1, T2>? EMPTY_ENTRY = new KeyValuePair<T1, T2>(default, default);

        private KeyValuePair<T1, T2>?[] _entries;
        private int _currentSize;
        private int _totalEntries;

        public OpenAddressingHashTable(int size = DEFAULT_INITIAL_SIZE) {
            _entries = new KeyValuePair<T1, T2>?[size];
            _currentSize = size;
            _totalEntries = 0;
        }

        public void Add(T1 key, T2 value)
        {
            Add(new KeyValuePair<T1, T2>(key, value));
        }

        public void Add(KeyValuePair<T1, T2>? kvp)
        {
            var hash = Hash(kvp.GetValueOrDefault().Key);
            Add(hash, kvp);
            Increment();
        }

        private void Add(int hash, KeyValuePair<T1, T2>? kvp)
        {
            if (_entries[hash] == null)
            {
                _entries[hash] = kvp;
            }
            else
            {
                hash++;
                if (hash >= _currentSize)
                    hash = 0;
                Add(hash, kvp);
            }
        }

        public T2 Get(T1 key)
        {
            var hash = Hash(key);
            for (var i = hash; i < _currentSize - 1; i++)
            {
                var data = _entries[i];
                if (!data.HasValue)
                    return default;
                var nonNullData = data.GetValueOrDefault();
                if (nonNullData.Key?.Equals(key) == true)
                    return nonNullData.Value;
            }
            for (var i = 0; i < hash; i++)
            {
                var data = _entries[i];
                if (!data.HasValue)
                    return default;
                var nonNullData = data.GetValueOrDefault();
                if (nonNullData.Key?.Equals(key) == true)
                    return nonNullData.Value;
            }
            throw new Exception("SHOULD NOT BE FULL!");
        }

        public T2 Remove(T1 key)
        {
            var hash = Hash(key);
            for (var i = hash; i < _currentSize - 1; i++)
            {
                var data = _entries[i];
                if (!data.HasValue)
                    return default;
                var nonNullData = data.GetValueOrDefault();
                if (nonNullData.Key?.Equals(key) == true)
                    return Remove(i);
            }
            for (var i = 0; i < hash; i++)
            {
                var data = _entries[i];
                if (!data.HasValue)
                    return default;
                var nonNullData = data.GetValueOrDefault();
                if (nonNullData.Key?.Equals(key) == true)
                    return Remove(i);
            }
            throw new Exception("SHOULD NOT BE FULL!");
        }

        private T2 Remove(int hash)
        {
            var foundData = _entries[hash].GetValueOrDefault().Value;
            _entries[hash] = EMPTY_ENTRY; // Fill In with empty (not null) data.
            return foundData;
            // Don't `_totalEntries--`, like in "SeparateChaining".  Deleted data takes up space.
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
            _entries = new KeyValuePair<T1, T2>?[_currentSize];
            _totalEntries = 0;

            foreach (var entry in oldTable)
            {
                if (entry.HasValue && !entry.Value.Equals(EMPTY_ENTRY))
                {
                    Add(entry);
                }
            }
        }

    }
}
