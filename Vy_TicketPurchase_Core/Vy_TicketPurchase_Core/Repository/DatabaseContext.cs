using Microsoft.EntityFrameworkCore;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<DbTicket> Tickets { get; set; }
        public DbSet<DbStation> Stations { get; set; }
        public DbSet<DbTrainLine> TrainLines { get; set; }
        public DbSet<DbPassengerType> PassengerTypes { get; set; }
    }
}