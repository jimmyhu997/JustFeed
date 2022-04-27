using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustFeedBackend.Models
{
    [Table("Dishes")]
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool Available { get; set; }
        public string Picture { get; set; } = string.Empty;
        [Required]
        public int Resturant_id { get; set; }
        public Resturant Resturant { get; set; }

        public int Dish_CategoriesID { get; set; }
        public Dish_categories Dish_Categories { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
