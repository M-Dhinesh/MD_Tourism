using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PackageAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<packages> Tourpackages { get; set; }
        public DbSet<gallery> Galleries { get; set; }
    }
}

