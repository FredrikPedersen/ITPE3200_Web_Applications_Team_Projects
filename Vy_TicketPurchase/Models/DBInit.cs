using System.Collections.Generic;
using System.Data.Entity;

namespace Vy_TicketPurchase.Models
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            var route1 = new Route()
            {
                startlocation = "Oslo S",
                stoplocation = "Lillestrøm",
                price = 30,
                travelTimeMinutes = 15,
            };

            context.Routes.Add(route1);
            base.Seed(context);
        }
    }
}