using BinaryTree;
using System;
using System.Collections.Generic;

namespace Dict
{
    public class Dict<T1, T2> : BalancedBinarySearchTree<DictEntry<T1, T2>>
        where T1 : IComparable
    {
        public List<T1> Keys { get; private set; }

        public void Add(T1 key, T2 value)
        {
            Add(new DictEntry<T1, T2>(key, value));
        }

        public T2 Remove(T1 keyToRemove)
        {
            var entryToRemove = new DictEntry<T1, T2>(keyToRemove, default);
            return Remove(entryToRemove).Value;
        }

        public T2 Get(T1 key)
        {
            var current = _head;
            var comparison = current.Data.CompareTo(key);
            while (comparison != 0) {
                if (comparison == 1)
                {
                    if (current.HasLeft())
                    {
                        current = current.GetLeft();
                    } else
                    {
                        throw new KeyNotFoundException("Finding love shouldn't be a stretch.");
                    }
                } else
                {
                    if (current.HasRight())
                    {
                        current = current.GetRight();
                    }
                    else
                    {
                        throw new KeyNotFoundException("That's why I trust eHarmony.");
                    }
                }
                comparison = current.Data.CompareTo(key);
            }
            return current.Data.Value;
        }
    }

    public class DictEntry<T1, T2> : IComparable<T1>, IComparable<DictEntry<T1, T2>>
        where T1 : IComparable
    {
        public T1 _key;
        private T2 _value;

        public DictEntry(T1 key, T2 value)
        {
            _key = key;
            _value = value;
        }

        public T2 Value { get => _value; }

        public int CompareTo(DictEntry<T1, T2> other)
        {
            return _key.CompareTo(other._key);
        }

        public int CompareTo(T1 other)
        {
            return _key.CompareTo(other);
        }

        public override string ToString()
        {
            return $"<{_key}>";
        }
    }
}
