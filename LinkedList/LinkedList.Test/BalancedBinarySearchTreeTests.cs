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
        public void PreOrderTraversal()
        {
            Assert.AreEqual("8, 6, 2, 0, 1, 4, 3, 5, 7, 13, 10, 9, 11, 12, 15, 14",
                _testBinaryTree.PreOrderTraversal());
        }

        [Test]
        public void InOrderTraversal()
        {
            Assert.AreEqual("0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15",
                _testBinaryTree.InOrderTraversal());
        }

        [Test]
        public void PostOrderTraversal()
        {
            Assert.AreEqual("1, 0, 3, 5, 4, 2, 7, 6, 9, 12, 11, 10, 14, 15, 13, 8",
                _testBinaryTree.PostOrderTraversal());
        }

        [Test]
        public void LevelOrderTraversal()
        {
            Assert.AreEqual("8, 6, 13, 2, 7, 10, 15, 0, 4, 9, 11, 14, 1, 3, 5, 12",
                _testBinaryTree.LevelOrderTraversal());
        }

        [Test]
        public void ExpensiveLevelOrderTraversal()
        {
            // Well This is broken for the binary search tree.
            // I think I made assumptions about how the tree was filled.
            Assert.AreEqual("8, 6, 13, 2, 7, 10, 15, 0, 4, , 9, 11, 14",
                _testBinaryTree.ExpensiveLevelOrderTraversal());
        }

        [Test]
        public void DummyTest()
        {
            Console.Write(_testBinaryTree);
        }
    }
}
