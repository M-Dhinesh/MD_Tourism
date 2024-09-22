using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountAPI.Models
{
    public class Traveller
    {
        public Traveller()
        {
            Name = string.Empty;
            Gender = "Unknown";
        }
        [Key]
        public int TravellerId { get; set; }
        [ForeignKey("TravellerId")]
        public User? Users { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
       
    }
}
