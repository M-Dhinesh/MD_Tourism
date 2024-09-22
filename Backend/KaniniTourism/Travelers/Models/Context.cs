using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Travelers.Models
{
   
    
        public class Context : DbContext
        {
            static string pass = "admin";
            static HMACSHA512 hmac = new HMACSHA512();
            Byte[] PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass));
            Byte[] PasswordKey = hmac.Key;
            public Context(DbContextOptions options) : base(options)
            {


            }
        public DbSet<Traveler> Travellers { get; set; }
        public DbSet<TravelerUser> TravelUsers { get; set; }
        public DbSet<TravelerFeedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TravelerUser>().HasData(
                new TravelerUser
                {
                    UserId = 1,
                    EmailId = "admin@gmail.com",
                    PasswordHash = PasswordHash,
                    PasswordKey = PasswordKey,
                    Role = "Admin"
                });
        }
    }
}


