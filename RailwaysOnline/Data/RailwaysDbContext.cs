using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RailwaysOnline.Models;

namespace RailwaysOnline.Data
{
    public class RailwaysDbContext : IdentityDbContext<User>
    {
        public RailwaysDbContext(DbContextOptions<RailwaysDbContext> options) : base(options)
        {
            
        }

        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
