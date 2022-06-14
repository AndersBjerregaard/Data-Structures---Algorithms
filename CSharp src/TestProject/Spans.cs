using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    /// <summary>
    /// Class to showcase differences between strings and spans in practice.
    /// </summary>
    [TestClass]
    public class Spans
    {
        // An immutable object
        private static readonly string _dateAsText = "08 07 2021";

        /// <summary>
        /// Example to parse as string as integers.
        /// </summary>
        [TestMethod]
        public void DateWithStringAndSubstring()
        {
            var dayAsText = _dateAsText.Substring(0, 2);
            var monthAsText = _dateAsText.Substring(3, 2);
            var yearAsText = _dateAsText.Substring(6);
            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);
            Assert.AreEqual(8, day);
            Assert.AreEqual(7, month);
            Assert.AreEqual(2021, year);
        }

        /// <summary>
        /// Example to parse as span as integers.
        /// </summary>
        [TestMethod]
        public void DateWithSpanAndSlice()
        {
            ReadOnlySpan<char> dateAsSpan = _dateAsText;
            var dayAsText = dateAsSpan.Slice(0, 2);
            var monthAsText = dateAsSpan.Slice(3, 2);
            var yearAsText = dateAsSpan.Slice(6);
            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);
            Assert.AreEqual(8, day);
            Assert.AreEqual(7, month);
            Assert.AreEqual(2021, year);
        }
    }
}
