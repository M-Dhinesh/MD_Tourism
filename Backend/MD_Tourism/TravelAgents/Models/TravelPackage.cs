using System.ComponentModel.DataAnnotations;

namespace TravelAgents.Models
{
    public class TravelPackage
    {
        [Key]
        public int Id { get; set; }
        public int? AgencyID { get; set; }
        public string? AgencyName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }   
        public string? Country { get; set; }
        public string? About { get; set; }
        public int Rate { get; set; }
        public string? Days { get; set; }
        public string? TransportType { get; set; }
        public Boolean? TransportAccommidation { get; set; }
        public Boolean? FoodAccommidation { get; set;}
        public Boolean? StayingAccommidation { get; set; }
        public string? Discount { get; set; }    
        public string[]? Places { get; set; }
    }
}
