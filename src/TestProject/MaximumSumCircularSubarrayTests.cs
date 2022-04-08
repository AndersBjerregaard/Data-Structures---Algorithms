using Datastructures_and_Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class MaximumSumCircularSubarrayTests
    {
        [TestMethod]
        public void BruteForceTest1()
        {
            Assert.AreEqual(6, MaximumSumCircularSubarray.FindLargestSubAarray(new int[] { 2, 1, -5, 4, -3, 1, -3, 4, -1 }));
        }

        [TestMethod]
        public void BruteForceTest2()
        {
            Assert.AreEqual(18, MaximumSumCircularSubarray.FindLargestSubAarray(new int[] { 8, -7, -3, 5, 6, -2, 3, -4, 2 }));
        }

        [TestMethod]
        public void CircularKadaneTest1()
        {
            Assert.AreEqual(6, MaximumSumCircularSubarray.CircularKadane(new int[] { 2, 1, -5, 4, -3, 1, -3, 4, -1 }));
        }

        [TestMethod]
        public void CircularKadaneTest2()
        {
            Assert.AreEqual(18, MaximumSumCircularSubarray.CircularKadane(new int[] { 8, -7, -3, 5, 6, -2, 3, -4, 2 }));
        }

        [TestMethod]
        public void KadanesAlgorithmTest1()
        {
            Assert.AreEqual(6, MaximumSumCircularSubarray.Kadane(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
    }
}
