using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AccountAPI.Models
{
    public class Context:DbContext
    {
        static string pass = "admin";
        static HMACSHA512 hmac = new HMACSHA512();
        Byte[] PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass));
        Byte[] PasswordKey = hmac.Key;

        public Context(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

    }
}
