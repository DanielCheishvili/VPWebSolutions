using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data.Entities;

namespace VPWebSolutions.Models
{
    public class SalesReportModel
    {
        public List<Order> Orders { get; set; }
        public List<OrderItem> Items { get; set; }

        public SalesReportModel()
        {
            Orders = new List<Order>();
            Items = new List<OrderItem>();
        }
    }
}
