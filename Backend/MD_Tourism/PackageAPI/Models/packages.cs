using System.ComponentModel.DataAnnotations;

namespace PackageAPI.Models
{
    public class packages
    {
        [Key]
        public int packageId { get; set; }
        public int? AgencyId { get; set; }
        public string? destination { get; set; }
        public string? DepartureCity { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? No_Days { get; set; }
        public int? No_Nights { get; set; }
        public string? FoodIncluded { get; set; }
        public string? AccommodationIncluded { get; set; }
        public string? TourType { get; set; }
        public string? description { get;set; }
        public int? available { get; set; }
        public int? Price { get; set; }
        public string? Places { get; set; }
    }
}
