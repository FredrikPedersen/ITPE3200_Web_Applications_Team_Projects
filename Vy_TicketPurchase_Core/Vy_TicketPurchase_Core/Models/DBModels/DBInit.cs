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
            
            if (!dbContext.Stations.Any())
            {
                seedRoutes(dbContext);
            }
        }

        //Reads csv file with routes and adds them to the dbcontext
        private static void seedRoutes(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\Models\DBModels\SeedData\routes.csv"))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var columns = line.Split("|");
                        var routeFromFile = new DbStation
                        {
                            StationName = columns[0],
                        };

                        dbContext.Add(routeFromFile);
                    }
                }
            }
            dbContext.SaveChanges();
        }
    }
}