using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Vy_TicketPurchase.Models
{
    public class DB : DbContext
    {
        public DB() : base("name = Ticket")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
        }
        
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Route> Routes { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}