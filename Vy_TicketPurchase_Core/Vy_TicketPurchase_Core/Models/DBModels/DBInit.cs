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

            if (!dbContext.Tickets.Any())
            {
                SeedTickets(dbContext);
            }
            if (!dbContext.TrainLines.Any())
            {
                seedTrainLines(dbContext);
            }
        }

        //Reads csv file with stations and adds them to the dbcontext
        private static void seedStations(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\Models\DBModels\SeedData\stations.csv"))
            {
                var stationSet = new HashSet<string>(); //Using a HashSet so prevent duplicate Stations in the database
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null) //Parse through the CSV-file and add all stations to stationSet
                    {
                        var columns = line.Split(",");
                        stationSet.Add(columns[2]); //The station names are located in the 3rd column in the downloaded file
                    }
                }

                foreach (var stationName in stationSet) //Create a new station object from each station in the set, then add them to the dbContext
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
            
        }

        private static int randomPrice()
        {
            Random rnd = new Random();
            return rnd.Next(39, 500);
        }
    }
}