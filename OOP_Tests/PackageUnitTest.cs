using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Task.Entities;

namespace OOP_Tests
{
    [TestClass]
    public class PackageUnitTest
    {
        #region Properties

        #region Width
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Width_Zero_ExpectException()
        {
            new Package().Width = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Width_Negative_ExpectException()
        {
            new Package().Width = -1;
        }

        [TestMethod]
        public void Width_Positive_ExpectPass()
        {
            new Package().Width = 1;
        }
        #endregion

        #region Length
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Length_Zero_ExpectException()
        {
            new Package().Length = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Length_Negative_ExpectException()
        {
            new Package().Length = -1;
        }

        [TestMethod]
        public void Length_Positive_ExpectPass()
        {
            new Package().Length = 1;
        }
        #endregion

        #region Height
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Height_Zero_ExpectException()
        {
            new Package().Height = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Height_Negative_ExpectException()
        {
            new Package().Height = -1;
        }

        [TestMethod]
        public void Height_Positive_ExpectPass()
        {
            new Package().Width = 1;
        }
        #endregion

        #endregion
    }
}
