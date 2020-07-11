using OOP_Task.Collections;
using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Task.Entities
{
    class Cart : Entity
    {
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }
        public int TotalItems { get; set; }

        public Cart(Dictionary<string, dynamic> propValues, List<PropertyInfo> propInfos) : base(propValues, propInfos) { }

        public Cart(int id, Customer customer, List<Product> products) : base(id)
        {
            Customer = customer;
            Products = products;
            TotalPrice = CalculateTotalPrice(products);
            TotalItems = products.Count;
        }

        double CalculateTotalPrice(List<Product> products)
        {
            return products.Sum(x => x.Price);
        }
    }
}
