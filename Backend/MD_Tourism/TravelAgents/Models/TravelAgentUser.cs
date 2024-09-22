using System.ComponentModel.DataAnnotations;

namespace TravelAgents.Models
{
    public class TravelAgentUser
    {
        [Key]
        public int UserId { get; set; }
        public string? EmailId { get; set; }
        public string? Role { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
    }
}
