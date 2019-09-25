using Microsoft.EntityFrameworkCore;

namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}