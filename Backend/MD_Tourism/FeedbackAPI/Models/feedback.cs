using System.ComponentModel.DataAnnotations;

namespace FeedbackAPI.Models
{
    public class feedback
    {
        [Key]
        public int feedbackID { get; set; }
        public string? travellerEmail { get; set; }
        public int? TourPackageId { get; set; } 
        public string? Comment { get; set; }
        public int? AgencyId { get; set; }
        public int? Ratings { get; set; }
        public DateTime? FeedbackDate { get; set; }
    }
}
