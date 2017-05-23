using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwaysOnline.Models;

namespace RailwaysOnline.Data
{
    public class RailwaysDbContext : DbContext
    {
        public RailwaysDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Journey> Journeys { get; set; }
    }
}
