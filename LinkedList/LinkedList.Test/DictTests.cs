using BinaryTree;
using Dict;
using NUnit.Framework;
using System;

namespace LinkedList.Test
{
    class DictTests
    {
        private Dict<string, string> _testDict;

        [SetUp]
        public void Setup()
        {
            _testDict = new Dict<string, string>();
            _testDict.Add("abc", "A Cool Test Value");
            _testDict.Add("qwe", "A Cooler Test Value");
            _testDict.Add("cvb", "A Really Cool Test Value");
            _testDict.Add("tut", "A Cool Testing Value");
            _testDict.Add("det", "Cool Test Value!");
            _testDict.Add("loi", "A Boring Test Value");
            _testDict.Add("ghj", "A C00l T3st V@lu3");
            _testDict.Add("wer", "1 Cool Test Value");
            _testDict.Add("fgh", "WHHHHHYYYYYYY?!??!");
            Console.WriteLine(_testDict);
        }

        [Test]
        public void Get_ReturnsExpectedValues()
        {
            Assert.AreEqual(_testDict.Get("abc"), "A Cool Test Value");
            Assert.AreEqual(_testDict.Get("qwe"), "A Cooler Test Value");
            Assert.AreEqual(_testDict.Get("cvb"), "A Really Cool Test Value");
            Assert.AreEqual(_testDict.Get("tut"), "A Cool Testing Value");
            Assert.AreEqual(_testDict.Get("det"), "Cool Test Value!");
            Assert.AreEqual(_testDict.Get("loi"), "A Boring Test Value");
            Assert.AreEqual(_testDict.Get("ghj"), "A C00l T3st V@lu3");
            Assert.AreEqual(_testDict.Get("wer"), "1 Cool Test Value");
            Assert.AreEqual(_testDict.Get("fgh"), "WHHHHHYYYYYYY?!??!");
        }
    }
}
