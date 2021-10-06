using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class MaxHeap<T> : BinaryTree<T>
    {


        public new void Add(T data)
        {
            var nodeToAdd = new Node<T>(data);
            if (_head == null)
            {
                _head = nodeToAdd;
                return;
            }
            var parentage = _head.Add(nodeToAdd);
            for (var i = 1; i < parentage.Count; i++)
            {
                var child = parentage[i - 1];
                var parent = parentage[i];
                if (parent.CompareTo(child) < 0)
                {
                    var swap = child.Data;
                    child.Data = parent.Data;
                    parent.Data = swap;
                } else
                {
                    break;
                }
            }
        }
    }
}
