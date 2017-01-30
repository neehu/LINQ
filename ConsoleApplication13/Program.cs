using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication13
{


    class Product
    {
        public int ID, price, UIS;
        public string Name;
        public Product(int ID, int price, int UIS, string Name)
        {
            this.ID = ID;
            this.price = price;
            this.UIS = UIS;
            this.Name = Name;
        }

        class Customer
        {
            public int ID;
            public string Name;
            public Customer(int ID, string Name)
            {
                this.ID = ID;
                this.Name = Name;
            }
        }

        class Order
        {
            public int ID;
            public DateTime Date;            
            public Product product;
            public Customer customer;

            public Order(int ID, DateTime Date, Customer custom, Product Name) 
            {
                this.ID = ID;
                this.Date = Date;
                this.customer = custom;
                this.product = Name;        
            }
        }


        static void Main(string[] args)
        {
            List<Product> product = new List<Product>();
            List<Customer> customer = new List<Customer>();
            List<Order> order = new List<Order>();

            product.Add(new Product(1, 1000, 6, "Mobile"));
            product.Add(new Product(2, 20, 0, "Watch"));
            product.Add(new Product(3, 3000, 8, "Purse"));
            product.Add(new Product(4, 40, 9, "Perfume"));
            product.Add(new Product(5, 5000, 0, "Shoes"));

            customer.Add(new Customer(1, "Priyu"));
            customer.Add(new Customer(2, "Shivu"));
            customer.Add(new Customer(3, "Sandy"));
            customer.Add(new Customer(4, "Shravs"));
            customer.Add(new Customer(5, "Sushma"));

            order.Add(new Order(1, Convert.ToDateTime("1/1/2017"), customer[0],product[0]));
            order.Add(new Order(2, Convert.ToDateTime("2/1/2017"), customer[1], product[1]));
            order.Add(new Order(3, Convert.ToDateTime("3/1/2017"), customer[0], product[2]));
            order.Add(new Order(4, Convert.ToDateTime("4/1/2017"), customer[1], product[3]));
            order.Add(new Order(5, Convert.ToDateTime("5/2/2017"), customer[2], product[4]));
            
            var result = from item in product
                         where item.UIS > 0
                         where item.price > 100
                         select item.Name;
                         

            foreach (var item in result)
            {
              Console.WriteLine("{0} is in stock", item);
                
            }
            var result1 = from orders in order
                              group orders by orders.customer.ID into CG
                              select new
                              {
                                  value = CG.Sum(index => index.product.price),
                                  key = CG.Key
                              };
                              foreach (var item in result1)
                              {
                                 Console.WriteLine(item);

                              }

            var result2 =      from orders in order
                               group orders by orders.product.ID into CG
                               select new
                               {
                                   value = CG.Count(),
                                   key = CG.Key

                               };
                                foreach (var item in result2)
                                {
                                    Console.WriteLine(item);

                                }
                     var last = from orders in order
                       group orders by orders.product.ID into CG
                       select new
                       {
                           value = CG.Count(),
                           key = CG.Key
                       };

            Console.WriteLine("Product Name with the number of times it was bought!");
            foreach (var k in last)
                Console.WriteLine(k);












            Console.ReadKey();

            }
        }
    }
