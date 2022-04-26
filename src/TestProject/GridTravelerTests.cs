using Datastructures_and_Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    [TestClass]
    public class GridTravelerTests
    {
        [TestMethod]
        public void SmallInputTests()
        {
            //Assert.AreEqual(1, GridTraveler.Travel(1, 1));
            Assert.AreEqual(3, GridTraveler.Travel(2, 3));
            //Assert.AreEqual(3, GridTraveler.Travel(3, 2));
            //Assert.AreEqual(6, GridTraveler.Travel(3, 3));
        }

        [TestMethod]
        public void LargeInputTests()
        {
            Assert.AreEqual(2333606220, GridTraveler.Travel(18, 18));
        }
    }
}
