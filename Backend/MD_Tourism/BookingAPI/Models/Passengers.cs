using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Passengers
    {
        [Key]
        public int PassengersId { get; set; }
        public int? packageId { get; set; }
        [ForeignKey("id")]
        public string? travellerEmail { get; set; }
        public Reservation? reservation { get; set; }
        public string? Name { get; set; }
        public int? age { get; set; }
    }
}