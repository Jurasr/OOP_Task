using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Task.Entities;
using OOP_Task.Helpers;
using System.Collections.Generic;

namespace OOP_Tests
{
    [TestClass]
    public class UtilitiesUnitTest
    {
        #region Methods

        #region List To Dict
        [TestMethod]
        public void ListToDict_EmptyList_ExpectEmptyDict()
        {
            Dictionary<Product, int> dictionary = Utilities.ListToDict(new List<Product>());
            Assert.AreEqual(0, dictionary.Count);
        }

        [TestMethod]
        public void ListToDict_ListOneItem_ExpectOneCount()
        {
            Product product1 = new Product(1, "Title", "Description", 10, 10, 10, 10);
            Dictionary<Product, int> dictionary = Utilities.ListToDict(new List<Product>() { product1 });
            Assert.AreEqual(1, dictionary.Count);
            Assert.AreEqual(1, dictionary[product1]);
        }

        [TestMethod]
        public void ListToDict_ListTwoSameItems_ExpectOneCountTwoKeyValue()
        {
            Product product1 = new Product(1, "Title", "Description", 10, 10, 10, 10);
            Dictionary<Product, int> dictionary = Utilities.ListToDict(new List<Product>() { product1, product1 });
            Assert.AreEqual(1, dictionary.Count);
            Assert.AreEqual(2, dictionary[product1]);
        }

        [TestMethod]
        public void ListToDict_ListThreeItemsTwoSameOneDifferent_ExpectTwoCountTwoAndOneKeyValues()
        {
            Product product1 = new Product(1, "Title", "Description", 10, 10, 10, 10);
            Product product2 = new Product(2, "Title", "Description", 10, 10, 10, 10);
            Dictionary<Product, int> dictionary = Utilities.ListToDict(new List<Product>() { product1, product1, product2 });
            Assert.AreEqual(2, dictionary.Count);
            Assert.AreEqual(2, dictionary[product1]);
            Assert.AreEqual(1, dictionary[product2]);
        }
        #endregion

        #region Validate Product Size
        [TestMethod]
        public void ValidateProductSize_Product10x10x10Package9x9x9_ExpectFalse()
        {
            Product product = new Product(1, "Title", "Description", 10, 10, 10, 10);
            List<Package> packages = new List<Package>
            {
                new Package("S", 9, 9, 9)
            };
            Assert.AreEqual(false, Utilities.ValidateProductSize(product, packages));
        }

        [TestMethod]
        public void ValidateProductSize_Product10x10x10Package10x10x10_ExpectTrue()
        {
            Product product = new Product(1, "Title", "Description", 10, 10, 10, 10);
            List<Package> packages = new List<Package>
            {
                new Package("S", 10, 10, 10)
            };
            Assert.AreEqual(true, Utilities.ValidateProductSize(product, packages));
        }

        [TestMethod]
        public void ValidateProductSize_Product10x10x10TwoPackages5x5x5and9x9x9_ExpectFalse()
        {
            Product product = new Product(1, "Title", "Description", 10, 10, 10, 10);
            List<Package> packages = new List<Package>
            {
                new Package("S", 5, 5, 5),
                new Package("S", 9, 9, 9)
            };
            Assert.AreEqual(false, Utilities.ValidateProductSize(product, packages));
        }

        [TestMethod]
        public void ValidateProductSize_Product6x6x6TwoPackages5x5x5and9x9x9_ExpectTrue()
        {
            Product product = new Product(1, "Title", "Description", 10, 6, 6, 6);
            List<Package> packages = new List<Package>
            {
                new Package("S", 5, 5, 5),
                new Package("S", 9, 9, 9)
            };
            Assert.AreEqual(true, Utilities.ValidateProductSize(product, packages));
        }
        #endregion

        #endregion
    }
}