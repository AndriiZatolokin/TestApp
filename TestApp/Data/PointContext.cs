using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Data
{
    public class PointContext : DbContext
    {
        public PointContext(DbContextOptions<PointContext> options)
            : base(options)
        {
        }

        public DbSet<Point> Points { get; set; }

    }
}
