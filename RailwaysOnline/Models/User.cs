using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RailwaysOnline.Models
{
    public class User : IdentityUser
    {
        public User(string userName) : base(userName)
        {
          
        }

        public User() : base()
        {
           Reservations = new List<Reservation>();
        }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
