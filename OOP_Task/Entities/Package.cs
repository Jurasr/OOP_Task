using System;
using System.Collections.Generic;
using System.Reflection;

namespace OOP_Task.Entities
{
    public class Package : Entity
    {
        #region Public Properties
        #region Type
        private string _Type;
        public string Type 
        { 
            get { return _Type; } 
            set { _Type = value; }
        }
        #endregion

        #region Width
        private double _Width;
        public double Width
        {
            get { return _Width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Package width should be greater than 0.");
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
                    throw new ArgumentOutOfRangeException("Package length should be greater than 0.");
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
                    throw new ArgumentOutOfRangeException("Package height should be greater than 0.");
                }
                _Height = value;
            }
        }
        #endregion 
        #endregion

        #region Constructors
        public Package() { }

        public Package(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) { }

        public Package(int id, string type, double length, double width, double height) : base(id)
        {
            Type = type;
            Length = length;
            Width = width;
            Height = height;
        }

        public Package(string type, double length, double width, double height)
        {
            Type = type;
            Length = length;
            Width = width;
            Height = height;
        }
        #endregion
    }
}
