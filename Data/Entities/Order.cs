using System;
using System.Collections.Generic;

namespace VPWebSolutions.Data.Entities
{
    public class Order
    {
        public const double TAX = 0.15;

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public string Status { get; set; }
    }
}
