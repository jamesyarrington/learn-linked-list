using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public LinkedList()
        {
            _head = _tail = null;
        }

        public LinkedList(ICollection<T> values)
        {
            if (values.Count < 1) throw new Exception("Placeholder.  Replace with specific exception");

            Node<T> last = null;
            Node<T> next;
            foreach (T value in values)
            {
                if (last == null)
                {
                    _head = new Node<T>(value);
                    last = _head;
                } else
                {
                    next = new Node<T>(value);
                    last.SetNext(next);
                    last = next;
                }
            }
            _tail = last;
        }

        public void AddNode(T data)
        {
            var newNode = new Node<T>(data);

            if (_tail != null)
            {
                _tail.SetNext(newNode);
            } else if (_head != null)
            {
                _head.SetNext(newNode);
            } else
            {
                _head = newNode;
            }
            _tail = newNode;
        }

        public override string ToString()
        {
            var current = _head;
            var output = _head?.ToString() ?? "";

            while (current?.HasNext() == true)
            {
                current = current.GetNext();
                output += ", " + current.ToString();
            }

            return output;
        }
    }

    internal class Node<T>
    {
        private T _data;
        private Node<T> _next;

        public T Data { get => _data; set => _data = value; }

        public Node(T data)
        {
            _data = data;
        }

        public void SetNext(Node<T> node)
        {
            _next = node;
        }

        public Node<T> GetNext()
        {
            return _next;
        }

        public bool HasNext()
        {
            return _next != null;
        }

        public override string ToString()
        {
            return _data.ToString();
        }
    }
}
