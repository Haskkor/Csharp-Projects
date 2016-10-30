using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestASPMVC.Models
{
    public class TestInitializer : DropCreateDatabaseIfModelChanges<TestContext>
    {
        protected override void Seed(TestContext context)
        {
            var products = new List<Product>
            {
                new Product {Name = "Widget", Description = "A widget is a widget."},
                new Product {Name = "Cranck", Description = "A cranck for the widget."}
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            var users = new List<User>
            {
                new User {Name = "Joe"},
                new User {Name = "Lillith"}
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var purchases = new List<Purchase>
            {
                new Purchase
                {
                    Product = products.First(p => p.Name == "Widget"),
                    user = users.First(u => u.Name == "Joe")
                }
            };
            purchases.ForEach(pr => context.Purchases.Add(pr));
            context.SaveChanges();
        }
    }
}