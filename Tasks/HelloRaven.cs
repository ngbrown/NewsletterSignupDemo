namespace Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Security.Policy;

    using Raven.Client.Document;

    public class HelloRaven
    {
        private static DocumentStore store;

        static HelloRaven()
        {
            store = new DocumentStore { Url = "http://localhost:8080" };
            store.Initialize();
        }

        public void Run(string[] args)
        {
            using (var session = store.OpenSession())
            {
                var product = new Product
                    {
                        Cost = 3.99m,
                        Name = "Milk"
                    };

                session.Store(product);
                session.SaveChanges();

                session.Store(new Order
                    {
                        Customer = "customer/ayende",
                        OrderLines =
                            {
                                new OrderLine
                                    {
                                        ProductId = product.Id,
                                        Quantity = 3
                                    },
                            }
                    });
                session.SaveChanges();
            }
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }

    public class Order
    {
        public string Id { get; set; }
        public string Customer { get; set; }
        public IList<OrderLine> OrderLines { get; set; }

        public Order()
        {
            OrderLines = new List<OrderLine>();
        }
    }

    public class OrderLine
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}