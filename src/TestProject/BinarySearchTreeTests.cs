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
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Insert(7);
            bst.Insert(3);
            bst.Insert(13);

            Assert.IsTrue(bst.Contains(7));
            Assert.IsTrue(bst.Contains(3));
            Assert.IsTrue(bst.Contains(13));
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
    }
}
