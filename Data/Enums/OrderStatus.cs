using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VPWebSolutions.Data.Enums
{
    public enum OrderStatus
    {
        ORDERED,
        PREPARING,
        READY,
        IN_DELIVERY,
        DELIVERED,
        CANCELED,
        COOKED,
    }
}
