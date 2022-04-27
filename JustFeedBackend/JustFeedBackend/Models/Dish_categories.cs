using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JustFeedBackend.Models
{
    public class Dish_categories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Dish> Dishes { get; set; }

    }
}
