using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Task.Entities;
using System;
using System.Collections.Generic;

namespace OOP_Tests
{
    [TestClass]
    public class ShipmentUnitTest
    {
        #region Properties

        #region Cart
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cart_ProductsEmpty_ExpectException()
        {
            new Shipment().Cart = new Cart() { Products = new List<Product>() };
        }

        [TestMethod]
        public void Cart_OneProduct_ExpectPass()
        {
            new Shipment().Cart = new Cart() { Products = new List<Product> { new Product() } };
        }

        [TestMethod]
        public void Cart_TwoProducts_ExpectPass()
        {
            new Shipment().Cart = new Cart() { Products = new List<Product> { new Product(), new Product() } };
        }
        #endregion Cart

        #region Shipment Type
        [TestMethod]
        public void ShipmentType_International_ExpectPass()
        {
            new Shipment().ShipmentType = "International";
        }

        [TestMethod]
        public void ShipmentType_Courier_ExpectPass()
        {
            new Shipment().ShipmentType = "Courier";
        }

        [TestMethod]
        public void ShipmentType_Post_ExpectPass()
        {
            new Shipment().ShipmentType = "Post";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShipmentType_Anything_ExpectException()
        {
            new Shipment().ShipmentType = "Anything";
        }
        #endregion

        #region Total Price
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TotalPrice_Negative_ExpectException()
        {
            new Shipment().TotalPrice = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TotalPrice_Zero_ExpectException()
        {
            new Shipment().TotalPrice = 0;
        }

        [TestMethod]
        public void TotalPrice_Positive_ExpectPass()
        {
            new Shipment().TotalPrice = 0.01;
        }

        [TestMethod]
        public void TotalPrice_OneProductPrice10International_Equals25p99()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "US of Doe", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product("Product Title", "Product Description", price: 10, 10, 10, 10) });
            Shipment shipment = new Shipment(cart, "International");
            Assert.AreEqual(shipment.TotalPrice, 25);
        }

        [TestMethod]
        public void TotalPrice_TwoProductsPrice10and15International_Equals40()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "US of Doe", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product("Product Title", "Product Description", price: 10, 10, 10, 10), new Product("Product Title", "Product Description", price: 15, 10, 10, 10) });
            Shipment shipment = new Shipment(cart, "International");
            Assert.AreEqual(shipment.TotalPrice, 40);
        }

        [TestMethod]
        public void TotalPrice_OneProductPrice10Courier_15()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "US of Doe", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product("Product Title", "Product Description", price: 10, 10, 10, 10) });
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(shipment.TotalPrice, 15);
        }

        [TestMethod]
        public void TotalPrice_TwoProducts10and15CourierEquals30()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "US of Doe", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product("Product Title", "Product Description", price: 10, 10, 10, 10), new Product("Product Title", "Product Description", price: 15, 10, 10, 10) });
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(shipment.TotalPrice, 30);
        }

        [TestMethod]
        public void TotalPrice_OneProductPrice10Post_13()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "US of Doe", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product("Product Title", "Product Description", price: 10, 10, 10, 10) });
            Shipment shipment = new Shipment(cart, "Post", 1);
            Assert.AreEqual(shipment.TotalPrice, 13);
        }

        [TestMethod]
        public void TotalPrice_TwoProductsPrice10and15Post_Equals28()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "US of Doe", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product("Product Title", "Product Description", price: 10, 10, 10, 10), new Product("Product Title", "Product Description", price: 15, 10, 10, 10) });
            Shipment shipment = new Shipment(cart, "Post", 1);
            Assert.AreEqual(shipment.TotalPrice, 28);
        }
        #endregion

        #endregion

        #region Constructors

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ShipmentInternationalToSameCountry_ExpectException()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product() { Price = 10 }});
            Shipment shipment = new Shipment(cart, "International");
        }

        [TestMethod]
        public void Constructor_ShipmentInternationalToAnotherCountry_ExpectPass()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "Another country", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product("Product Title", "Product Description", price: 10, 10, 10, 10) });
            Shipment shipment = new Shipment(cart, "International");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ShipmentPostButNoPostIdProvided_ExpectException()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product() { Price = 10 } });
            Shipment shipment = new Shipment(cart, "Post");
        }

        [TestMethod]
        public void Constructor_ShipmentPostIdIsProvided_ExpectPass()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product("Product Title", "Product Description", price: 10, 10, 10, 10) });
            Shipment shipment = new Shipment(cart, "Post", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ShipmentPostNonExistantPostIdIsProvided_ExpectException()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            Cart cart = new Cart(customer, new List<Product> { new Product() { Price = 10 } });
            Shipment shipment = new Shipment(cart, "Post", 2);
        }
        #endregion

        #region Methods

        #region Calculate Packages

        /*
         * Package sizes (from bin/debug/package.csv):
         * 
         * S - 20,20,20
         * M - 40,40,40
         * L - 60,60,60
         * 
         */
        
        [TestMethod]
        public void CalculatePackages_Product20x20x20_Expect1PackageS()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            List<Product> productList = new List<Product> { new Product { Id = 1, Width = 20, Length = 20, Height = 20 } };
            Cart cart = new Cart(customer, productList);
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(1, shipment.ShipmentPackages.Count);
            Assert.AreEqual("S", shipment.ShipmentPackages[0].Type);
        }

        [TestMethod]
        public void CalculatePackages_2Products20x20x20_Expect1PackageM()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            List<Product> productList = new List<Product> { 
                new Product { Id = 1, Width = 20, Length = 20, Height = 20 },
                new Product { Id = 2, Width = 20, Length = 20, Height = 20 }
            };
            Cart cart = new Cart(customer, productList);
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(1, shipment.ShipmentPackages.Count);
            Assert.AreEqual("M", shipment.ShipmentPackages[0].Type);
        }

        [TestMethod]
        public void CalculatePackages_4Products10x10x10_Expect1PackageS()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            List<Product> productList = new List<Product> {
                new Product { Id = 1, Width = 10, Length = 10, Height = 10 },
                new Product { Id = 2, Width = 10, Length = 10, Height = 10 },
                new Product { Id = 3, Width = 10, Length = 10, Height = 10 },
                new Product { Id = 4, Width = 10, Length = 10, Height = 10 }
            };
            Cart cart = new Cart(customer, productList);
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(1, shipment.ShipmentPackages.Count);
            Assert.AreEqual("S", shipment.ShipmentPackages[0].Type);
        }

        [TestMethod]
        public void CalculatePackages_1Product41x40x40_Expect1PackageL()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            List<Product> productList = new List<Product> {
                new Product { Id = 1, Width = 41, Length = 40, Height = 40 }
            };
            Cart cart = new Cart(customer, productList);
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(1, shipment.ShipmentPackages.Count);
            Assert.AreEqual("L", shipment.ShipmentPackages[0].Type);
        }

        [TestMethod]
        public void CalculatePackages_1Product21x20x20_Expect1PackageM()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            List<Product> productList = new List<Product> {
                new Product { Id = 1, Width = 21, Length = 20, Height = 20 }
            };
            Cart cart = new Cart(customer, productList);
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(1, shipment.ShipmentPackages.Count);
            Assert.AreEqual("M", shipment.ShipmentPackages[0].Type);
        }

        [TestMethod]
        public void CalculatePackages_2Products60x60x60_Expect2PackagesL()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            List<Product> productList = new List<Product> {
                new Product { Id = 1, Width = 60, Length = 60, Height = 60 },
                new Product { Id = 2, Width = 60, Length = 60, Height = 60 },
            };
            Cart cart = new Cart(customer, productList);
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(2, shipment.ShipmentPackages.Count);
            Assert.AreEqual("L", shipment.ShipmentPackages[0].Type);
            Assert.AreEqual("L", shipment.ShipmentPackages[1].Type);
        }

        [TestMethod]
        public void CalculatePackages_2Products40x40x40and1x1x1_Expect1PackageL()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            List<Product> productList = new List<Product> {
                new Product { Id = 1, Width = 40, Length = 40, Height = 40 },
                new Product { Id = 2, Width = 1, Length = 1, Height = 1 }
            };
            Cart cart = new Cart(customer, productList);
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(1, shipment.ShipmentPackages.Count);
            Assert.AreEqual("L", shipment.ShipmentPackages[0].Type);
        }

        [TestMethod]
        public void CalculatePackages_2Products60x60x60and1x1x1_Expect2PackagesLandS()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            List<Product> productList = new List<Product> {
                new Product { Id = 1, Width = 60, Length = 60, Height = 60 },
                new Product { Id = 2, Width = 1, Length = 1, Height = 1 }
            };
            Cart cart = new Cart(customer, productList);
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(2, shipment.ShipmentPackages.Count);
            Assert.AreEqual("L", shipment.ShipmentPackages[0].Type);
            Assert.AreEqual("S", shipment.ShipmentPackages[1].Type);
        }

        [TestMethod]
        public void CalculatePackages_3Products60x60x60and60x60x60and21x20x20_Expect3PackagesLandLandM()
        {
            Customer customer = new Customer("Johnny", "DoeDoeDoeDoe", "lithuania", "Dopecity", "Doestreet", 1);
            List<Product> productList = new List<Product> {
                new Product { Id = 1, Width = 60, Length = 60, Height = 60 },
                new Product { Id = 1, Width = 60, Length = 60, Height = 60 },
                new Product { Id = 2, Width = 21, Length = 20, Height = 20 }
            };
            Cart cart = new Cart(customer, productList);
            Shipment shipment = new Shipment(cart, "Courier");
            Assert.AreEqual(3, shipment.ShipmentPackages.Count);
            Assert.AreEqual("L", shipment.ShipmentPackages[0].Type);
            Assert.AreEqual("L", shipment.ShipmentPackages[1].Type);
            Assert.AreEqual("M", shipment.ShipmentPackages[2].Type);
        }
        #endregion

        #endregion
    }
}