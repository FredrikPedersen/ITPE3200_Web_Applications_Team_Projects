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
            //Database.SetInitializer(new DBInit());
            //for å sette inn forhåndslaget data?, krever en DBInit klasse
        }
        public DbSet<Ticket> Billetter { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}