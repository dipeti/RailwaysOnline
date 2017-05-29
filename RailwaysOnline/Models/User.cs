using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Newtonsoft.Json.Converters;

namespace RailwaysOnline.Models
{
    public enum Languages
    {
        fr,
        nl,
        en
    }
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
        public Languages Language { get; set; }

    }
}
