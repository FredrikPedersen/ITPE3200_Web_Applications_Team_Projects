using System;
using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Repository;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business
{
    public class DepartureService
    {
        public readonly DatabaseContext _databaseContext;

        public DepartureService(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public List<DbDepartures> GetAllDepartures()
        {
            return _databaseContext.Departures.Select(t => new DbDepartures
            {
                Id = t.Id,
                departureTime = t.departureTime
            }).ToList();
        }

        public List<DbDepartures> GetDeparturesLater(string departureTime)
        {
            List<DbDepartures> departures = GetAllDepartures();
            List<DbDepartures> returnlist = new List<DbDepartures>();
            var splitArray = new string[2];
            splitArray = departureTime.Split(":");
            Console.WriteLine(splitArray[0]);
            Console.WriteLine(splitArray[1]);
            foreach (DbDepartures departure in departures)
            {
                //if ()
                {
                    returnlist.Add(departure);
                }
            }
            return returnlist;
        }

        //Metode for å hente ut alle filer i avgangdatabasen til avganger med knapp for å velge avgang, som er etter valgt tidspunkt
    }
}