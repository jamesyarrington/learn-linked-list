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
        private ArrayList<string> _sevenElementArrayList;

        private readonly string _firstString = "uno";
        private readonly string _secondString = "dos";
        private readonly string _thirdString = "tres";
        private readonly string _fourthString = "cuatro"; // quatro?
        private readonly string _fifthString = "cinco";
        private readonly string _sixthString = "seis";
        private readonly string _seventhString = "siete"; // really, I thought I knew how to spell these
        private readonly string _stringToAdd = "mas";

        [SetUp]
        public void Setup()
        {
            _emptyArrayList = new ArrayList<string>();
            _oneElementArrayList = new ArrayList<string>(new[] { _firstString });
            _threeElementArrayList = new ArrayList<string>(
                new[] { _firstString, _secondString, _thirdString });
            _sevenElementArrayList = new ArrayList<string>(
                new[] { _firstString, _secondString, _thirdString, _fourthString, _fifthString, _sixthString, _seventhString });
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
        public void Remove_OutOfRange_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.Remove(3));
        }

        [Test]
        public void RemoveBadOrder_Start_RemovesElement()
        {
            _threeElementArrayList.RemoveBadOrder(0);
            Assert.AreEqual(2, _threeElementArrayList.Length);
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.Get(2));
            Assert.IsTrue(_threeElementArrayList.Get(0) == _secondString || _threeElementArrayList.Get(0) == _thirdString);
            Assert.IsTrue(_threeElementArrayList.Get(1) == _secondString || _threeElementArrayList.Get(1) == _thirdString);
            Assert.AreEqual(_secondString, _threeElementArrayList.Get(0));
            Assert.AreEqual(_thirdString, _threeElementArrayList.Get(1));
        }

        [Test]
        public void RemoveBadOrder_End_RemovesElement()
        {
            _threeElementArrayList.RemoveBadOrder(2);
            Assert.AreEqual(_firstString, _threeElementArrayList.Get(0));
            Assert.AreEqual(_secondString, _threeElementArrayList.Get(1));
            Assert.AreEqual(2, _threeElementArrayList.Length);
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.Get(2));
            Assert.IsTrue(_threeElementArrayList.Get(0) == _secondString || _threeElementArrayList.Get(0) == _firstString);
            Assert.IsTrue(_threeElementArrayList.Get(1) == _secondString || _threeElementArrayList.Get(1) == _firstString);
        }

        [Test]
        public void RemoveBadOrder_Middle_RemovesElement()
        {
            _threeElementArrayList.RemoveBadOrder(1);
            Assert.AreEqual(_firstString, _threeElementArrayList.Get(0));
            Assert.AreEqual(_thirdString, _threeElementArrayList.Get(1));
            Assert.AreEqual(2, _threeElementArrayList.Length);
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.Get(2));
            Assert.IsTrue(_threeElementArrayList.Get(0) == _thirdString || _threeElementArrayList.Get(0) == _firstString);
            Assert.IsTrue(_threeElementArrayList.Get(1) == _thirdString || _threeElementArrayList.Get(1) == _firstString);
        }

        [Test]
        public void RemoveBadOrder_BigOne_RemovesElement()
        {
            _sevenElementArrayList.RemoveBadOrder(1);
            Assert.AreEqual(_firstString, _sevenElementArrayList.Get(0));
            Assert.AreEqual(_thirdString, _sevenElementArrayList.Get(1));
            Assert.AreEqual(_fourthString, _sevenElementArrayList.Get(2));
            Assert.AreEqual(_fifthString, _sevenElementArrayList.Get(3));
            Assert.AreEqual(_sixthString, _sevenElementArrayList.Get(4));
            Assert.AreEqual(_seventhString, _sevenElementArrayList.Get(5));
            Assert.AreEqual(6, _sevenElementArrayList.Length);
            Assert.Throws<ArgumentOutOfRangeException>(() => _sevenElementArrayList.Get(6));
        }

        [Test]
        public void RemoveBadOrder_OutOfRange_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _threeElementArrayList.RemoveBadOrder(3));
        }
    }
}
