using System;
using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Business.Stations.Models;
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
                FromStation = t.FromStation,
                ToStation = t.ToStation,
                CustomerGivenName = SeparateGivenName(t.DbCustomer.Name),
                CustomerLastName = SeparateLastName(t.DbCustomer.Name),
                CustomerNumber = t.DbCustomer.Phonenumber,
                ValidFromDate = t.ValidFrom.ToShortDateString(),
                ValidFromTime = t.ValidFrom.ToShortTimeString(),
                Price = t.Price
            }).ToList();
        }
        
        public bool SaveTicket(ServiceModelTicket ticket) {
            DbCustomer customer = new DbCustomer
            {
                Name = ticket.CustomerGivenName + " " + ticket.CustomerLastName,
                Phonenumber = ticket.CustomerNumber
            };
            
            DbTicket newTicket = new DbTicket
            {
                FromStation = ticket.FromStation,
                ToStation = ticket.ToStation,
                ValidFrom = StringsToDateTime(ticket.ValidFromDate, ticket.ValidFromTime),
                DbCustomer = customer,
                Price = GeneratePrice()
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

        private static int GeneratePrice(ServiceModelStation fromStation, ServiceModelStation toStation)
        {
            //TODO NOT FINISHED
            var start = fromStation.NumberOnLine;
            var end = toStation.NumberOnLine;
            var pricePrStation = 15;
            if (start > end)
            {
                
            }

            return 0;
        }
    }
}