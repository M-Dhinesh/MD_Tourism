using Microsoft.EntityFrameworkCore;

namespace FeedbackAPI.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<feedback> Feedbacks { get; set; }
    }
}
