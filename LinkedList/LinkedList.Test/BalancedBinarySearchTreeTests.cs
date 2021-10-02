using BinaryTree;
using NUnit.Framework;
using System;

namespace LinkedList.Test
{
    class BalancedBinarySearchTreeTests
    {
        private BalancedBinarySearchTree<int> _testBinaryTree;

        [SetUp]
        public void Setup()
        {
            _testBinaryTree = new BalancedBinarySearchTree<int>();
            _testBinaryTree.Add(8);
            _testBinaryTree.Add(6);
            _testBinaryTree.Add(13);
            _testBinaryTree.Add(10);
            _testBinaryTree.Add(2);
            _testBinaryTree.Add(4);
            _testBinaryTree.Add(0);
            _testBinaryTree.Add(11);
            _testBinaryTree.Add(9);
            _testBinaryTree.Add(12);
            _testBinaryTree.Add(15);
            _testBinaryTree.Add(5);
            _testBinaryTree.Add(1);
            _testBinaryTree.Add(14);
            _testBinaryTree.Add(7);
            _testBinaryTree.Add(3);
        }

        [Test]
        public void InOrderTraversal()
        {
            Assert.AreEqual("0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15",
                _testBinaryTree.InOrderTraversal());
        }

        [Test]
        public void DummyTest()
        {
            Console.Write(_testBinaryTree);
        }
    }
}
