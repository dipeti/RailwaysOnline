using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RailwaysOnline.Models
{
    public enum Cities { Brussels, London, Paris, Amsterdam, Berlin}
    public class Journey
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Cities FromCity { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Cities ToCity { get; set; }
        public int BusinessSeats { get; set; }
        public int EconomySeats { get; set; }

    }
}
