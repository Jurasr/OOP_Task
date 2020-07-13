using System;
using System.Collections.Generic;
using System.Reflection;
using OOP_Task.Interfaces;

namespace OOP_Task.Entities
{
    public class PostPoint: Entity, IAddress
    {
        #region Public Properties

        #region Address Country
        private string addressCountry;
        public string AddressCountry
        {
            get { return addressCountry; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Customer address country should be atleast 5 characters long.");
                }
                addressCountry = value;
            }
        }
        #endregion

        #region Address City
        private string addressCity;
        public string AddressCity
        {
            get { return addressCity; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Customer address city should be atleast 5 characters long.");
                }
                addressCity = value;
            }
        }
        #endregion

        #region Address Street
        private string addressStreet;
        public string AddressStreet
        {
            get { return addressStreet; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Customer address street should be atleast 5 characters long.");
                }
                addressStreet = value;
            }
        }
        #endregion

        #region Address Street Number
        private int addressStreetNumber;
        public int AddressStreetNumber
        {
            get { return addressStreetNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Customer address street nummber should be greater than 0.");
                }
                addressStreetNumber = value;
            }
        }
        #endregion

        #endregion

        #region Constructors
        public PostPoint() { }

        public PostPoint(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) { }

        public PostPoint(int id, string addressCountry, string addressCity, string addressStreet, int addressStreetNumber) : base(id)
        {
            AddressCountry = addressCountry;
            AddressCity = addressCity;
            AddressStreet = addressStreet;
            AddressStreetNumber = addressStreetNumber;
        }

        public PostPoint(string addressCountry, string addressCity, string addressStreet, int addressStreetNumber)
        {
            AddressCountry = addressCountry;
            AddressCity = addressCity;
            AddressStreet = addressStreet;
            AddressStreetNumber = addressStreetNumber;
        }
        #endregion
    }
}
