using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OOP_Task.Entities
{
    public class Customer: Entity, IAddress
    {
        #region Public Properties
        #region Name
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Customer name should be atleast 5 characters long.");
                }
                _Name = value;
            }
        }
        #endregion

        #region Surname
        private string _Surname;
        public string Surname
        {
            get { return _Surname; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Customer name should be atleast 5 characters long.");
                }
                _Surname = value;
            }
        }
        #endregion

        #region Address Country
        private string _AddressCountry;
        public string AddressCountry
        {
            get { return _AddressCountry; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Customer address country should be atleast 5 characters long.");
                }
                _AddressCountry = value;
            }
        }
        #endregion

        #region Address City
        private string _AddressCity;
        public string AddressCity
        {
            get { return _AddressCity; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Customer address city should be atleast 5 characters long.");
                }
                _AddressCity = value;
            }
        }
        #endregion

        #region Address Street
        private string _AddressStreet;
        public string AddressStreet
        {
            get { return _AddressStreet; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Customer address street should be atleast 5 characters long.");
                }
                _AddressStreet = value;
            }
        }
        #endregion

        #region Address Street Number
        private int _AddressStreetNumber;
        public int AddressStreetNumber
        {
            get { return _AddressStreetNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Customer address street nummber cannot be 0.");
                }
                _AddressStreetNumber = value;
            }

        }
        #endregion
        #endregion

        #region Constructors 
        public Customer() { }

        public Customer(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) { }

        public Customer(int id, string name, string surname, string addressCountry, string addressCity, string addressStreet, int addressStreetNumber): base(id)
        {
            Name = name;
            Surname = surname;
            AddressCountry = addressCountry;
            AddressCity = addressCity;
            AddressStreet = addressStreet;
            AddressStreetNumber = addressStreetNumber;
        }

        public Customer(string name, string surname, string addressCountry, string addressCity, string addressStreet, int addressStreetNumber)
        {
            Name = name;
            Surname = surname;
            AddressCountry = addressCountry;
            AddressCity = addressCity;
            AddressStreet = addressStreet;
            AddressStreetNumber = addressStreetNumber;
        }
        #endregion
    }
}
