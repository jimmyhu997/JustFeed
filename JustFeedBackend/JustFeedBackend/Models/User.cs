using System.ComponentModel.DataAnnotations;

namespace JustFeedBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Surname { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
        [Required]
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.Today;

        public List<Resturant> Resturants { get; set; }
        public List<Order> Orders { get; set; }
    }
}
