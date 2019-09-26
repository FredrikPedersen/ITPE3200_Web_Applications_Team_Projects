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
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
            dbContext.Database.EnsureCreated();
            
            if (!dbContext.Routes.Any())
            {
                seedRoutes(dbContext);
            }
        }

        private static void seedRoutes(DatabaseContext dbContext)
        {
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
                    }
                }
            }
            dbContext.SaveChanges();
        }
    }
}