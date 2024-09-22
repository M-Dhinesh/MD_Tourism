using System.ComponentModel.DataAnnotations;

namespace TravelAgents.Models
{
    public class TravelAgentFeedback
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public DateTime? Time { get; set; }
        public string? Message { get; set; }
    }
}
