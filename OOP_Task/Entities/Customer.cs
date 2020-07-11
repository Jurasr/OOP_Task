using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OOP_Task.Entities
{
    class Customer: Entity
    {
        private string name;
        public string Name 
        { 
            get { return name; } 
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Customer name should be atleast 5 characters long.");
                }
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Customer name should be atleast 5 characters long.");
                }
            }
        }

        private string addressCountry;
        public string AddressCountry
        {
            get { return addressCountry; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Customer address country should be atleast 5 characters long.");
                }
            }
        }

        private string addressCity;
        public string AddressCity
        {
            get { return addressCity; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Customer address city should be atleast 5 characters long.");
                }
            }
        }

        private string addressStreet;
        public string AddressStreet 
        { 
            get { return addressStreet; } 
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Customer address street should be atleast 5 characters long.");
                }
            }
        }

        private int addressStreetNumber;
        public int AddressStreetNumber
        {
            get { return addressStreetNumber; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Customer address street nummber cannot be 0.");
                }
            }

        }

        private int addressFlatNumber;
        public int AddressFlatNumber
        {
            get { return addressStreetNumber; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Customer address flat nummber cannot be 0.");
                }
            }
        }

        public Customer() { }

        public Customer(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) { }

        public Customer(int id, string name, string surname, string addressCountry, string addressCity, string addressStreet, int addressStreetNumber, int addressFlatNumber): base(id)
        {
            Name = name;
            Surname = surname;
            AddressCountry = addressCountry;
            AddressCity = addressCity;
            AddressStreet = addressStreet;
            AddressStreetNumber = addressStreetNumber;
            AddressFlatNumber = addressFlatNumber;
        }

        public Customer(string name, string surname, string addressCountry, string addressCity, string addressStreet, int addressStreetNumber, int addressFlatNumber)
        {
            Name = name;
            Surname = surname;
            AddressCountry = addressCountry;
            AddressCity = addressCity;
            AddressStreet = addressStreet;
            AddressStreetNumber = addressStreetNumber;
            AddressFlatNumber = addressFlatNumber;
        }
    }
}
