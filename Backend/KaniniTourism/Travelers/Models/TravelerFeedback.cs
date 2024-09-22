using System.ComponentModel.DataAnnotations;

namespace Travelers.Models
{
    public class TravelerFeedback
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public DateTime? Time { get; set; }
        public string? Message { get; set; }
    }
}
