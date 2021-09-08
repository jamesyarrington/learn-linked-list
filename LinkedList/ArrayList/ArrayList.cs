using System;

namespace ArrayList
{
    public class ArrayList<T>
    {
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
            var newData = new T[_length + 1];
            for(var i = 0; i < _length; i++)
            {
                newData[i] = _data[i];
            }
            newData[_length] = element;
            _length++;
            _data = newData;
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
