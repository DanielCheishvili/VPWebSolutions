using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VPWebSolutions.Data.Enums;
using VPWebSolutions.Models;

namespace VPWebSolutions.Data.Entities
{
    public class Order
    {
        public const double TAX = 0.15;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public float OrderTotal { get; set; }
        public UserData UserData { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }
        //public ApplicationUser Customer { get; set; }
        //TODO Need to remove Customer

        public int IdCustomer { get; set; }
        public string DeliveryGuyId { get; set; }
        public bool isGuestUser { get; set; }
        [Display(Name = "Delivery Address")]
        public string OrderAddress { get; set; }
        public DateTime? PreparingStartTime { get; set; }
        public DateTime? PreparingDoneTime { get; set; }
    }
}
