using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPWebSolutions.Data.Entities
{
    public enum OrderStatus
    {
        PENDING,
        ORDERED,
        COOKED,
        SHIPPED,
        DELIVERED,
        CANCELED,
    }
    public class Order
    {
        public const double TAX = 0.15;
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}
