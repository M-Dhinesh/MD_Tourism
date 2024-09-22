using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Reservation> Reservations { get; set; }    
        public DbSet<Passengers> Tour_Travellers { get; set; }
    }
}
