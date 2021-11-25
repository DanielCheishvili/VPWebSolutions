
namespace VPWebSolutions.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Order Order { get; set; }
    }
}
