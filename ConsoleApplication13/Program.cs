using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
class Product
{
    public int productId, price, UnitsInStock;
    public string Name;
    public Product(int productId, int price, int unitsInStock, string Name)
    {
        this.productId = productId;
        this.price = price;
        this.UnitsInStock = unitsInStock;
        this.Name = Name;
    }

    class Customer
    {
        public int customerId;
        public string customerName;
        public Customer(int customerId, string Name)
        {
            this.customerId = customerId;
            this.customerName = Name;
        }
    }

    class Order
    {
        public int orderId;
        public DateTime Date;            
        public Product product;
        public Customer customer;

        public Order(int orderId, DateTime Date, Customer customer, Product Name) 
        {
            this.orderId = orderId;
            this.Date = Date;
            this.customer = customer;
            this.product = Name;        
        }
    }


    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        List<Customer> customers = new List<Customer>();
        List<Order> orders = new List<Order>();

        products.Add(new Product(1, 1000, 6, "Mobile"));
        products.Add(new Product(2, 20, 0, "TV"));
        products.Add(new Product(3, 3000, 8, "Watch"));
        products.Add(new Product(4, 40, 9, "Perfume"));
        products.Add(new Product(5, 5000, 0, "WristBands"));

        customers.Add(new Customer(1, "Priyu"));
        customers.Add(new Customer(2, "Shivu"));
        customers.Add(new Customer(3, "Sandy"));
        customers.Add(new Customer(4, "Shravs"));
        customers.Add(new Customer(5, "Sushma"));

        orders.Add(new Order(1, Convert.ToDateTime("1/1/2017"), customers[0],products[0]));
        orders.Add(new Order(2, Convert.ToDateTime("2/1/2017"), customers[1], products[1]));
        orders.Add(new Order(3, Convert.ToDateTime("3/1/2017"), customers[0], products[2]));
        orders.Add(new Order(4, Convert.ToDateTime("4/1/2017"), customers[1], products[3]));
        orders.Add(new Order(5, Convert.ToDateTime("5/2/2017"), customers[2], products[4]));
            
        var ProductsinStock = from item in products
                            where item.UnitsInStock > 0
                            where item.price > 100
                            select item.Name;                         
                            foreach (var item in ProductsinStock)
                            {
                              Console.WriteLine("{0} is in stock", item);                
                            }

         var customerNames =  from order in orders
                              group order by order.customer.customerId into CustomerGroup
                              select new
                              {
                                sum = CustomerGroup.Sum(index => index.product.price),
                                key = CustomerGroup.Key,                                                                                                                                       
                                };
                                                                                   
        var product =       from order in orders
                            group order by order.product.productId into ProductGroup
                            select new
                            {
                                totalNumber = ProductGroup.Count(),
                                key = ProductGroup.Key

                            };
                            foreach (var item in product)
                            {
                                Console.WriteLine(item);
                            }

    var groupedOrders =      from order in orders
                            where DateTime.Compare(order.Date, DateTime.Now.AddDays(-31)) > 0
                            select order.customer.customerName;


                            Console.WriteLine("Customer who bought a product in the last month:");
                            foreach (var element in groupedOrders)
                            {
                            Console.WriteLine(element);
                            }


   var numberOfItems =      from order in orders
                            group order by order.product.productId into ProductGroup
                            select new
                            {
                            value = ProductGroup.Count(),
                            key = ProductGroup.Key
                            };

                            Console.WriteLine("Product Name with the number of times it was bought!");
                            foreach (var element in numberOfItems)
                            Console.WriteLine(element);
                            Console.ReadKey();
        }
    }
}
