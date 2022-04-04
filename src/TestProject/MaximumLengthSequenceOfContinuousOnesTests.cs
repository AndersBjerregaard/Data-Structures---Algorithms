using Datastructures_and_Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class MaximumLengthSequenceOfContinuousOnesTests
    {
        [TestMethod]
        public void InitialTest()
        {
            Assert.AreEqual(7, MaximumLengthSequenceOfContinuousOnes.FindIndexOfZero(new int[] { 0, 0, 1, 0, 1, 1, 1, 0, 1, 1 }));
        }
    }
}
