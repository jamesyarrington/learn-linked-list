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
                var newHeadsParent = GetLeft().PenultimateRight();
                var newHead = newHeadsParent;
                if (newHeadsParent.HasRight()) {
                    newHead = newHeadsParent.GetRight();
                    newHeadsParent.SetRight(null);
                } else
                {
                    SetRight(null);
                }
                var oldLeft = GetLeft();
                SetLeft(null);

                // SO MUCH HACK
                if (this != newHead)
                    newHead.SetRight(this);

                if (oldLeft.GetRight() == newHead)
                {
                    oldLeft.SetRight(null);
                    newHead.Add(oldLeft);
                }
                else if (newHead != oldLeft)
                {
                    newHead.Add(oldLeft);
                }
                return (BalancedBinarySearchNode<T>)newHead;
            }
            if (balance < -1)
            {
                var newHeadsParent = GetRight().PenultimateLeft();
                var newHead = newHeadsParent;
                if (newHeadsParent.HasLeft())
                {
                    newHead = newHeadsParent.GetLeft();
                    newHeadsParent.SetLeft(null);
                }
                else
                {
                    SetLeft(null);
                }
                var oldRight = GetRight();
                SetRight(null);

                // SO MUCH HACK
                if (newHead != this)
                    newHead.SetLeft(this);

                if (oldRight.GetLeft() == newHead)
                {
                    oldRight.SetLeft(null);
                    newHead.Add(oldRight);
                }
                else if (newHead != oldRight)
                {
                    newHead.Add(oldRight);
                }
                return (BalancedBinarySearchNode<T>)newHead;
            }
            return this;
        }
    }
}
