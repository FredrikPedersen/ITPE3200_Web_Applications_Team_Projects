using System;
using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Business.Tickets.Models;
using Vy_TicketPurchase_Core.Repository;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business.Tickets
{
    public class TicketService
    {
        
        private readonly DatabaseContext _databaseContext;

        public TicketService(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public List<ServiceModelTicket> GetAllTickets()
        {
            return _databaseContext.Tickets.Select(t => new ServiceModelTicket
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
        
        public bool SaveTicket(ServiceModelTicket ticket, List<DbStation> stationsFromName) {
            
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
        private static DateTime StringsToDateTime(String date, String time)
        {
            var dateAndTime = date + " " + time;
            return Convert.ToDateTime(dateAndTime);
        }

        //Separates the given name from a string with a full name. Used when creating a ServiceModelTicket from a DbTicket
        private static string SeparateGivenName(string name)
        {
            var nameSplit = name.Split(" ");
            return nameSplit[0];
        }

        //Separates the surname from a string with a full name. Used when creating a ServiceModelTicket from a DbTicket
        private string SeparateLastName(string name)
        {
            var nameSplit = name.Split(" ");
            return nameSplit[nameSplit.Length-1];
            
        }

        private static double GeneratePrice(DbStation fromStation, DbStation toStation, DbPassengerType passengerType)
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

        private DbCustomer CreateNewCustomerFromInput(ServiceModelTicket ticket)
        {
            return new DbCustomer
            {
                Name = ticket.CustomerGivenName + " " + ticket.CustomerLastName,
                Phonenumber = ticket.CustomerNumber
            };
        }

        private DbPassengerType FindTicketPassengerType(string passengerTypeName)
        {
            List <DbPassengerType> passengerTypes = GetAllPassengerTypes();

            foreach (DbPassengerType passengerType in passengerTypes)
            {
                if (passengerTypeName.Equals(passengerType.Type))
                {
                    return passengerType;
                }
            }
            return passengerTypes[0]; //This outcome should never happen, but sets passengerType to Adult if it does.
        }
        
        //temporary method, must be moved into separate service
        public List<DbPassengerType> GetAllPassengerTypes()
        {
            return _databaseContext.PassengerTypes.Select(t => new DbPassengerType
            {
                Id = t.Id,
                Type = t.Type,
                PriceMultiplier = t.PriceMultiplier
            }).ToList();
        }
    }
}