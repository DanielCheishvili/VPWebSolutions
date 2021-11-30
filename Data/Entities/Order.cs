using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data.Entities
{
    public enum OrderStatus
    {
        PENDING,
        ORDERED,
        COOKED,
        OUT_FOR_DELIVERY,
        DELIVERED,
        CANCELED,
    }
    public class Order
    {
        public const double TAX = 0.15;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Order Id")]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string DeliveryGuyId { get; set; }
        public ApplicationUser Customer {get; set;}
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}
