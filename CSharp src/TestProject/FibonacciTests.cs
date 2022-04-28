using Datastructures_and_Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void SmallInputTests()
        {
            Assert.AreEqual(8, Fibonacci.Fib(6));
            Assert.AreEqual(13, Fibonacci.Fib(7));
            Assert.AreEqual(21, Fibonacci.Fib(8));
        }

        [TestMethod]
        public void LargeInputTests()
        {
            Assert.AreEqual(50, Fibonacci.Fib(50));
        }
    }
}
