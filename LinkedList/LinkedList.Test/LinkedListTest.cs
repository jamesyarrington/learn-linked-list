using NUnit.Framework;

namespace LinkedList.Test
{
    public class Tests
    {
        private LinkedList<string> _empty_LinkedList;
        private LinkedList<string> _oneElement_LinkedList;
        private LinkedList<string> _twoElement_LinkedList;
        private LinkedList<string> _threeElement_LinkedList;
        private LinkedList<int> _manyElement_LinkedList;

        private readonly string _firstElement = "first";
        private readonly string _secondElement = "2nd";
        private readonly string _thirdElement = "THIRD";

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
    }
}