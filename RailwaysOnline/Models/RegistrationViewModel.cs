using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaysOnline.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [UIHint("Password")]
        public string Password { get; set; }
        [Required]
        public Languages Languages { get; set; }
    }
}
