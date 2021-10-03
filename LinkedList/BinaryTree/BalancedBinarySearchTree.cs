using System;
using System.Collections.Generic;

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
                _head = ((BalancedBinarySearchNode<T>)_head).Balanced();
            }
        }

        public T Remove(T toRemove)
        {
            if (_head == null)
                throw new KeyNotFoundException();

            var found = ((BalancedBinarySearchNode<T>)_head).Remove(toRemove);
            _head = ((BalancedBinarySearchNode<T>)_head).Balanced();
            return found;
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

        public T Remove(T toRemove)
        {
            var selfComparison = CompareTo(toRemove); // Should not be 0;
            var leftComparison = 1;
            var rightComparison = -1;
            BalancedBinarySearchNode<T> left = null;
            BalancedBinarySearchNode<T> right = null;
            T found = default(T);

            if (HasLeft())
            {
                left = (BalancedBinarySearchNode<T>)GetLeft();
                leftComparison = left.CompareTo(toRemove);
            }
            if (HasRight())
            {
                right = (BalancedBinarySearchNode<T>)GetRight();
                rightComparison = right.CompareTo(toRemove);
            }
            var childComparisonTotal = leftComparison + rightComparison + selfComparison;
            switch (childComparisonTotal)
            {
                case 3: // Less than Left Node.
                case 1: // Greater than Left Node.
                    found = left.Remove(toRemove);
                    SetLeft(left.Balanced());
                    return found;
                case 2: // Equal to Left Node.
                    found = left.Data;
                    BalancedBinarySearchNode<T> newLeft = null;
                    if (left.HasLeft())
                    {
                        newLeft = (BalancedBinarySearchNode<T>)left.GetLeft();
                        if (left.HasRight())
                        {
                            newLeft.Add((BalancedBinarySearchNode<T>)left.GetRight());
                            newLeft = newLeft.Balanced();
                        }
                    } else if(left.HasRight())
                    {
                        newLeft = (BalancedBinarySearchNode<T>)left.GetRight();
                    }
                    SetLeft(newLeft);
                    return found;
                case -1: // Less than Right Node.
                case -3: // Greater that Right Node.
                    found = right.Remove(toRemove);
                    SetRight(right.Balanced());
                    return found;
                case -2: // Equal to Right Node.
                    found = right.Data;
                    BalancedBinarySearchNode<T> newRight = null;
                    if (right.HasRight())
                    {
                        newRight = (BalancedBinarySearchNode<T>)right.GetRight();
                        if (right.HasLeft())
                        {
                            newRight.Add((BalancedBinarySearchNode<T>)right.GetLeft());
                            newRight = newRight.Balanced();
                        }
                    }
                    else if (right.HasLeft())
                    {
                        newRight = (BalancedBinarySearchNode<T>)right.GetLeft();
                    }
                    SetRight(newRight);
                    return found;
                default:
                    throw new ArgumentOutOfRangeException($"Only -3 to +3, excluding zero should be possible.  Received {childComparisonTotal}");
            }
        }

        public int CompareTo(BalancedBinarySearchNode<T> that)
        {
            return CompareTo(that.Data);
        }
        public int CompareTo(T that)
        {
            return (Data as IComparable<T>).CompareTo(that);
        }

        public BalancedBinarySearchNode<T> Balanced()
        {
            var balance = LeftDepth() -  RightDepth();
            if (balance > 1)
            {
                var centerEdge = GetLeft().RightEdge(); // log(n)
                var edgeLength = centerEdge.Count;
                var newHead = centerEdge[0];
                if (edgeLength > 1 && centerEdge[1].HasRight()) {
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
                if (centerEdge.Count > 1 && centerEdge[1].HasLeft())
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
