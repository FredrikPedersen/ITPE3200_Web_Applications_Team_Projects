using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Repository
{
    public class DbInit
    {
        public static void Initialize(IServiceScope serviceScope)
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
            dbContext.Database.EnsureCreated();

            if (!dbContext.TrainLines.Any())
            {
                SeedTrainLines(dbContext);
            }
        }
        
        private static List<DbStation> SeedStations(DatabaseContext dbContext, string stations)
        {
            var stationNames = stations.Split(",");
            List<DbStation> staionList = new List<DbStation>();

            foreach (var stationName in stationNames)
            {
                var stationFromFile = new DbStation
                {
                    StationName = stationName
                };
                dbContext.Add(stationFromFile);
                staionList.Add(stationFromFile);
            }
            dbContext.SaveChanges();
            return staionList;
        }

        private static void SeedTrainLines(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\Models\DBModels\SeedData\lines.csv"))
            {
                while (!reader.EndOfStream)
                {
                    
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var columns = line.Split("|");
                        var lineFromFile = new DbTrainLine
                        {
                            Name = columns[0],
                            Stations = SeedStations(dbContext, columns[1])
                        };
                        dbContext.Add(lineFromFile);
                    }
                }
            }
            dbContext.SaveChanges();
        }
    }
}