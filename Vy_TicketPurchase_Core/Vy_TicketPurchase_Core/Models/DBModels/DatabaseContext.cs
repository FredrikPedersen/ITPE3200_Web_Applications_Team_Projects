using Microsoft.EntityFrameworkCore;
using Vy_TicketPurchase_Core.Services.Tickets.Models;

namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<DbTicket> Tickets { get; set; }
        public DbSet<DbCustomer> Customers { get; set; }
        public DbSet<DbStation> Stations { get; set; }
<<<<<<< HEAD
=======
        public DbSet<DbTrainLine> TrainLines { get; set; }
>>>>>>> origin/MartinaBrack
    }
}