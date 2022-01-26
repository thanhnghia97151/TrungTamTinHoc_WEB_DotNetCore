using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    [Table("Superstore")]
    public class Superstore
    {
        public int RowId { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipMode { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Segment { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string ProductId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductName { get; set; }
        public decimal Sales { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Profit { get; set; }
    }
}
