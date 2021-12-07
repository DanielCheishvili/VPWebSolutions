
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPWebSolutions.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        [ForeignKey("MenuItem_Id")]
        public MenuItem MenuItem { get; set; }
        
        [Required]
        public int MenuItem_Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Order Order { get; set; }
        public int OrderFK { get; set; }
    }
}
