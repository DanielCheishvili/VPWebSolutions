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
        [Display(Name = "Order total")]
        public float OrderTotal { get; set; }
        public UserData UserData { get; set; }
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }
        public int IdCustomer { get; set; }
        public string DeliveryGuyId { get; set; }
        [Display(Name = "Is guest user")]
        public bool isGuestUser { get; set; }
        [Display(Name = "Delivery Address")]
        public string OrderAddress { get; set; }
        [Display(Name = "Preparing start time")]
        public DateTime? PreparingStartTime { get; set; }
        [Display(Name = "Preparing done time")]
        public DateTime? PreparingDoneTime { get; set; }
        public string Type { get; set; }
    }
}
