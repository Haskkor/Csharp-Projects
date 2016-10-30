using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Providers.Entities;

namespace TestASPMVC.Models
{
    public class TestModels : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    [Table("dbUsers")]
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DbUserId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } 
    }

    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("UserId")]
        public virtual User user { get; set; }
        public virtual Product Product { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; } 
    }

    public class TestContext : DbContext
    {
        public DbSet Users { get; set; }
        public DbSet Purchases { get; set; }
        public DbSet Products { get; set; }
    }
}