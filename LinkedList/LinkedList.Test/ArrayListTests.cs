using ArrayList;
using NUnit.Framework;
using System;

namespace LinkedList.Test
{
    public class ArrayListTests
    {
        private ArrayList<string> _emptyArrayList;
        private ArrayList<string> _oneElementArrayList;
        private ArrayList<string> _threeElementArrayList;

        private readonly string _firstString = "hgddgjl'" +
            "lkup[[oi";
        private readonly string _secondString = "tyi[[kmhkljj.";
        private readonly string _thirdString = "rtuop;;;;";
        private readonly string _stringToAdd = "new_value";

        [SetUp]
        public void Setup()
        {
            _emptyArrayList = new ArrayList<string>();
            _oneElementArrayList = new ArrayList<string>(new[] { _firstString });
            _threeElementArrayList = new ArrayList<string>(
                new[] { _firstString, _secondString, _thirdString });

        }

        [Test]
        public void Get_InRange_ReturnsElement()
        {
            Assert.AreEqual(_secondString, _threeElementArrayList.Get(1));
        }

        [Test]
        public void Get_OutOfRange_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.Get(3));
        }

        [Test]
        public void Add_AddsElementToArrayList()
        {
            _threeElementArrayList.Add(_stringToAdd);
            Assert.AreEqual(_stringToAdd, _threeElementArrayList.Get(3));
            Assert.AreEqual(_firstString, _threeElementArrayList.Get(0));
            Assert.AreEqual(_secondString, _threeElementArrayList.Get(1));
            Assert.AreEqual(_thirdString, _threeElementArrayList.Get(2));
        }

        [Test]
        public void Remove_Start_RemovesElement()
        {
            _threeElementArrayList.Remove(0);
            Assert.AreEqual(_secondString, _threeElementArrayList.Get(0));
            Assert.AreEqual(_thirdString, _threeElementArrayList.Get(1));
            Assert.AreEqual(2, _threeElementArrayList.Length);
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.Get(2));
        }

        [Test]
        public void Remove_End_RemovesElement()
        {
            _threeElementArrayList.Remove(2);
            Assert.AreEqual(_firstString, _threeElementArrayList.Get(0));
            Assert.AreEqual(_secondString, _threeElementArrayList.Get(1));
            Assert.AreEqual(2, _threeElementArrayList.Length);
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.Get(2));
        }

        [Test]
        public void Remove_Middle_RemovesElement()
        {
            _threeElementArrayList.Remove(1);
            Assert.AreEqual(_firstString, _threeElementArrayList.Get(0));
            Assert.AreEqual(_thirdString, _threeElementArrayList.Get(1));
            Assert.AreEqual(2, _threeElementArrayList.Length);
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.Get(2));
        }

        [Test]
        public void Remove_OutOfRange_ThrowsAndDoesNotModify()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.Get(3));
        }
    }
}
