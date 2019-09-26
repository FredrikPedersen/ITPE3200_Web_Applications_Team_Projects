using Microsoft.EntityFrameworkCore;

namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        
        public DbSet<DbTicket> Tickets { get; set; }
        public DbSet<DbCustomer> Customers { get; set; }
        public DbSet<DbRoute> Routes { get; set; }
    }
}