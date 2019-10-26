using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Model.DBModels;

namespace Data.Access.Layer
{
    public class DatabaseContext : AuditDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<DbTicket> Tickets { get; set; }
        public DbSet<DbStation> Stations { get; set; }
        public DbSet<DbTrainLine> TrainLines { get; set; }
        public DbSet<DbPassengerType> PassengerTypes { get; set; }
        public DbSet<DbDepartures> Departures { get; set; }
        public DbSet<DbUser> Users { get; set; }
    }
}