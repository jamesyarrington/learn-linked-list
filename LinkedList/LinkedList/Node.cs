namespace LinkedList
{
    public class Node<T>
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
