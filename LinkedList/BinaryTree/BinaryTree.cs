using System;
using System.IO;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        private Node<T> _head;

        public BinaryTree()
        {
            _head = null;
        }

        public void Add(T data)
        {
            var nodeToAdd = new Node<T>(data);
            if (_head == null)
            {
                _head = nodeToAdd;
                return;
            }
            var searchNode = _head;
            var random = new Random(DateTime.Now.Millisecond);
            while (searchNode != null)
            {
                if (searchNode.HasLeft())
                {
                    if (searchNode.HasRight())
                    {
                        // I'm sure this will change.
                        searchNode = random.Next(0, 2) == 1 ? searchNode.GetLeft() : searchNode.GetRight();
                    } else
                    {
                        searchNode.SetRight(nodeToAdd);
                        return;
                    }
                } else
                {
                    searchNode.SetLeft(nodeToAdd);
                    return;
                }
            }
        }

        public override string ToString()
        {
            return _head.ToString();
        }
    }

    internal class Node<T>
    {
        private T _data;
        private Node<T> _left;
        private Node<T> _right;

        public T Data { get => _data; set => _data = value; }

        public Node(T data)
        {
            _data = data;
        }

        public void SetRight(Node<T> node)
        {
            _right = node;
        }

        public void SetLeft(Node<T> node)
        {
            _left = node;
        }

        public Node<T> GetRight()
        {
            return _right;
        }

        public Node<T> GetLeft()
        {
            return _left;
        }

        public bool HasRight()
        {
            return _right != null;
        }

        public bool HasLeft()
        {
            return _left != null;
        }

        public override string ToString()
        {
            var leftString = _left?.ToString() ?? "";
            var rightString = _right?.ToString() ?? "";
            var thisString = $" ({_data.ToString()}) ";
            var topString = thisString;
            var arrowLine = "";
            var finalWidth = thisString.Length;
            var newWidth = thisString.Length;
            if (HasLeft() & HasRight())
            {
                newWidth = StringWidth(leftString) + StringWidth(rightString);
                var thisWidth = thisString.Length;
                var padding = (newWidth - thisWidth) / 2;
                topString = thisString.PadLeft(newWidth - padding).PadRight(newWidth);
                finalWidth = topString.Length;
                var leftLine = new string('=', (finalWidth - StringWidth(leftString)) / 2 - 1);
                var rightLine = new string('=', (finalWidth - StringWidth(rightString)) / 2);
                arrowLine = $"|{leftLine}^{rightLine}|".PadLeft(finalWidth - StringWidth(rightString) / 2 + 1).PadRight(finalWidth);
            } else if(HasLeft() | HasRight())
            {
                var nextString = leftString + rightString;
                newWidth = StringWidth(nextString);
                var thisWidth = thisString.Length;
                var padding = (newWidth - thisWidth) / 2;
                topString = thisString.PadLeft(newWidth - padding).PadRight(newWidth);
                finalWidth = topString.Length;
                arrowLine = "|".PadLeft(finalWidth / 2).PadRight(finalWidth);
            }
            
            var totalSring = $"{topString}{Environment.NewLine}{arrowLine}";
            var extraPadding = (finalWidth - newWidth) / 2;
            var extraPaddingLeft = new string(' ', extraPadding);
            var extraPaddingRight = new string(' ', finalWidth - newWidth - extraPadding);
            using (var leftReader = new StringReader(leftString))
            using (var rightReader = new StringReader(rightString))
            {
                var nextLeftLine = "";
                var nextRightLine = "";
                while (leftReader.Peek() >= 0 || rightReader.Peek() >= 0)
                {
                    nextLeftLine = leftReader.ReadLine() ??
                        new string(' ', extraPadding + StringWidth(leftString));
                    nextRightLine = rightReader.ReadLine() ??
                        new string(' ', extraPadding + StringWidth(rightString));
                    totalSring += $"{Environment.NewLine}{extraPaddingLeft}{nextLeftLine}" +
                        $"{nextRightLine}{extraPaddingRight}";
                }

            }
            return totalSring;
        }

        private int StringWidth(string leftOrRightString)
        {
            using (var reader = new StringReader(leftOrRightString))
            {
                return (reader.ReadLine() ?? "").Length;
            }
        }
    }
}
