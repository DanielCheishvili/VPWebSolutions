using System;
using System.Collections.Generic;
using System.Linq;

namespace VPWebSolutions.Data.Entities
{
    public enum PizzaSize
    {
        Small,
        Medium,
        Large,
    }
    public class Pizza : MenuItem
    {
        public PizzaSize Size { get; set; }
        public string PizzaType { get; set; }

    }
}
