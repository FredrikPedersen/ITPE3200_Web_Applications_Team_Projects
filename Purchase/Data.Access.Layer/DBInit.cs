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
                seedDepartures(dbContext);
            }
        }

        private static List<DbStation> SeedStations(DatabaseContext dbContext, string stations)
        {
            string[] separator = {", "};
            string[] stationNames = stations.Split(separator, StringSplitOptions.RemoveEmptyEntries);
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

        private static void seedDepartures(DatabaseContext dbContext)
        {

            var departures0 = new DbDepartures {departureTime = "00:00"};
            var departures1 = new DbDepartures {departureTime = "01:00"};
            var departures2 = new DbDepartures {departureTime = "02:00"};
            var departures3 = new DbDepartures {departureTime = "03:00"};
            var departures4 = new DbDepartures {departureTime = "04:00"};
            var departures5 = new DbDepartures {departureTime = "05:00"};
            var departures6 = new DbDepartures {departureTime = "06:00"};
            var departures7 = new DbDepartures {departureTime = "07:00"};
            var departures8 = new DbDepartures {departureTime = "08:00"};
            var departures9 = new DbDepartures {departureTime = "09:00"};
            var departures10 = new DbDepartures {departureTime = "10:00"};
            var departures11 = new DbDepartures {departureTime = "11:00"};
            var departures12 = new DbDepartures {departureTime = "12:00"};
            var departures13 = new DbDepartures {departureTime = "13:00"};
            var departures14 = new DbDepartures {departureTime = "14:00"};
            var departures15 = new DbDepartures {departureTime = "15:00"};
            var departures16 = new DbDepartures {departureTime = "16:00"};
            var departures17 = new DbDepartures {departureTime = "17:00"};
            var departures18 = new DbDepartures {departureTime = "18:00"};
            var departures19 = new DbDepartures {departureTime = "19:00"};
            var departures20 = new DbDepartures {departureTime = "20:00"};
            var departures21 = new DbDepartures {departureTime = "21:00"};
            var departures22 = new DbDepartures {departureTime = "22:00"};
            var departures23 = new DbDepartures {departureTime = "23:00"};
            
            dbContext.Add(departures0);
            dbContext.Add(departures1);
            dbContext.Add(departures2);
            dbContext.Add(departures3);
            dbContext.Add(departures4);
            dbContext.Add(departures5);
            dbContext.Add(departures6);
            dbContext.Add(departures7);
            dbContext.Add(departures8);
            dbContext.Add(departures9);
            dbContext.Add(departures10);
            dbContext.Add(departures11);
            dbContext.Add(departures12);
            dbContext.Add(departures13);
            dbContext.Add(departures14);
            dbContext.Add(departures15);
            dbContext.Add(departures16);
            dbContext.Add(departures17);
            dbContext.Add(departures18);
            dbContext.Add(departures19);
            dbContext.Add(departures20);
            dbContext.Add(departures21);
            dbContext.Add(departures22);
            dbContext.Add(departures23);
            
            dbContext.SaveChanges();
        }
    }
}