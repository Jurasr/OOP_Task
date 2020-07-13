using System;
using System.Collections.Generic;
using System.Reflection;
using OOP_Task.Collections;
using OOP_Task.Helpers;

namespace OOP_Task.Entities
{
    public class Product : Entity
    {
        #region Private Properties
        private List<Package> _Packages = new FileCollection<Package>().GetAll();
        #endregion

        #region Public Properties
        #region Title
        private string _Title;
        public string Title 
        { 
            get { return _Title; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Product title should be atleast 5 characters long.");
                }
                _Title = value;
            }
        }
        #endregion

        #region Description
        private string _Description;
        public string Description 
        { 
            get { return _Description; }
            set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentOutOfRangeException("Product description should be atleast 10 characters long.");
                }
                _Description = value;
            }
        }
        #endregion

        #region Price
        private double _Price;
        public double Price 
        { 
            get { return _Price; } 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Product price should be higher than 0.");
                }
                _Price = value;
            }
        }
        #endregion

        #region Width
        private double _Width { get; set; }
        public double Width 
        { 
            get { return _Width; } 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Product width should be higher than 0.");
                }
                _Width = value;
            }
        }
        #endregion

        #region Length
        private double _Length;
        public double Length
        {
            get { return _Length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Product length should be higher than 0.");
                }
                _Length = value;
            }
        }
        #endregion

        #region Height
        private double _Height;
        public double Height
        {
            get { return _Height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Product height should be higher than 0.");
                }
                _Height = value;
            }
        }
        #endregion
        #endregion

        #region Constructors
        public Product() { }

        public Product(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) 
        {
            
            if (Utilities.ValidateProductSize(this, _Packages) == false)
            {
                throw new ArgumentOutOfRangeException("Product size dimensions are too big to add to a package.");
            }
            
        }

        public Product(int id, string title, string description, double price, double width, double length, double height): base(id)
        {
            Title = title;
            Description = description;
            Price = price;
            Width = width;
            Length = length;
            Height = height;

            if (Utilities.ValidateProductSize(this, _Packages) == false)
            {
                throw new ArgumentOutOfRangeException("Product size dimensions are too big to add to a package.");
            }
           
        }

        public Product(string title, string description, double price, double width, double length, double height)
        {
            Title = title;
            Description = description;
            Price = price;
            Width = width;
            Length = length;
            Height = height;

            if (Utilities.ValidateProductSize(this, _Packages) == false)
            {
                throw new ArgumentOutOfRangeException("Product size dimensions are too big to add to a package.");
            }
        }
        #endregion
    }
}
