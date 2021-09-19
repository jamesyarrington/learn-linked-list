using BinaryTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Test
{
    class BinaryTreeTests
    {
        private BinaryTree<int> _testBinaryTree;

        [SetUp]
        public void Setup()
        {
            _testBinaryTree = new BinaryTree<int>();
            for (var i = 1; i < 16; i++)
            {
                _testBinaryTree.Add(i);
            }
        }

        [Test]
        public void PreeOrderTraversal()
        {
            Assert.AreEqual("1, 2, 4, 8, 9, 5, 10, 11, 3, 6, 12, 13, 7, 14, 15",
                _testBinaryTree.PreOrderTraversal());
        }

        [Test]
        public void InOrderTraversal()
        {
            Assert.AreEqual("8, 4, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15",
                _testBinaryTree.InOrderTraversal());
        }

        [Test]
        public void PostOrderTraversal()
        {
            Assert.AreEqual("8, 9, 4, 10, 11, 5, 2, 12, 13, 6, 14, 15, 7, 3, 1",
                _testBinaryTree.PostOrderTraversal());
        }

        [Test]
        public void DummyTest()
        {
            var kholinFamilyTree = new BinaryTree<string>();
            kholinFamilyTree.Add("1");
            kholinFamilyTree.Add("2");
            kholinFamilyTree.Add("3");
            kholinFamilyTree.Add("4");
            kholinFamilyTree.Add("5");
            kholinFamilyTree.Add("6");
            kholinFamilyTree.Add("7");
            kholinFamilyTree.Add("8");
            kholinFamilyTree.Add("9");
            kholinFamilyTree.Add("10");
            kholinFamilyTree.Add("11");
            kholinFamilyTree.Add("12");
            kholinFamilyTree.Add("13");
            kholinFamilyTree.Add("14");
            kholinFamilyTree.Add("15");

            Console.Write(kholinFamilyTree);
        }
    }
}
