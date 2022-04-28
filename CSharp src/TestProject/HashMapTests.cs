using Datastructures_and_Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static TestProject.BinarySearchTreeTests;

namespace TestProject
{
    [TestClass]
    public class HashMapTests
    {
        [TestMethod]
        public void InsertionWithPrimitiveTypes()
        {
            // Arrange
            HashMap<int> integerHashMap = new HashMap<int>(10);

            // Act
            integerHashMap.Put("one", 1);
            integerHashMap.Put("fortytwo", 42);
            integerHashMap.Put("onemillion", 1000000);

            // Assert
            Assert.AreEqual(1, integerHashMap.Get("one"));
            Assert.AreEqual(42, integerHashMap.Get("fortytwo"));
            Assert.AreEqual(1000000, integerHashMap.Get("onemillion"));
        }

        // This test method asserts whether hash table collisions have been given a solution.
        // Although it should be noted, that there's an astronomically low chance that the index computed from the key 'fortytwo' was put within an empty LinkedList node.
        [TestMethod]
        public void InsertMoreThanInitialArraySizeWithPrimitiveTypes()
        {
            // Arrange
            HashMap<int> integerHashMap = new HashMap<int>(10);

            Random random = new Random();

            // Act
            for (int i = 0; i < 1000; i++)
            {
                int randomInteger = random.Next(1, 1000000);
                integerHashMap.Put(randomInteger.ToString(), randomInteger);
            }

            integerHashMap.Put("fortytwo", 1000001);

            // Assert
            Assert.AreEqual(1000001, integerHashMap.Get("fortytwo"));
        }

        [TestMethod]
        public void HashMapWithGenericTypes()
        {
            // Arrange
            HashMap<GenericTestObject> hashMap = new HashMap<GenericTestObject>(10);

            Random random = new Random();

            // Act
            for (int i = 0; i < 1000; i++)
            {
                hashMap.Put(random.Next(1, 1000).ToString(), new GenericTestObject());
            }

            var assertObject = new GenericTestObject();

            hashMap.Put("key", assertObject);

            // Assert
            Assert.AreEqual(assertObject.Data, hashMap.Get("key").Data);
        }
    }
}
