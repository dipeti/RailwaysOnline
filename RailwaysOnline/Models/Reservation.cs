using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaysOnline.Models
{
    public enum Classes
    {
        Business, Economy
    }
    public class Reservation
    {
        public int Id { get; set; }
        public Journey Journey { get; set; }
        public Classes Class { get; set; }
        public int Seats { get; set; }
    }
}
