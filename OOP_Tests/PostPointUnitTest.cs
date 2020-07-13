using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Task.Entities;

namespace OOP_Tests
{
    [TestClass]
    public class PostPointUnitTest
    {
        #region Properties

        #region Address Country
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressCountry_Length4_ExpectException()
        {
            new PostPoint().AddressCountry = new string('x', 4);
        }

        [TestMethod]
        public void AddressCountry_Length5_ExpectPass()
        {
            new PostPoint().AddressCountry = new string('x', 5);
        }
        #endregion

        #region Address City
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressCity_Length4_ExpectException()
        {
            new PostPoint().AddressCity = new string('x', 4);
        }

        [TestMethod]
        public void AddressCity_Length5_ExpectPass()
        {
            new PostPoint().AddressCity = new string('x', 5);
        }
        #endregion

        #region Address Street
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressStreet_Length4_ExpectException()
        {
            new PostPoint().AddressStreet = new string('x', 4);
        }

        [TestMethod]
        public void AddressStreet_Length5_ExpectPass()
        {
            new PostPoint().AddressStreet = new string('x', 5);
        }
        #endregion

        #region Address Street Number
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressStreetNumber_Negative_ExpectException()
        {
            new PostPoint().AddressStreetNumber = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressStreetNumber_Zero_ExpectException()
        {
            new PostPoint().AddressStreetNumber = 0;
        }

        [TestMethod]
        public void AddressStreetNumber_Positive_ExpectPass()
        {
            new PostPoint().AddressStreetNumber = 1;
        }
        #endregion

        #endregion
    }
}
