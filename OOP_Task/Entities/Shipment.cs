using OOP_Task.Collections;
using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Entities;
using CromulentBisgetti.ContainerPacking.Algorithms;

namespace OOP_Task.Entities
{
    class Shipment: Entity
    {
        private List<Package> AllPackages = new FileCollection<Package>().GetAll();
        
        private Dictionary<string, double> ShipmentPrices = new Dictionary<string, double>
        {
            ["International"] = 15.99,
            ["Courier"] = 4.99,
            ["Post"] = 2.99
        };

        public Cart Cart { set; get; }
        private List<Package> Packages = new List<Package>();
        public double TotalPrice { get; set; }

        private string shipmentType;
        public string ShipmentType 
        { 
          get
            {
                return shipmentType;
            }
          set
            {
                if (!ShipmentPrices.Keys.ToArray().Contains(value))
                {
                    throw new ArgumentException();
                }
                shipmentType = value;
            }
        }

        public Shipment(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) { }

        public Shipment(int id, Cart cart, string shipmentType): base(id)
        {
            Cart = cart;
            CalculatePackages(Cart.Products);
            ShipmentType = shipmentType;
            TotalPrice = Cart.TotalPrice + ShipmentPrices[shipmentType];
        }
        
        void CalculatePackages(List<Product> products)
        {
            List<Package> resultPackages = new List<Package>();

            for (int i = 0; i < AllPackages.Count; i++) 
            {
                List<Container> packages = new List<Container>
                {
                    new Container(AllPackages[i].Id, AllPackages[i].Width, AllPackages[i].Length, AllPackages[i].Height)
                };

                List<Item> productsToPack = new List<Item>();

                foreach (Product product in products)
                {
                    productsToPack.Add(new Item(product.Id, product.Width, product.Length, product.Height, 1));
                }

                List<int> packingAlgorithms = new List<int>();
                packingAlgorithms.Add((int)AlgorithmType.EB_AFIT);

                List<ContainerPackingResult> packingResults = PackingService.Pack(packages, productsToPack, packingAlgorithms);

                List<Item> unpackedProducts = packingResults[0].AlgorithmPackingResults[0].UnpackedItems;
            
                if (unpackedProducts.Count != 0)
                {
                    if (i == AllPackages.Count - 1)
                    {
                        Packages.Add(AllPackages[i]);

                        List<int> unpackedIds = new List<int>();

                        foreach (Item product in unpackedProducts)
                        {
                            unpackedIds.Add(product.ID);
                        }

                        CalculatePackages(products.Where(x => unpackedIds.Contains(x.Id)).ToList());
                    }
                    else
                    {
                        continue;
                    }
                }

                Packages.Add(AllPackages[i]);

                break;
            }
        }
    }
}



