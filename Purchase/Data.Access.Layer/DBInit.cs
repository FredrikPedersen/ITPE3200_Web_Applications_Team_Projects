using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Model.DBModels;

namespace Data.Access.Layer
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

            if (!dbContext.Departures.Any())
            {
                SeedDepartures(dbContext);
            }
        }

        private static List<DbStation> SeedStations(DatabaseContext dbContext, string stations)
        {
            string[] separator = {", "};
            var stationNames = stations.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var numberOnLine = 1;
            List<DbStation> stationList = new List<DbStation>();

            foreach (var stationName in stationNames)
            {
                var stationFromFile = new DbStation
                {
                    StationName = stationName,
                    NumberOnLine = numberOnLine
                };
                dbContext.Add(stationFromFile);
                stationList.Add(stationFromFile);
                numberOnLine++;
            }
            dbContext.SaveChanges();
            return stationList;
        }

        private static void SeedTrainLines(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\Files\SeedData\lines.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var columns = line.Split('|');
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
            var typeAdult = new DbPassengerType
            {
                Type = "Voksen",
                PriceMultiplier = 1.0
            };
            var typeSenior = new DbPassengerType
            {
                Type = "Honør",
                PriceMultiplier = 0.5
            };
            var typeStudent = new DbPassengerType
            {
                Type = "Student",
                PriceMultiplier = 0.7
            };
            var typeChild = new DbPassengerType
            {
                Type = "Barn",
                PriceMultiplier = 0.5
            };

            dbContext.Add(typeAdult);
            dbContext.Add(typeSenior);
            dbContext.Add(typeStudent);
            dbContext.Add(typeChild);

            dbContext.SaveChanges();
        }

        private static void SeedDepartures(DatabaseContext dbContext)
        {
            for (var i = 0; i < 23; i++)
            {
                var time = i + ":00";

                if (i < 10)
                {
                    time = "0" + time;
                }
                
                var newDeparture = new DbDepartures
                {
                    DepartureTime = time
                };
                dbContext.Add(newDeparture);
            }
            
            dbContext.SaveChanges();
        }
    }
}