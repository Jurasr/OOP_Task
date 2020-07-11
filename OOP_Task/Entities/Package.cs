using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Entities;
using CromulentBisgetti.ContainerPacking.Algorithms;

namespace OOP_Task.Entities
{
    class Package : Entity
    {
        private char type;
        public char Type 
        { 
            get { return type; } 
            set
            {
                if (!new char[] { 'S', 'M', 'L'}.Contains(value))
                {
                    throw new ArgumentException("Package type can only be S, M or L.")
                }
            }
        }

        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public Package(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) { }

        public Package(int id, char type, decimal length, decimal width, decimal height) : base(id)
        {
            Type = type;
            Length = length;
            Width = width;
            Height = height;
        }
    }

    static class PackageHelpers
    {
        public static bool ValidateProductSize(Product product, List<Package> packages)
        {
            if (packages.Count == 0)
            {
                throw new ArgumentNullException();
            }

            List<Item> productsToPack = new List<Item>
            {
                new Item(product.Id, product.Width, product.Length, product.Height, 1)
            };

            List<int> algorithms = new List<int>();

            algorithms.Add((int)AlgorithmType.EB_AFIT);

            foreach (Package package in packages)
            {
                List<Container> containers = new List<Container>
                {
                    new Container(package.Id, package.Width, package.Length, package.Height)
                };

                List<ContainerPackingResult> result = PackingService.Pack(containers, productsToPack, algorithms);

                List<Item> unpackedItems = result[0].AlgorithmPackingResults[0].UnpackedItems;

                if (unpackedItems.Count == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
