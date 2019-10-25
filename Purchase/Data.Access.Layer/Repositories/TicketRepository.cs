using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Access.Layer.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TicketRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public List<RepositoryModelTicket> GetAllTickets()
        {
            return _databaseContext.Tickets.Select(t => new RepositoryModelTicket
            {
                Id = t.Id,
                FromStation = t.FromStation.StationName,
                ToStation = t.ToStation.StationName,
                CustomerGivenName = SeparateGivenName(t.DbCustomer.Name),
                CustomerLastName = SeparateLastName(t.DbCustomer.Name),
                CustomerNumber = t.DbCustomer.Phonenumber,
                ValidFromDate = t.ValidFrom.ToShortDateString(),
                ValidFromTime = t.ValidFrom.ToShortTimeString(),
                Price = t.Price,
                PassengerType = t.PassengerType.Type
            }).ToList();
        }

        public bool SaveTicket(RepositoryModelTicket ticket, List<DbStation> stationsFromName)
        {
            DbTicket newTicket = new DbTicket
            {
                FromStation = stationsFromName[0],
                ToStation = stationsFromName[1],
                ValidFrom = StringsToDateTime(ticket.ValidFromDate, ticket.ValidFromTime),
                DbCustomer = CreateNewCustomerFromInput(ticket),
                PassengerType = FindTicketPassengerType(ticket.PassengerType),
                Price = GeneratePrice(stationsFromName[0], stationsFromName[1], FindTicketPassengerType(ticket.PassengerType))
            };

            try
            {
                _databaseContext.Tickets.Add(newTicket);
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method for converting strings with date and time data to a DateTime object. Used when creating a DbTicket from a ServiceModelTicket
        public static DateTime StringsToDateTime(String date, String time)
        {
            var dateAndTime = date + " " + time;
            return Convert.ToDateTime(dateAndTime);
        }

        //Separates the given name from a string with a full name. Used when creating a ServiceModelTicket from a DbTicket
        public static string SeparateGivenName(string name)
        {
            var nameSplit = name.Split(' ');
            return nameSplit[0];
        }

        //Separates the surname from a string with a full name. Used when creating a ServiceModelTicket from a DbTicket
        public string SeparateLastName(string name)
        {
            var nameSplit = name.Split(' ');
            return nameSplit[nameSplit.Length - 1];
        }

        public static double GeneratePrice(DbStation fromStation, DbStation toStation, DbPassengerType passengerType)
        {
            var start = fromStation.NumberOnLine;
            var end = toStation.NumberOnLine;
            var price = 0.0;
            if (start > end)
            {
                price = (start - end) * passengerType.PriceMultiplier;
            }
            else
            {
                price = (end - start) * passengerType.PriceMultiplier;
            }

            return price;
        }

        public DbCustomer CreateNewCustomerFromInput(RepositoryModelTicket ticket)
        {
            return new DbCustomer
            {
                Name = ticket.CustomerGivenName + " " + ticket.CustomerLastName,
                Phonenumber = ticket.CustomerNumber
            };
        }

        public DbPassengerType FindTicketPassengerType(string passengerTypeName)
        {
            //TODO Vi får dobbeltlagring av passasjertyper. UNDERSØK SENERE!
            var passengerTypes = GetAllPassengerTypes();

            foreach (var passengerType in passengerTypes)
            {
                if (passengerType.Type == passengerTypeName)
                {
                    return new DbPassengerType
                    {
                        PriceMultiplier = passengerType.PriceMultiplier,
                        Type = passengerType.Type
                    };
                }
            }
            return passengerTypes[0]; //This outcome should never happen, but sets passengerType to Adult if it does.
        }

        public List<DbPassengerType> GetAllPassengerTypes()
        {
            return _databaseContext.PassengerTypes.Select(t => new DbPassengerType
            {
                Type = t.Type,
                PriceMultiplier = t.PriceMultiplier
            }).ToList();
        }
    }
}