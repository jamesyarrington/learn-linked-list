using System;

namespace ArrayList
{
    public class ArrayList<T>
    {
        private const int EXPANSION_FACTOR = 2;
        private T[] _data;
        private int _length;

        public int Length { get => _length; }

        public ArrayList(T[] data)
        {
            _data = data;
            _length = data.Length;
        }

        public ArrayList() : this(Array.Empty<T>()) { }

        public T Get(int index)
        {
            if (index >= _length)
                throw new ArgumentOutOfRangeException($"{index} is out of range.  Length is {_length}");
            return _data[index];
        }

        public void Add(T element)
        {
            if (_length >= _data.Length)
            {
                var newData = new T[EXPANSION_FACTOR * _length];
                for (var i = 0; i < _length; i++)
                {
                    // This loop seems bad, but I'm not sure how else to create a new array with the existing array's data.
                    newData[i] = _data[i];
                }
                _data = newData;
            }
            _data[_length] = element;
            _length++;
        }

        public void Remove(int index)
        {
            if (index >= _length)
                throw new ArgumentOutOfRangeException($"{index} is out of range.  Length is {_length}");
            for (var i = index; i < _length - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _length--;
        }
    }
}
