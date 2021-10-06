using BinaryTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Test
{
    class MaxHeapTests
    {
        private MaxHeap<int> _testMaxHeap;

        [SetUp]
        public void Setup()
        {
            _testMaxHeap = new MaxHeap<int>();
            for (var i = 1; i < 34; i++)
            {
                _testMaxHeap.Add(i);
            }

            Console.WriteLine(_testMaxHeap);
        }

        [Test]
        public void DummyTest()
        {
            var kholinFamilyTree = new MaxHeap<string>();
            kholinFamilyTree.Add("1");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("2");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("3");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("4");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("5");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("6");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("7");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("8");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("9");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("10");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("11");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("12");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("13");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("14");
            Console.WriteLine(kholinFamilyTree);
            Console.WriteLine("____________");
            kholinFamilyTree.Add("15");
            Console.WriteLine(kholinFamilyTree);
        }
    }
}
