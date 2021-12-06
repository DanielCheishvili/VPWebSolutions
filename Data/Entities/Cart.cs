using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VPWebSolutions.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public List<OrderItem> CartItems { get; set; }

        public Account Customer { get; set; }
    }
}
