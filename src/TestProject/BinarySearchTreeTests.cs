using Datastructures_and_Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestProject
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void InsertWithInteger()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Insert(1);

            Assert.IsTrue(bst.Contains(1));
        }

        [TestMethod]
        public void InsertWithMultipleIntegers()
        {
            // Arrange
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            // Act
            bst.Insert(9);
            bst.Insert(7);
            bst.Insert(15);
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(8);

            // Assert that the numbers inserted exist in the tree
            Assert.IsTrue(bst.Contains(9));
            Assert.IsTrue(bst.Contains(7));
            Assert.IsTrue(bst.Contains(15));
            Assert.IsTrue(bst.Contains(3));
            Assert.IsTrue(bst.Contains(5));
            Assert.IsTrue(bst.Contains(8));

            // Assert that the structure of the tree is proper
            Assert.AreEqual(9, bst.root.Data);
            Assert.AreEqual(15, bst.root.Right.Data);
            Assert.AreEqual(7, bst.root.Left.Data);
            Assert.AreEqual(8, bst.root.Left.Right.Data);
            Assert.AreEqual(5, bst.root.Left.Left.Data);
            Assert.AreEqual(3, bst.root.Left.Left.Left.Data);

            // Assert that the count variable works as intended
            Assert.AreEqual(6, bst.Count);
        }

        [TestMethod]
        public void InsertWithGenericTypes()
        {
            var bst = new BinarySearchTree<GenericTestObject>();

            var obj1 = new GenericTestObject();
            var obj2 = new GenericTestObject();
            var obj3 = new GenericTestObject();
            var obj4 = new GenericTestObject();

            bst.Insert(obj1);
            bst.Insert(obj2);
            bst.Insert(obj3);

            Assert.IsTrue(bst.Contains(obj1));
            Assert.IsTrue(bst.Contains(obj2));
            Assert.IsTrue(bst.Contains(obj3));
            Assert.IsFalse(bst.Contains(obj4));
        }

        [TestMethod]
        public void DeletionWithMultipleGenericTypesInTree()
        {
            // Arrange
            var bst = new BinarySearchTree<IntegerTestObject>();

            bst.Insert(new IntegerTestObject(13));
            var objectToBeDeleted = new IntegerTestObject(7);
            bst.Insert(objectToBeDeleted);
            bst.Insert(new IntegerTestObject(9));
            bst.Insert(new IntegerTestObject(11));
            bst.Insert(new IntegerTestObject(8));
            bst.Insert(new IntegerTestObject(15));
            bst.Insert(new IntegerTestObject(5));
            bst.Insert(new IntegerTestObject(6));
            bst.Insert(new IntegerTestObject(4));

            // Act
            bst.Remove(objectToBeDeleted);

            // Assert that the largest value in the left subtree of the object that was deleted has been promoted in its stead.
            Assert.AreEqual(6, bst.root.Left.Data.Data);
            Assert.AreEqual(5, bst.root.Left.Left.Data.Data);
            Assert.AreEqual(9, bst.root.Left.Right.Data.Data);
        }

        [TestMethod]
        public void PreorderTraversalTest()
        {
            // Arrange
            var bst = new BinarySearchTree<IntegerTestObject>();

            bst.Insert(new IntegerTestObject(23));
            bst.Insert(new IntegerTestObject(31));
            bst.Insert(new IntegerTestObject(14));
            bst.Insert(new IntegerTestObject(17));
            bst.Insert(new IntegerTestObject(7));
            bst.Insert(new IntegerTestObject(9));

            // Act
            var collection = bst.PreorderTraversal();
            string actual = "";
            foreach (var item in collection)
            {
                actual += $"{item} ";
            }

            // Assert
            Assert.AreEqual("23 14 7 9 17 31 ", actual);
        }

        [TestMethod]
        public void PostorderTraversalTest()
        {
            // Arrange
            var bst = new BinarySearchTree<IntegerTestObject>();

            bst.Insert(new IntegerTestObject(23));
            bst.Insert(new IntegerTestObject(31));
            bst.Insert(new IntegerTestObject(14));
            bst.Insert(new IntegerTestObject(17));
            bst.Insert(new IntegerTestObject(7));
            bst.Insert(new IntegerTestObject(9));

            // Act
            var collection = bst.PostorderTraversal();
            string actual = "";
            foreach (var item in collection)
            {
                actual += $"{item} ";
            }

            // Assert
            Assert.AreEqual("9 7 17 14 31 23 ", actual);
        }

        [TestMethod]
        public void BreadthFirstTraversalTest()
        {
            // Arrange
            var bst = new BinarySearchTree<IntegerTestObject>();

            bst.Insert(new IntegerTestObject(23));
            bst.Insert(new IntegerTestObject(31));
            bst.Insert(new IntegerTestObject(14));
            bst.Insert(new IntegerTestObject(17));
            bst.Insert(new IntegerTestObject(7));
            bst.Insert(new IntegerTestObject(9));

            // Act
            var collection = bst.BreadthFirstTraversal();
            string actual = "";
            foreach (var item in collection)
            {
                actual += $"{item} ";
            }

            // Assert
            Assert.AreEqual("23 14 31 7 17 9 ", actual);
        }

        public class GenericTestObject : IComparable<GenericTestObject>
        {
            public Guid Data { get; }

            public GenericTestObject()
            {
                Data = Guid.NewGuid();
            }

            public int CompareTo([AllowNull] GenericTestObject other)
            {
                return Data.CompareTo(other.Data);
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        public class IntegerTestObject : IComparable<IntegerTestObject>
        {
            public int Data { get; }

            public IntegerTestObject()
            {
                Data = new Random().Next(1, 1000);
            }

            public IntegerTestObject(int value)
            {
                Data = value;
            }

            public int CompareTo([AllowNull] IntegerTestObject other)
            {
                return Data.CompareTo(other.Data);
            }

            public override string ToString()
            {
                return $"{Data}";
            }
        }
    }
}
