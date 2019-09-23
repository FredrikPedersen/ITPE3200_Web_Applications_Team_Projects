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

            var route2 = new Route()
            {
                startlocation = "Trondheim",
                stoplocation = "Oslo S",
                price = 1500,
                travelTimeMinutes = 320,
            };
            
            var route3 = new Route()
            {
                startlocation = "Bergen",
                stoplocation = "Oslo S",
                price = 900,
                travelTimeMinutes = 180,
            };
            
            context.Routes.Add(route1);
            context.Routes.Add(route2);
            context.Routes.Add(route3);
            base.Seed(context);
        }
    }
}