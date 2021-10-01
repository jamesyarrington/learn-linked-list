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
