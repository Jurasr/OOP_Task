using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Task.Entities;
using System.Collections.Generic;

namespace OOP_Tests
{
    [TestClass]
    public class CartUnitTest
    {
        #region Constructors

        #region Total Price
        [TestMethod]
        public void TotalPrice_ProductPrice10_Expect10()
        {
            double totalPrice = new Cart(1, new Customer(), new List<Product>()
            {
                new Product() { Price = 10 },
            }).TotalPrice;

            Assert.AreEqual(totalPrice, 10);
        }

        [TestMethod]
        public void TotalPrice_ProductsEmpty_Expect0()
        {
            double totalPrice = new Cart(1, new Customer(), new List<Product>()).TotalPrice;

            Assert.AreEqual(totalPrice, 0);
        }

        [TestMethod]
        public void TotalPrice_Product1Price20Product2Price40dot99_Expect60dot99()
        {
            double totalPrice = new Cart(1, new Customer(), new List<Product>()
            {
                new Product() { Price = 20 },
                new Product() { Price = 40.99 }
            }).TotalPrice;

            Assert.AreEqual(totalPrice, 60.99);
        }

        [TestMethod]
        public void TotalPrice_Product1Price1Product2Price2Product3Price3_Expect6()
        {
            double totalPrice = new Cart(1, new Customer(), new List<Product>()
            {
                new Product() { Price = 1 },
                new Product() { Price = 2 },
                new Product() { Price = 3 }
            }).TotalPrice;

            Assert.AreEqual(totalPrice, 6);
        }
        #endregion

        #region Total Items
        [TestMethod]
        public void TotalItems_0Products_Expect0()
        {
            int totalItems = new Cart(1, new Customer(), new List<Product>()).TotalItems;

            Assert.AreEqual(totalItems, 0);
        }

        [TestMethod]
        public void TotalItems_1Product_Expect1()
        {
            int totalItems = new Cart(1, new Customer(), new List<Product>()
            { 
                new Product()
            }).TotalItems;

            Assert.AreEqual(totalItems, 1);
        }

        [TestMethod]
        public void TotalItems_2Products_Expect2()
        {
            int totalItems = new Cart(1, new Customer(), new List<Product>()
            {
                new Product(),
                new Product()
            }).TotalItems;

            Assert.AreEqual(totalItems, 2);
        }
        #endregion

        #endregion
    }
}