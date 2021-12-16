using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VPWebSolutions.Data.Entities;
using VPWebSolutions.Models;

namespace VPWebSolutions.Logic
{
    public class CartActions
    {
        public static List<OrderItem> listItems = new List<OrderItem>();

        public static double total {get; set;}
    }
}
