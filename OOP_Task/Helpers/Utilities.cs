using CromulentBisgetti.ContainerPacking.Algorithms;
using CromulentBisgetti.ContainerPacking.Entities;
using OOP_Task.Entities;
using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;

namespace OOP_Task.Helpers
{
    public static class Utilities
    {
        #region List To Dict
        public static Dictionary<T, int> ListToDict<T>(List<T> list) where T : IEntity
        {
            Dictionary<T, int> dictionary = new Dictionary<T, int>();

            foreach (T item in list)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary[item] = 1;
                }
            }

            return dictionary;
        }
        #endregion

        #region Validate Product Size
        public static bool ValidateProductSize(Product product, List<Package> packages)
        {
            if (packages.Count == 0)
            {
                throw new ArgumentNullException("There are no packages");
            }

            List<Item> productsToPack = new List<Item>
            {
                new Item(product.Id, (decimal)product.Width, (decimal)product.Length, (decimal)product.Height, 1)
            };

            List<int> algorithms = new List<int>();

            algorithms.Add((int)AlgorithmType.EB_AFIT);

            foreach (Package package in packages)
            {
                List<Container> containers = new List<Container>
                {
                    new Container(package.Id, (decimal)package.Width, (decimal)package.Length, (decimal)package.Height)
                };

                List<ContainerPackingResult> result = CromulentBisgetti.ContainerPacking.PackingService.Pack(containers, productsToPack, algorithms);

                List<Item> unpackedItems = result[0].AlgorithmPackingResults[0].UnpackedItems;

                if (unpackedItems.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
