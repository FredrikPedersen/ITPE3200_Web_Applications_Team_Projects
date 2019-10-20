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

            if (!dbContext.PassengerTypes.Any())
            {
                SeedPassengerTypes(dbContext);
            }
        }

        private static List<DbStation> SeedStations(DatabaseContext dbContext, string stations)
        {
            var stationNames = stations.Split(", ");
            var numberOnLine = 1;
            List<DbStation> staionList = new List<DbStation>();

            foreach (var stationName in stationNames)
            {
                var stationFromFile = new DbStation
                {
                    StationName = stationName,
                    NumberOnLine = numberOnLine
                };
                dbContext.Add(stationFromFile);
                staionList.Add(stationFromFile);
                numberOnLine++;
            }
            dbContext.SaveChanges();
            return staionList;
        }

        private static void SeedTrainLines(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\Repository\DBModels\SeedData\lines.csv"))
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

        private static void SeedPassengerTypes(DatabaseContext dbContext)
        {
            var typeAdult = new DbPassengerType { Type = "Adult" };
            var typeSenior = new DbPassengerType { Type = "Senior" };
            var typeStudent = new DbPassengerType { Type = "Student" };

            dbContext.Add(typeAdult);
            dbContext.Add(typeSenior);
            dbContext.Add(typeStudent);

            dbContext.SaveChanges();
        }

        private static void seedDepartures(DatabaseContext dbContext)
        {
            var departure1 = new DBDepartures { departureTime = "11.00" };
            var departure2 = new DBDepartures { departureTime = "12.00" };
            var departure3 = new DBDepartures { departureTime = "13.00" };
            var departure4 = new DBDepartures { departureTime = "14.00" };
            var departure5 = new DBDepartures { departureTime = "15.00" };
            var departure6 = new DBDepartures { departureTime = "16.00" };
            var departure7 = new DBDepartures { departureTime = "17.00" };
            var departure8 = new DBDepartures { departureTime = "18.00" };
            var departure9 = new DBDepartures { departureTime = "19.00" };

            dbContext.Add(departure1);
            dbContext.Add(departure2);
            dbContext.Add(departure3);
            dbContext.Add(departure4);
            dbContext.Add(departure5);
            dbContext.Add(departure6);
            dbContext.Add(departure7);
            dbContext.Add(departure8);
            dbContext.Add(departure9);

            dbContext.SaveChanges();
        }
    }
}