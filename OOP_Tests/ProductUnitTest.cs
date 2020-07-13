using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Task.Entities;

namespace OOP_Tests
{
    [TestClass]
    public class ProductUnitTest
    {
        #region Properties

        #region Title
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Title_Length4_ExpectException()
        {
            new Product().Title = new String('x', 4);
        }

        [TestMethod]
        public void Title_Length5_ExpectPass()
        {
            new Product().Title = new String('x', 5);
        }
        #endregion

        #region Description
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Description_Length9_ExpectException()
        {
            new Product().Description = new String('x', 9);
        }

        [TestMethod]
        public void Description_Length10_ExpectPass()
        {
            new Product().Description = new String('x', 10);
        }
        #endregion

        #region Price
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Price_Negative_ExpectException()
        {
            new Product().Price = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Price_Zero_ExpectException()
        {
            new Product().Price = 0;
        }

        [TestMethod]
        public void Price_One_ExpectPass()
        {
            new Product().Price = 1;
        }
        #endregion

        #region Width
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Width_Negative_ExpectException()
        {
            new Product().Width = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Width_Zero_ExpectException()
        {
            new Product().Width = 0;
        }

        [TestMethod]
        public void Width_One_ExpectPass()
        {
            new Product().Width = 1;
        }
        #endregion

        #region Length
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Length_Negative_ExpectException()
        {
            new Product().Length = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Length_Zero_ExpectException()
        {
            new Product().Length = 0;
        }

        [TestMethod]
        public void Length_One_ExpectPass()
        {
            new Product().Length = 1;
        }
        #endregion

        #region Height
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Height_Negative_ExpectException()
        {
            new Product().Height = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Height_Zero_ExpectException()
        {
            new Product().Height = 0;
        }

        [TestMethod]
        public void Height_One_ExpectPass()
        {
            new Product().Height = 1;
        }
        #endregion

        #endregion
    }
}
