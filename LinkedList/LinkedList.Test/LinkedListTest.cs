using NUnit.Framework;

namespace LinkedList.Test
{
    public class LinkedListTests
    {
        private LinkedList<string> _empty_LinkedList;
        private LinkedList<string> _oneElement_LinkedList;
        private LinkedList<string> _twoElement_LinkedList;
        private LinkedList<string> _threeElement_LinkedList;

        private readonly string _firstElement = "first";
        private readonly string _secondElement = "2nd";
        private readonly string _thirdElement = "THIRD";
        private readonly string _newElement = "NNNNEEEEWWWW!!!!";

        [SetUp]
        public void Setup()
        {
            _empty_LinkedList = new LinkedList<string>();
            _oneElement_LinkedList = new LinkedList<string>(
                new[] { _firstElement });
            _twoElement_LinkedList = new LinkedList<string>(
                new[] { _firstElement, _secondElement });
            _threeElement_LinkedList = new LinkedList<string>(
                new[] { _firstElement, _secondElement, _thirdElement });
        }

        [Test]
        public void ToString_EmptyLinkedList_EmptyString()
        {
            Assert.IsEmpty(_empty_LinkedList.ToString());
        }

        [Test]
        public void ToString_OneElementLinkedList_ReturnsElementsString()
        {
            Assert.AreEqual(_firstElement, _oneElement_LinkedList.ToString());
        }

        [Test]
        public void ToString_TwoElementLinkedList_ReturnsCommaSeparatedString()
        {
            var expectedOutput = $"{_firstElement}, {_secondElement}";
            Assert.AreEqual(expectedOutput, _twoElement_LinkedList.ToString());
        }

        [Test]
        public void ToString_ThreeElementLinkedList_ReturnsCommaSeparatedString()
        {
            var expectedOutput = $"{_firstElement}, {_secondElement}, {_thirdElement}";
            Assert.AreEqual(expectedOutput, _threeElement_LinkedList.ToString());
        }

        [Test]
        public void AddNode_ToEmptyLinkedList_ToString_ReturnsSingleElement()
        {
            _empty_LinkedList.AddNode(_newElement);
            Assert.AreEqual(_newElement, _empty_LinkedList.ToString());
        }

        [Test]
        public void AddNode_ToSingleElementLinkedList_ToString_ReturnsTwoElements()
        {
            var expectedOutput = $"{_firstElement}, {_newElement}";

            _oneElement_LinkedList.AddNode(_newElement);

            Assert.AreEqual(expectedOutput, _oneElement_LinkedList.ToString());
        }

        [Test]
        public void AddNode_ToThreeElementLinkedList_ToString_ReturnsFourElements()
        {
            var expectedOutput = $"{_firstElement}, {_secondElement}, {_thirdElement}, {_newElement}";

            _threeElement_LinkedList.AddNode(_newElement);

            Assert.AreEqual(expectedOutput, _threeElement_LinkedList.ToString());
        }

        [Test]
        public void RemoveNode_EmptyLinkedList_ReturnsNull()
        {
            Assert.IsNull(_empty_LinkedList.RemoveNode(2));
            Assert.AreEqual("", _empty_LinkedList.ToString());
        }

        [Test]
        public void RemoveNode_OneElementLinkedList_ReturnsValueAndEmpties()
        {
            Assert.AreEqual(_firstElement, _oneElement_LinkedList.RemoveNode(0));
            Assert.AreEqual("", _oneElement_LinkedList.ToString());
        }

        [Test]
        public void RemoveNode_OneElementLinkedListOutBoundsIndex_ReturnsNull()
        {
            Assert.IsNull(_oneElement_LinkedList.RemoveNode(1));
            Assert.AreEqual(_firstElement, _oneElement_LinkedList.ToString());
        }

        [Test]
        public void RemoveNode_ThreeElementLinkedList_ReturnsandRemovesValue()
        {
            Assert.AreEqual(_secondElement, _threeElement_LinkedList.RemoveNode(1));
            Assert.AreEqual($"{_firstElement}, {_thirdElement}", _threeElement_LinkedList.ToString());
        }

        [Test]
        public void RemoveNode_ThreeElementLinkedListRemoveHead_ReturnsandRemovesValue()
        {
            Assert.AreEqual(_firstElement, _threeElement_LinkedList.RemoveNode(0));
            Assert.AreEqual($"{_secondElement}, {_thirdElement}", _threeElement_LinkedList.ToString());
        }

        [Test]
        public void RemoveNode_ThreeElementLinkedListRemoveTail_ReturnsandRemovesValue()
        {
            Assert.AreEqual(_thirdElement, _threeElement_LinkedList.RemoveNode(2));
            Assert.AreEqual($"{_firstElement}, {_secondElement}", _threeElement_LinkedList.ToString());
        }

        [Test]
        public void RemoveNode_ThreeElementLinkedListOutBoundsIndex_ReturnsNull()
        {
            Assert.IsNull(_threeElement_LinkedList.RemoveNode(4));
            Assert.AreEqual($"{_firstElement}, {_secondElement}, {_thirdElement}", _threeElement_LinkedList.ToString());
        }
    }
}