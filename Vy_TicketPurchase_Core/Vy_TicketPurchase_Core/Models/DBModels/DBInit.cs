using System;
using System.Collections.Generic;
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
                seedStations(dbContext);
            } 
        }

        //Reads csv file with stations and adds them to the dbcontext
        private static void seedStations(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\Models\DBModels\SeedData\stations.csv"))
            {
                var stationSet = new HashSet<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var columns = line.Split(",");
                        stationSet.Add(columns[2]);
                    }
                }

                foreach (var stationName in stationSet)
                {
                    var stationFromFile = new DbStation
                    {
                        StationName = stationName
                    };
                    dbContext.Add(stationFromFile);
                }
            }
            dbContext.SaveChanges();
        }
    }
}