using System;
using System.ComponentModel.DataAnnotations;
using Audit.EntityFramework;

namespace Model.DBModels
{
    [AuditInclude]
    public class DbTicket
    {
        [Key]
        public int Id { get; set; }
        public DbStation FromStation { get; set; }
        public DbStation ToStation { get; set; }
        public DateTime ValidFrom { get; set; }
        public DbCustomer DbCustomer { get; set; }
        public DbPassengerType PassengerType { get; set; }
        public double Price { get; set; }
    }
}