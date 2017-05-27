using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(0,200)]
        public int BusinessSeats { get; set; }
        [Range(0, 200)]
        public int EconomySeats { get; set; }

        public decimal Price { get; set; }
        public decimal PriceBusinessClass => Decimal.Multiply(Price, 2);

        public int GetAvailableSeats(Classes classes)
        {
            if (classes == Classes.Business)
            {
                return BusinessSeats;
            }
            else if (classes == Classes.Economy)
            {
                return EconomySeats;
            }
            return 0;
        }

        public string ValidateJourney(Classes selectedClass, int seats)
        {
            int availableSeats = GetAvailableSeats(selectedClass);
            if (availableSeats == 0)
            {
                return "No seat(s) left.";
            }
            else if (availableSeats < seats || seats == 5)
            {
                return $"Only {availableSeats} seat(s) left.";
            }
            return String.Empty;
        }

    }
}
