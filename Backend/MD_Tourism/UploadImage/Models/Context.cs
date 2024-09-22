using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UploadImage.Models;

public class Context : DbContext
    {
        public DbSet<Image> Images { get; set; }

    }
