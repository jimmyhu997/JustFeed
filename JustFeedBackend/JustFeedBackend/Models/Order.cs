using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JustFeedBackend.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Delivery_address { get; set; }
        public string Notes { get; set; }
        public DateTime Creation_time { get; set; } = DateTime.Now;
        public int ResturantID { get; set; }
        public Resturant Resturant { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
