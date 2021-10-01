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
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(6);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(13);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(10);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(2);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(4); // Here
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(0);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(11);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(9);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(12);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(15);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(5);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(1);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(14);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(7);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
            _testBinaryTree.Add(3);
            Console.Write(_testBinaryTree);
            Console.Write(Environment.NewLine);
            Console.Write("...");
            Console.Write(Environment.NewLine);
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
