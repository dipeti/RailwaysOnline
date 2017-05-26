using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaysOnline.Models
{
    public class JourneyViewModel
    {
        [Required(ErrorMessage = "Starting station must NOT be empty!")]
        public string From { get; set; }
        [Required(ErrorMessage = "Destination station must NOT be empty!")]
        public string To { get; set; }
        [Required(ErrorMessage = "Date must NOT be empty!")]
        public DateTime Date { get; set; }
        public IEnumerable<Journey> Journeys { get; set; }

    }
}
