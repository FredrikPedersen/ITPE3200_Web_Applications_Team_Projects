using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DbInit
    {
        public static void Initialize(IServiceScope serviceScope)
        {
            Console.WriteLine("DBINIT'S INITIALIZE IS BEING CALLED");
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
            dbContext.Database.EnsureCreated();

            Console.WriteLine("PRINTING ROUTES.ANY " + dbContext.Routes.Any());
            if (!dbContext.Routes.Any())
            {
                seedRoutes(dbContext);
            }
        }

        private static void seedRoutes(DatabaseContext dbContext)
        {
            Console.WriteLine("SEEDROUTES IS BEING CALLED!");
            using (var reader = new StreamReader(@".\Models\DBModels\SeedData\routes.csv"))
            {
                var count = 10;
                while (count > 0 && !reader.EndOfStream)
                {
                    count--;
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var columns = line.Split("|");
                        var aRoute = new Route
                        {
                            Startlocation = columns[0],
                            Stoplocation = columns[1],
                            TravelTimeMinutes = Int32.Parse(columns[2]),
                            Price = Double.Parse(columns[3])
                        };

                        dbContext.Add(aRoute);
                        Console.WriteLine("HERE IS THE ROUTE: " + aRoute.ToString());
                    }
                }
            }
            dbContext.SaveChanges();
        }
    }
}