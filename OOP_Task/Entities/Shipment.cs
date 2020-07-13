using OOP_Task.Collections;
using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Entities;
using CromulentBisgetti.ContainerPacking.Algorithms;
using OOP_Task.Helpers;

namespace OOP_Task.Entities
{
    public class Shipment: Entity
    {
        #region Modifications for Testing - delete this region after done testing
        public List<Package> ShipmentPackages
        {
            get { return _ShipmentPackages; }
        }
        #endregion

        #region Private Properties
        private const string COUNTRY_TO_SHIP_FROM = "lithuania";
        
        private List<Package> _AllPackagesSorted = new FileCollection<Package>().GetAll().OrderBy(package => package.Height* package.Width* package.Length).ToList();
        
        private List<Package> _ShipmentPackages = new List<Package>();

        private FileCollection<PostPoint> _PostPointCollection = new FileCollection<PostPoint>();

        private Dictionary<string, double> _ShipmentPrices = new Dictionary<string, double>
        {
            ["International"] = 15,
            ["Courier"] = 5,
            ["Post"] = 3
        };
        #endregion

        #region Public Properties

        #region Cart
        private Cart _Cart;
        public Cart Cart 
        {
            get { return _Cart; }
            set
            {
                if (value.Products.Count == 0)
                {
                    throw new ArgumentNullException("Shipment cart products cannot be empty.");
                }
                _Cart = value;
            }
        }
        #endregion

        #region Shipment Type
        private string _ShipmentType;
        public string ShipmentType
        {
            get { return _ShipmentType; }
            set
            {
                if (!_ShipmentPrices.Keys.ToArray().Contains(value))
                {
                    throw new ArgumentException($"Shipment type can only be: {string.Join(", ", _ShipmentPrices.Keys.ToArray())}");
                }
                _ShipmentType = value;
            }
        }
        #endregion

        #region Total Price
        private double _TotalPrice;
        public double TotalPrice 
        { 
            get { return _TotalPrice; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Shipment total price needs to be greater than 0.");
                }
                _TotalPrice = value;
            }
        }
        #endregion

        #region Shipment Address
        private string _ShipmentAddress;
        public string ShipmentAddress
        {
            get { return _ShipmentAddress; }
            set { _ShipmentAddress = value; }
        }
        #endregion

        #endregion

        #region Constructors
        public Shipment() { }

        public Shipment(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) { }

        public Shipment(int id, Cart cart, string shipmentType, int postId = 0): base(id)
        {
            ConstructorValidator(cart.Customer, shipmentType, postId);
            Cart = cart;
            ShipmentType = shipmentType;
            CalculatePackages(Utilities.ListToDict(Cart.Products));
            TotalPrice = Cart.TotalPrice + _ShipmentPrices[shipmentType];
            ShipmentAddress = FormatShipmentAddress(postId);
        }

        public Shipment(Cart cart, string shipmentType, int postId = 0)
        {
            ConstructorValidator(cart.Customer, shipmentType, postId);
            Cart = cart;
            ShipmentType = shipmentType;
            CalculatePackages(Utilities.ListToDict(Cart.Products));
            TotalPrice = Cart.TotalPrice + _ShipmentPrices[shipmentType];
            ShipmentAddress = FormatShipmentAddress(postId);
        }
        #endregion

        #region Methods

        #region Calculate Packages
        void CalculatePackages(Dictionary<Product, int> products)
        {
            
            List<int> packingAlgorithms = new List<int> { (int)AlgorithmType.EB_AFIT };

            for (int i = 0; i < _AllPackagesSorted.Count; i++) 
            {
                List<Container> containers = new List<Container>
                {
                    new Container(_AllPackagesSorted[i].Id, (decimal)_AllPackagesSorted[i].Width, (decimal)_AllPackagesSorted[i].Length, (decimal)_AllPackagesSorted[i].Height)
                };

                List<Item> productsToPack = new List<Item>();

                foreach (KeyValuePair<Product, int> product in products)
                {
                    productsToPack.Add(new Item(product.Key.Id, (decimal)product.Key.Width, (decimal)product.Key.Length, (decimal)product.Key.Height, product.Value));
                }

                List<ContainerPackingResult> packingResults = PackingService.Pack(containers, productsToPack, packingAlgorithms);

                List<Item> unpackedItems = packingResults[0].AlgorithmPackingResults[0].UnpackedItems;
                
                if (unpackedItems.Count == 0)
                {
                    _ShipmentPackages.Add(_AllPackagesSorted[i]);
                    break;
                }
                else
                {
                    if (i == _AllPackagesSorted.Count - 1)
                    {
                        _ShipmentPackages.Add(_AllPackagesSorted[i]);

                        Dictionary<Product, int> unpackedProducts = new Dictionary<Product, int>();

                        foreach (Item item in unpackedItems)
                        {
                            int unpackedId = item.ID;

                            foreach (KeyValuePair<Product, int> product in products)
                            {
                                if (product.Key.Id == unpackedId)
                                {
                                    if (unpackedProducts.ContainsKey(product.Key))
                                    {
                                        unpackedProducts[product.Key]++;
                                    }
                                    else
                                    {
                                        unpackedProducts[product.Key] = 1;
                                    }
                                    break;
                                }
                            }
                        }
                        CalculatePackages(unpackedProducts);
                    }
                }
            }
        }
        #endregion

        #region Format Shipment Address
        string FormatShipmentAddress(int postId = 0)
        {
            IAddress address;

            if (ShipmentType == "Post")
            {
                address = _PostPointCollection.GetOne(postId);
            }
            else
            {
                address = Cart.Customer;
            }

            return $"Country: {address.AddressCountry}, City: {address.AddressCity}, Street: {address.AddressStreet}, Number: {address.AddressStreetNumber}.";
        }
        #endregion

        #region Constructor Validator
        void ConstructorValidator(Customer customer, string shipmentType, int postId = 0)
        {
            if (shipmentType == "International" && customer.AddressCountry.ToLower() == COUNTRY_TO_SHIP_FROM)
            {
                throw new ArgumentException("Cannot ship an international shipment to the same country.");
            }
            else if (shipmentType == "Post" && postId == 0)
            {
                throw new ArgumentNullException("Please provide a Post Point ID if you want to make a Post shipment.");
            }
            else if (shipmentType == "Post" && _PostPointCollection.GetOne(postId) == null)
            {
                throw new ArgumentException($"Post Point with ID of {postId} not found.");
            }
        }
        #endregion

        #endregion
    }
}

