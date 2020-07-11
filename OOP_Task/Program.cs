using OOP_Task.Collections;
using OOP_Task.Entities;
using System;
using System.Collections.Generic;

namespace OOP_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Product> products = new List<Product>
            {
                new Product(1, "Product1", "Description1", 19.99, 5, 5, 5),
                // new Product(2, "Product2", "Description2", 9.99, 5, 5, 5),
                // new Product(3, "Product3", "Description3", 5.99, 5, 5, 5),
                // new Product(4, "Product4", "Description4", 4.99, 5, 5, 5),
                // new Product(5, "Product5", "Description5", 20.99, 10, 20, 20)
            };

            Customer customer = new Customer(1, "Juras", "Rabacauskas", "Lithuania", "Kedainiai", "Lauko", 17, 12);

            Cart cart = new Cart(1, customer, products);

            Shipment shipment = new Shipment(1, cart, "Internatizonal");

            foreach(var x in shipment.Packages)
            {
                Console.WriteLine(x.Type);
            }

            // Shipment shipment = new Shipment(1, cart);

            Console.ReadLine();
        }
    }
}