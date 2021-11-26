
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPWebSolutions.Data.Entities
{
    public enum MenuItemType
    {
        Pizza,
        Fries,
        Burger,
        Drink,
    }
    public abstract class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Price { get; set; }
        public MenuItemType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageId { get; set; }
    }
}
