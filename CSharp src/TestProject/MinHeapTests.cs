using Datastructures_and_Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static TestProject.BinarySearchTreeTests;

namespace TestProject
{
    [TestClass]
    public class MinHeapTests
    {
        [TestMethod]
        public void InsertWithIntegers()
        {
            // Arrange
            MinHeap<int> heap = new MinHeap<int>(8);

            // Act
            heap.Add(3);
            heap.Add(9);
            heap.Add(12);
            heap.Add(7);
            heap.Add(1);

            // Assert
            Assert.AreEqual("1,3,12,9,7,0,0,0", heap.ToString());
        }

        [TestMethod]
        public void InsertWithGenericObjects()
        {
            // Arrange
            MinHeap<IntegerTestObject> heap = new MinHeap<IntegerTestObject>(8);

            // Act
            heap.Add(new IntegerTestObject(3));
            heap.Add(new IntegerTestObject(9));
            heap.Add(new IntegerTestObject(12));
            heap.Add(new IntegerTestObject(7));
            heap.Add(new IntegerTestObject(1));

            // Assert
            Assert.AreEqual("1,3,12,9,7,,,", heap.ToString());
        }

        [TestMethod]
        public void FindIndexWithIntegers()
        {
            // Arrange
            MinHeap<int> heap = new MinHeap<int>(8);

            // Act
            heap.Add(3);
            heap.Add(9);
            heap.Add(12);
            heap.Add(7);
            heap.Add(1);

            // Assert
            heap.FindIndex(1, out int actual1);
            Assert.AreEqual(0, actual1);
            heap.FindIndex(3, out int actual2);
            Assert.AreEqual(1, actual2);
            heap.FindIndex(12, out int actual3);
            Assert.AreEqual(2, actual3);
            heap.FindIndex(9, out int actual4);
            Assert.AreEqual(3, actual4);
            heap.FindIndex(7, out int actual5);
            Assert.AreEqual(4, actual5);
            Assert.IsFalse(heap.FindIndex(15, out _));
        }

        [TestMethod]
        public void FindIndexWithGenericTypes()
        {
            // Arrange
            MinHeap<IntegerTestObject> heap = new MinHeap<IntegerTestObject>(8);

            // Act
            heap.Add(new IntegerTestObject(3));
            heap.Add(new IntegerTestObject(9));
            heap.Add(new IntegerTestObject(12));
            heap.Add(new IntegerTestObject(7));
            heap.Add(new IntegerTestObject(1));

            // Assert
            heap.FindIndex(new IntegerTestObject(1), out int actual1);
            Assert.AreEqual(0, actual1);
            heap.FindIndex(new IntegerTestObject(3), out int actual2);
            Assert.AreEqual(1, actual2);
            heap.FindIndex(new IntegerTestObject(12), out int actual3);
            Assert.AreEqual(2, actual3);
            heap.FindIndex(new IntegerTestObject(9), out int actual4);
            Assert.AreEqual(3, actual4);
            heap.FindIndex(new IntegerTestObject(7), out int actual5);
            Assert.AreEqual(4, actual5);
            Assert.IsFalse(heap.FindIndex(new IntegerTestObject(15), out _));
        }

        [TestMethod]
        public void AddMoreElementsThanInitialArraySize()
        {
            // Arrange
            MinHeap<int> heap = new MinHeap<int>(8);

            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                heap.Add(random.Next(1, 100));
            }

            // Act & Assert
            try
            {
                heap.Add(42);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CheckHeapOrderAfterInsertion()
        {
            // Arrange
            MinHeap<IntegerTestObject> heap = new MinHeap<IntegerTestObject>(8);

            // Act
            heap.Add(new IntegerTestObject(10));
            heap.Add(new IntegerTestObject(23));
            heap.Add(new IntegerTestObject(17));
            heap.Add(new IntegerTestObject(19));
            heap.Add(new IntegerTestObject(21));
            heap.Add(new IntegerTestObject(5));

            // Assert
            Assert.AreEqual(5, heap[0].Data);
            Assert.AreEqual(19, heap[1].Data);
            Assert.AreEqual(10, heap[2].Data);
            Assert.AreEqual(23, heap[3].Data);
            Assert.AreEqual(21, heap[4].Data);
            Assert.AreEqual(17, heap[5].Data);
        }

        [TestMethod]
        public void DeletionWithIntegers()
        {
            // Arrange
            MinHeap<int> heap = new MinHeap<int>(8);

            heap.Add(10);
            heap.Add(15);
            heap.Add(20);
            heap.Add(17);

            // Act
            heap.Remove(10);

            // Assert
            Assert.AreEqual("15,17,20,0,0,0,0,0", heap.ToString());
        }

        [TestMethod]
        public void DeletionWithManyIntegers()
        {
            // Arrange
            MinHeap<int> heap = new MinHeap<int>(8);

            Random random = new Random();

            heap.Add(1);

            for (int i = 0; i < 20; i++)
            {
                heap.Add(random.Next(2, 100));
            }

            heap.Add(101);

            // Act
            heap.Remove(1);
            heap.Remove(101);

            // Assert
            Assert.IsFalse(heap.FindIndex(1, out _));
            Assert.IsFalse(heap.FindIndex(101, out _));
        }

        [TestMethod]
        public void DeleteWithGenericTypes()
        {
            // Arrange
            MinHeap<IntegerTestObject> heap = new MinHeap<IntegerTestObject>(8);

            Random random = new Random();

            heap.Add(new IntegerTestObject(1));

            for (int i = 0; i < 20; i++)
            {
                heap.Add(new IntegerTestObject(random.Next(2, 100)));
            }

            heap.Add(new IntegerTestObject(101));

            // Act
            heap.Remove(new IntegerTestObject(1));
            heap.Remove(new IntegerTestObject(101));

            // Assert
            Assert.IsFalse(heap.FindIndex(new IntegerTestObject(1), out _));
            Assert.IsFalse(heap.FindIndex(new IntegerTestObject(101), out _));
        }

        [TestMethod]
        public void SmartTraversal() // This test is supposed to be debugged and observed, to see if the heap knows not to search for a low value like '10' further down the heap.
        {
            // Arrange
            MinHeap<IntegerTestObject> heap = new MinHeap<IntegerTestObject>(8);

            heap.Add(new IntegerTestObject(8));
            heap.Add(new IntegerTestObject(19));
            heap.Add(new IntegerTestObject(12));
            heap.Add(new IntegerTestObject(23));
            heap.Add(new IntegerTestObject(78));

            // Act
            heap.FindIndex(new IntegerTestObject(10), out _); // Debug this! The idea is that the heap doesn't need to check the children of the node '19'.
        }
    }
}
