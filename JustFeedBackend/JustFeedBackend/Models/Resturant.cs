using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustFeedBackend.Models
{
    public class Resturant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Description { get; set; } = String.Empty;
        [Required]
        public string Phone_number { get; set; } = String.Empty;
        [Required]
        public string Address { get; set; } = String.Empty;
        // use the Data annotation for declare with type is the information
        [Required]
        public double Longitude { get; set; } = 0;
        [Required]
        public double Latitude { get; set; } = 0;
        [Required]
        public float Min_order { get; set; } = 0;
        [Required, Column(TypeName = "tinyint")]
        public int Range_delivery { get; set; } = 0;
        [Required]
        public float delivery_charge { get; set; } = 0;
        // Declaration of the foreign Key
        public int UserID { get; set; } = 0;
        public User User { get; set; }
        public ICollection<Dish_type> Dish_types { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<Order> Orders { get; set; }
    }
}
