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

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DummyTest()
        {
            var kholinFamilyTree = new BinaryTree<string>();
            kholinFamilyTree.Add("Dalinar");
            kholinFamilyTree.Add("Gavilar");
            kholinFamilyTree.Add("Jasnah");
            kholinFamilyTree.Add("Elhokar");
            kholinFamilyTree.Add("Navani");
            kholinFamilyTree.Add("Adolin");
            kholinFamilyTree.Add("Renarin");
            kholinFamilyTree.Add("Kaladin <Adopted>");
            kholinFamilyTree.Add("Shallan");

            Console.Write(kholinFamilyTree);
        }
    }
}
