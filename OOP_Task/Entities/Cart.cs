using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OOP_Task.Entities
{
    public class Cart : Entity
    {
        #region Public Properties

        #region Customer
        private Customer _Customer;
        public Customer Customer 
        { 
            get { return _Customer; } 
            set { _Customer = value; }
        }
        #endregion

        #region Products
        private List<Product> _Products;
        public List<Product> Products 
        { 
            get { return _Products; }
            set { _Products = value; }
        }
        #endregion

        #region Total Price
        private double _TotalPrice;
        public double TotalPrice 
        { 
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }
        #endregion

        #region Total Items
        private int _TotalItems;
        public int TotalItems 
        { 
            get { return _TotalItems; }
            set { _TotalItems = value; }
        }
        #endregion

        #endregion

        #region Constructors
        public Cart() { }

        public Cart(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) { }

        public Cart(int id, Customer customer, List<Product> products) : base(id)
        {
            Customer = customer;
            Products = products;
            TotalPrice = CalculateTotalPrice(products);
            TotalItems = products.Count;
        }

        public Cart(Customer customer, List<Product> products)
        {
            Customer = customer;
            Products = products;
            TotalPrice = CalculateTotalPrice(products);
            TotalItems = products.Count;
        }
        #endregion

        #region Calculate Total Price
        double CalculateTotalPrice(List<Product> products)
        {
            return products.Sum(x => x.Price);
        }
        #endregion
    }
}
