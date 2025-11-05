using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW5.Tests
{
    [TestClass]
    public class MyListTests
    {
        // testing constructors
        [TestMethod]
        public void Constructor_Default_CreatesEmptyList()
        {
            var list = new MyList<int>();

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(4, list.Capacity);
        }

        [TestMethod]
        public void Constructor_WithCapacity_CreatesListWithSpecifiedCapacity()
        {
            var list = new MyList<int>(10);

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(10, list.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithZeroCapacity_ThrowsException()
        {
            var list = new MyList<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNegativeCapacity_ThrowsException()
        {
            var list = new MyList<int>(-5);
        }

        [TestMethod]
        public void Constructor_WithCollection_CreatesListWithCollectionItems()
        {
            var collection = new[] { 1, 2, 3 };

            var list = new MyList<int>(collection);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(4, list.Capacity); // Minimum capacity is 4
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithNullCollection_ThrowsException()
        {
            var list = new MyList<int>(null);
        }

        // testing Add method
        [TestMethod]
        public void Add_SingleItem_IncreasesCount()
        {
            var list = new MyList<string>();

            list.Add("test");

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("test", list[0]);
        }

        [TestMethod]
        public void Add_MultipleItems_AutoResizesWhenNeeded()
        {
            var list = new MyList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(10, list.Count);
            Assert.IsTrue(list.Capacity >= 10); // Should have resized
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, list[i]);
            }
        }

        // testing AddRange method
        [TestMethod]
        public void AddRange_AddsAllItemsFromCollection()
        {
            var list = new MyList<int>();
            var itemsToAdd = new[] { 1, 2, 3, 4, 5 };

            list.AddRange(itemsToAdd);

            Assert.AreEqual(5, list.Count);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i + 1, list[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddRange_WithNullCollection_ThrowsException()
        {
            var list = new MyList<int>();

            list.AddRange(null);
        }
    }
}
