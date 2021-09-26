using System;

namespace BinaryTree
{
    public class BinarySearchTree<T> : BinaryTree<T>
    {
        public new void Add(T newData)
        {
            var newNode = new BinarySearchNode<T>(newData);
            if (_head == null)
            {
                _head = newNode;
                return;
            } else
            {
                ((BinarySearchNode<T>)_head).Add(newNode);
            }
        }
    }

    internal class BinarySearchNode<T> : Node<T>, IComparable<BinarySearchNode<T>>
    {
        public BinarySearchNode(T newData) :  base(newData) { }

        public void Add(BinarySearchNode<T> newNode)
        {
            if (CompareTo(newNode) > 0)
            {
                if (HasLeft())
                {
                    ((BinarySearchNode<T>)GetLeft()).Add(newNode);
                } else
                {
                    SetLeft(newNode);
                }
            } else
            {
                if (HasRight())
                {
                    ((BinarySearchNode<T>)GetRight()).Add(newNode);
                }
                else
                {
                    SetRight(newNode);
                }
            }
        }

        public int CompareTo(BinarySearchNode<T> that)
        {
            return (Data as IComparable).CompareTo(that.Data as IComparable);
        }
    }
}
