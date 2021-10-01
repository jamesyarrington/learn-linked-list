using System;

namespace BinaryTree
{
    public class BalancedBinarySearchTree<T> : BinarySearchTree<T>
    {
        public new void Add(T newData)
        {
            var newNode = new BalancedBinarySearchNode<T>(newData);
            if (_head == null)
            {
                _head = newNode;
                return;
            } else
            {
                ((BalancedBinarySearchNode<T>)_head).Add(newNode);
            }
        }
    }

    internal class BalancedBinarySearchNode<T> : BinarySearchNode<T>, IComparable<BalancedBinarySearchNode<T>>
    {
        public BalancedBinarySearchNode(T newData) :  base(newData) { }

        public void Add(BalancedBinarySearchNode<T> newNode)
        {
            if (CompareTo(newNode) > 0)
            {
                if (HasLeft())
                {
                    var left = (BalancedBinarySearchNode<T>)GetLeft();
                    left.Add(newNode);
                    SetLeft(left.Balanced());
                } else
                {
                    SetLeft(newNode);
                }
            } else
            {
                if (HasRight())
                {
                    var right = (BalancedBinarySearchNode<T>)GetRight();
                    right.Add(newNode);
                    SetRight(right.Balanced());
                }
                else
                {
                    SetRight(newNode);
                }
            }
        }

        public int CompareTo(BalancedBinarySearchNode<T> that)
        {
            return (Data as IComparable).CompareTo(that.Data as IComparable);
        }

        private BalancedBinarySearchNode<T> Balanced()
        {
            var balance = LeftDepth() -  RightDepth();
            if (balance > 1)
            {
                var centerEdge = GetLeft().RightEdge(); // log(n)
                var edgeLength = centerEdge.Count;
                var newHead = centerEdge[0];
                if (edgeLength > 1 & centerEdge[1].HasRight()) {
                    newHead = centerEdge[1].GetRight();
                    centerEdge[1].SetRight(null);
                } else
                {
                    SetRight(null);
                }
                SetLeft(null);
                newHead.SetRight(this);

                if (edgeLength > 1)
                {
                    ((BalancedBinarySearchNode<T>)newHead).Add((BalancedBinarySearchNode<T>)centerEdge[edgeLength - 1]);
                }
                return (BalancedBinarySearchNode<T>)newHead;
            }
            if (balance < -1)
            {
                var centerEdge = GetRight().LeftEdge();
                var edgeLength = centerEdge.Count;
                var newHead = centerEdge[0];
                if (centerEdge.Count > 1 & centerEdge[1].HasLeft())
                {
                    newHead = centerEdge[1].GetLeft();
                    centerEdge[1].SetLeft(null);
                }
                else
                {
                    SetLeft(null);
                }
                SetRight(null);
                newHead.SetLeft(this);

                if (edgeLength > 1)
                {
                    ((BalancedBinarySearchNode<T>)newHead).Add((BalancedBinarySearchNode<T>)centerEdge[edgeLength - 1]);
                }
                return (BalancedBinarySearchNode<T>)newHead;
            }
            return this;
        }
    }
}
