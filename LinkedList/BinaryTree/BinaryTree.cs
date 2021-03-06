using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        internal Node<T> _head;

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
            _head.Add(nodeToAdd);
        }

        public void AddRandom(T data)
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

        public string InOrderTraversal()
        {
            return _head.InOrderTraversal();
        }

        public string PreOrderTraversal()
        {
            return _head.PreOrderTraversal();
        }

        public string PostOrderTraversal()
        {
            return _head.PostOrderTraversal();
        }

        public string LevelOrderTraversal()
        {
            var output = new List<Node<T>>(_head.Depth() * ((int)Math.Log(_head.Depth() + 1)));
            output.Add(_head);
            var parsedEntries = 0;
            while (parsedEntries < output.Count)
            {
                for (var i = parsedEntries; i < output.Count; i++)
                {
                    parsedEntries++;
                    var nodeToParse = output[i];
                    if (nodeToParse.HasLeft())
                    {
                        output.Add(nodeToParse.GetLeft());
                    }
                    if (nodeToParse.HasRight())
                    {
                        output.Add(nodeToParse.GetRight());
                    }
                }
            }

            return string.Join(", ", output.Select( n => n.Data));
        }

        public string ExpensiveLevelOrderTraversal()
        {
            var output = "";
            for (var i = 0; i <= _head.Depth(); i++)
            {
                if (i > 0)
                    output += ", ";
                output += _head.PrintLevel(i);
            }

            return output;
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

        public string PreOrderTraversal()
        {
            var leftTraversal = HasLeft() ?
                 ", " + _left?.PreOrderTraversal() : "";
            var rightTraversal = HasRight() ?
                 ", " + _right?.PreOrderTraversal() : "";
            return $"{_data}{leftTraversal}{rightTraversal}";
        }

        public string InOrderTraversal()
        {
            var leftTraversal = HasLeft() ?
                 _left?.InOrderTraversal() + ", " : "";
            var rightTraversal = HasRight() ?
                 ", " + _right?.InOrderTraversal() : "";
            return $"{leftTraversal}{_data}{rightTraversal}";
        }

        public string PostOrderTraversal()
        {
            var leftTraversal = HasLeft() ?
                 _left?.PostOrderTraversal() + ", " : "";
            var rightTraversal = HasRight() ?
                _right?.PostOrderTraversal() + ", " : "";
            return $"{leftTraversal}{rightTraversal}{_data}";
        }

        public string PrintLevel(int level)
        {
            if (level <= 0)
                return _data.ToString();
            var delim = HasLeft() & HasRight() ? ", " : "";
            return $"{_left?.PrintLevel(level - 1)}{delim}{_right?.PrintLevel(level - 1)}";
        }

        public List<Node<T>> Add(Node<T> data)
        {
            if (!HasLeft())
            {
                SetLeft(data);
                return new List<Node<T>> { data, this };
            }
            if (!HasRight())
            {
                SetRight(data);
                return new List<Node<T>> { data, this };
            }
            var left = GetLeft();
            var right = GetRight();
            if (!left.IsFull() || IsFull())
            {
                // Add when both sides full, or left has space.
                var parentOrder = left.Add(data);
                parentOrder.Add(this);
                return parentOrder;
            } else
            {
                var parentOrder = right.Add(data);
                parentOrder.Add(this);
                return parentOrder;
            }

        }

        public int Depth()
        {
            return Math.Max(LeftDepth(), RightDepth());
        }

        internal int LeftDepth()
        {
            if (HasLeft())
            {
                return 1 + GetLeft().Depth();
            }
            return 0;
        }

        private bool IsFull()
        {
            if (!HasLeft() && !HasRight())
                return true;
            return GetLeft().IsFull() && HasRight() && GetRight().IsFull() && LeftDepth() == RightDepth();
        }

        internal int RightDepth()
        {
            if (HasRight())
            {
                return 1 + GetRight().Depth();
            }
            return 0;
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

        internal List<Node<T>> LeftEdge()
        {
            if (HasLeft())
            {
                var leftEdge = GetLeft().LeftEdge();
                leftEdge.Add(this);
                return leftEdge;
            }
            else
            {
                return new List<Node<T>>() { this };
            }
        }

        internal List<Node<T>> RightEdge()
        {
            if (HasRight())
            {
                var rightEdge = GetRight().RightEdge();
                rightEdge.Add(this);
                return rightEdge;
            }
            else
            {
                return new List<Node<T>>() { this };
            }
        }

        internal Node<T> PenultimateLeft()
        {
            if (!HasLeft())
                return this;
            var current = this;
            do
            {
                current = current.GetLeft();
            } while (current.HasLeft() && current.GetLeft().HasLeft());
            return current;
        }

        internal Node<T> PenultimateRight()
        {
            if (!HasRight())
                return this;
            var current = this;
            do
            {
                current = current.GetRight();
            } while (current.HasRight() && current.GetRight().HasRight());
            return current;
        }

        public int CompareTo(Node<T> that)
        {
            return (Data as IComparable).CompareTo(that.Data as IComparable);
        }
    }
}
