using System.Data.Entity;

namespace Vy_TicketPurchase.Models.DBModels
{
    public class DBInit : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var route1 = new Route()
            {
                Startlocation = "Oslo S",
                Stoplocation = "Lillestrøm",
                Price = 30,
                TravelTimeMinutes = 15,
            };

            var route2 = new Route()
            {
                Startlocation = "Trondheim",
                Stoplocation = "Oslo S",
                Price = 1500,
                TravelTimeMinutes = 320,
            };
            
            var route3 = new Route()
            {
                Startlocation = "Bergen",
                Stoplocation = "Oslo S",
                Price = 900,
                TravelTimeMinutes = 180,
            };
            
            context.Routes.Add(route1);
            context.Routes.Add(route2);
            context.Routes.Add(route3);
            base.Seed(context);
        }
    }
}