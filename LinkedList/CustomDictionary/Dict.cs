using BinaryTree;
using System;
using System.Collections.Generic;

namespace Dict
{
    public class Dict<T1, T2> : BalancedBinarySearchTree<DictEntry<T1, T2>>
        where T1 : IComparable
    {
        public List<T1> Keys { get; private set; }

        public T2 Get(T1 key)
        {
            var current = _head;
            while ()
        }
    }

    public class DictEntry<T1, T2> : IComparable<T1>, IComparable<DictEntry<T1, T2>
        where T1 : IComparable
    {
        private T1 _key;
        private T2 _value;

        public DictEntry(T1 key, T2 value)
        {
            _key = key;
            _value = value;
        }

        public int CompareTo(DictEntry<T1, T2> other)
        {
            return _key.CompareTo(other._key);
        }

        public int CompareTo(T1 other)
        {
            return _key.CompareTo(other);
        }
    }
}
