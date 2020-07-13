using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Task.Entities;
using System;

namespace OOP_Tests
{
    [TestClass]
    public class CustomerUnitTest
    {
        #region Properties

        #region Name
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Name_Length4_ExpectException()
        {
            new Customer().Name = new String('x', 4);
        }

        [TestMethod]
        public void Name_Length5_ExpectPass()
        {
            new Customer().Name = new String('x', 5);
        }
        #endregion

        #region Surname
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Surname_Length4_ExpectException()
        {
            new Customer().Surname = new String('x', 4);
        }

        [TestMethod]
        public void Surname_Length5_ExpectPass()
        {
            new Customer().Surname = new String('x', 5);
        }
        #endregion

        #region Address Country
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressCountry_Length4_ExpectException()
        {
            new Customer().AddressCountry = new String('x', 4);
        }

        [TestMethod]
        public void AddressCountry_Length5_ExpectPass()
        {
            new Customer().AddressCountry = new String('x', 5);
        }
        #endregion

        #region Address City
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressCity_Length4_ExpectException()
        {
            new Customer().AddressCity = new String('x', 4);
        }

        [TestMethod]
        public void AddressCity_Length5_ExpectPass()
        {
            new Customer().AddressCity = new String('x', 5);
        }
        #endregion

        #region Address Street
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressStreet_Length4_ExpectException()
        {
            new Customer().AddressStreet = new String('x', 4);
        }

        [TestMethod]
        public void AddressStreet_Length5_ExpectPass()
        {
            new Customer().AddressStreet = new String('x', 5);
        }
        #endregion

        #region Address Street Number
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressStreetNumber_Zero_ExpectException()
        {
            new Customer().AddressStreetNumber = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddressStreetNumber_Negative_ExpectException()
        {
            new Customer().AddressStreetNumber = -1;
        }

        [TestMethod]
        public void AddressStreetNumber_Positive_ExpectPass()
        {
            new Customer().AddressStreetNumber = 1;
        }
        #endregion

        #endregion
    }
}
