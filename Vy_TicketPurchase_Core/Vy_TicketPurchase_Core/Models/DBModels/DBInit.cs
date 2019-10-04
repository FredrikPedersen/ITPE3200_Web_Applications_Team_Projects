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

            if (!dbContext.Tickets.Any())
            {
                SeedTickets(dbContext);
            }
            if (!dbContext.TrainLines.Any())
            {
                seedTrainLines(dbContext);
            }
        }
        
        private static List<DbStation> seedStations(DatabaseContext dbContext, string stations)
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

        //Method used for seeding some hardcoded example tickets to the database. Used for testing functionality, to be removed later.
        private static void SeedTickets(DatabaseContext dbContext)
        {
            var ticket1 = new DbTicket
            {
                DbCustomer = new DbCustomer
                {
                    Name = "Per Kåre Ostepop",
                    Phonenumber = "87356783"
                },
                FromStation = "Lillestrøm",
                ToStation = "Oslo S",
                ValidFrom = new DateTime(2019, 11, 02, 12, 05, 00),
                Price = randomPrice()
            };

            var ticket2 = new DbTicket
            {
                DbCustomer = new DbCustomer
                {
                    Name = "Julie Z Nilsen ",
                    Phonenumber = "99106201"
                },
                FromStation = "Eidsvoll",
                ToStation ="Lysaker",
                ValidFrom = new DateTime(2018, 01, 15, 17, 47, 00),
                Price = randomPrice()
            };
            dbContext.Add(ticket1);
            dbContext.Add(ticket2);
            dbContext.SaveChanges();
        }

        private static void seedTrainLines(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\Models\DBModels\SeedData\lines.csv"))
            {
                while (!reader.EndOfStream)
                {
                    
                    var line = reader.ReadLine();
                    if (line != null) //Parse through the CSV-file and add all stations to stationSet
                    {
                        var columns = line.Split("|");
                        DbTrainLine lineFromFile = new DbTrainLine
                        {
                            Name = columns[0],
                            Stations = seedStations(dbContext, columns[1])
                        };
                        dbContext.Add(lineFromFile);
                    }
                }
            }
            dbContext.SaveChanges();
            }

        private static int randomPrice()
        {
            Random rnd = new Random();
            return rnd.Next(39, 500);
        }
    }
}