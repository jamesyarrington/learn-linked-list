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

        public void AddNode(Node<T> node)
        {

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
}
