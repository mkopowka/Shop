using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<QuantityWarehouse> QuantityWarehouses { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportProductQuantity> TransportProductQuantities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public void SaveUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }
        public User getUser()
        {
            string username = System.Web.HttpContext.Current.User.Identity.Name;
            var temp = Users.Where(s => username.Contains(s.Email)).ToList();
            return temp.Count == 1 ? temp.First() : null;
        }
    }
}