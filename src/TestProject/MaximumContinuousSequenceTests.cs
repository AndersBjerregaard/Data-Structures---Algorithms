using Datastructures_and_Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class MaximumContinuousSequenceTests
    {
        [TestMethod]
        public void GenericTest()
        {
            // My implementation
            Assert.AreEqual(7, MaximumContinuousSequence.FindIndexOfZero(new int[] { 0, 0, 1, 0, 1, 1, 1, 0, 1, 1 }));

            // Internets implementation
            Assert.AreEqual(7, MaximumContinuousSequence.FindIndexOfZeroOtherImplementation(new int[] { 0, 0, 1, 0, 1, 1, 1, 0, 1, 1 }));
        }

        [TestMethod]
        public void TestWithTwoOutcomes()
        {
            // My implementation
            Assert.AreEqual(0, MaximumContinuousSequence.FindIndexOfZero(new int[] { 0, 1, 1, 0, 0 }));

            // Internets implementation
            Assert.AreEqual(0, MaximumContinuousSequence.FindIndexOfZeroOtherImplementation(new int[] { 0, 1, 1, 0, 0 }));
        }

        [TestMethod]
        public void TestWithInvalidInput()
        {
            // My implementation
            Assert.AreEqual(-1, MaximumContinuousSequence.FindIndexOfZero(new int[] { 1, 1 }));

            // Internets implementation
            Assert.AreEqual(-1, MaximumContinuousSequence.FindIndexOfZeroOtherImplementation(new int[] { 1, 1 }));
        }
    }
}
