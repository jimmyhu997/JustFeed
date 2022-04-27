using System.ComponentModel.DataAnnotations;

namespace JustFeedBackend.Models
{
    public class Dish_type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        public ICollection<Resturant> Resturants { get; set; }
    }
}
