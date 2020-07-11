using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Algorithms;
using CromulentBisgetti.ContainerPacking.Entities;
using Microsoft.SqlServer.Server;
using OOP_Task.Collections;
using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OOP_Task.Entities
{
    class Product : Entity
    {
        private List<Package> Packages = new FileCollection<Package>().GetAll();

        private string title;
        public string Title 
        { 
            get { return title; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Product title should be atleast 5 characters long.");
                }
                title = value;
            }
        }

        private string description;
        public string Description 
        { 
            get { return description; }
            set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentOutOfRangeException("Product description should be atleast 10 characters long.");
                }
                title = value;
            }
        }

        private double price;
        public double Price 
        { 
            get { return price; } 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Product price should be higher than 0.");
                }
            }
        }

        private decimal width;
        public decimal Width 
        { 
            get { return width; } 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Product width should be higher than 0.");
                }
            }
        }

        private decimal length;
        public decimal Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Product length should be higher than 0.");
                }
            }
        }

        private decimal height;
        public decimal Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Product height should be higher than 0.");
                }
            }
        }

        public Product() { }

        public Product(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) 
        {
            if (PackageHelpers.ValidateProductSize(this, Packages) == false)
            {
                throw new ArgumentException();
            }
        }

        public Product(int id, string title, string description, double price, decimal width, decimal length, decimal height): base(id)
        {
            Title = title;
            Description = description;
            Price = price;
            Width = width;
            Length = length;
            Height = height;

            if (PackageHelpers.ValidateProductSize(this, Packages) == false)
            {
                throw new ArgumentException();
            }
        }

        public Product(string title, string description, double price, decimal width, decimal length, decimal height)
        {
            Title = title;
            Description = description;
            Price = price;
            Width = width;
            Length = length;
            Height = height;

            if (PackageHelpers.ValidateProductSize(this, Packages) == false)
            {
                throw new ArgumentException();
            }
        }
    }
}
