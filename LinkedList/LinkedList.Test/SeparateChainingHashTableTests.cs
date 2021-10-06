using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.Test
{
    class SeparateChainingHashTableTests
    {
        private SeparateChainingHashTable<string, string> _testHashTable;
        private string _testKey = "Card Game";
        private string _testValue = "Magic: The Gathering";


        [SetUp]
        public void SetUp()
        {
            _testHashTable = new SeparateChainingHashTable<string, string>();
        }

        [Test]
        public void AddSome_GetExpected()
        {
            _testHashTable.Add("garbage in", "garbage out");
            _testHashTable.Add("Guess what will never see the light of day.", "this");
            _testHashTable.Add("Will.Uneccesary?Punctioantion>Break}Things", "better,not");
            _testHashTable.Add(_testKey, _testValue);
            _testHashTable.Add("q23waetsrxdhtgfn", "09oyi8kutjynhbfg");
            _testHashTable.Add("Guess who has 2 thumbs and can't think of more test values", "this guy");
            _testHashTable.Add("Fry", "Leela");

            Assert.AreEqual(_testValue, _testHashTable.Get(_testKey));
        }

        [Test]
        public void AddSome_Delete_DoesNotGetExpected()
        {
            _testHashTable.Add("garbage in", "garbage out");
            _testHashTable.Add("Guess what will never see the light of day.", "this");
            _testHashTable.Add("Will.Uneccesary?Punctioantion>Break}Things", "better,not");
            _testHashTable.Add(_testKey, _testValue);
            _testHashTable.Add("q23waetsrxdhtgfn", "09oyi8kutjynhbfg");
            _testHashTable.Add("Guess who has 2 thumbs and can't think of more test values", "this guy");
            _testHashTable.Add("Fry", "Leela");

            Assert.AreEqual(_testValue, _testHashTable.Remove(_testKey));
            Assert.AreEqual(null, _testHashTable.Get(_testKey));
        }

        [Test]
        public void AddSome_RequiresExpansion_GetExpected()
        {
            _testHashTable = new SeparateChainingHashTable<string, string>(1);
            _testHashTable.Add("garbage in", "garbage out");
            _testHashTable.Add("Guess what will never see the light of day.", "this");
            _testHashTable.Add("Will.Uneccesary?Punctioantion>Break}Things", "better,not");
            _testHashTable.Add(_testKey, _testValue);
            _testHashTable.Add("q23waetsrxdhtgfn", "09oyi8kutjynhbfg");
            _testHashTable.Add("Guess who has 2 thumbs and can't think of more test values", "this guy");
            _testHashTable.Add("Fry", "Leela");

            Assert.AreEqual(_testValue, _testHashTable.Get(_testKey));
        }

        [Test]
        public void AddSome_RequiresExpansion_Delete_DoesNotGetExpected()
        {
            _testHashTable = new SeparateChainingHashTable<string, string>(1);
            _testHashTable.Add("garbage in", "garbage out");
            _testHashTable.Add("Guess what will never see the light of day.", "this");
            _testHashTable.Add("Will.Uneccesary?Punctioantion>Break}Things", "better,not");
            _testHashTable.Add(_testKey, _testValue);
            _testHashTable.Add("q23waetsrxdhtgfn", "09oyi8kutjynhbfg");
            _testHashTable.Add("Guess who has 2 thumbs and can't think of more test values", "this guy");
            _testHashTable.Add("Fry", "Leela");

            Assert.AreEqual(_testValue, _testHashTable.Remove(_testKey));
            Assert.AreEqual(null, _testHashTable.Get(_testKey));
        }

        [Test]
        public void AddARidiculusNumber_GetExpected()
        {
            for (var i = 0; i < 500000; i++)
            {
                _testHashTable.Add(i.ToString(), $"{i} is the lonliest number.");
            }
            _testHashTable.Add(_testKey, _testValue);
            for (var i = 500000; i < 5000000; i++)
            {
                _testHashTable.Add(i.ToString(), $"{i} is the lonliest number.");
            }

            Assert.AreEqual(_testValue, _testHashTable.Get(_testKey));
        }

        [Test]
        public void AddARidiculusNumber_Delete_DoesNotGetExpected()
        {
            for (var i = 0; i < 500000; i++)
            {
                _testHashTable.Add(i.ToString(), $"{i} is the lonliest number.");
            }
            _testHashTable.Add(_testKey, _testValue);
            for (var i = 500000; i < 5000000; i++)
            {
                _testHashTable.Add(i.ToString(), $"{i} is the lonliest number.");
            }

            Assert.AreEqual(_testValue, _testHashTable.Remove(_testKey));
            Assert.AreEqual(null, _testHashTable.Get(_testKey));
        }
    }
}
