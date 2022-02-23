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
        public void DeletionWithIntegers()
        {
            // Arrange
            MinHeap<int> heap = new MinHeap<int>(8);

            heap.Add(3);
            heap.Add(9);
            heap.Add(12);
            heap.Add(7);
            heap.Add(1);

            // Act
            heap.Remove(1);

            // Assert
            Assert.AreEqual("3,7,12,9,0,0,0,0", heap.ToString());
        }
    }
}
