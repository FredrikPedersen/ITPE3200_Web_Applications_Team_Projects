using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Vy_TicketPurchase.Models.DBModels
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name = Ticket")
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