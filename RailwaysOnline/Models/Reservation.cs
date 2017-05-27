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

        public decimal Price => Class == Classes.Economy ? Journey.Price * Seats : Journey.PriceBusinessClass * Seats;

        public void AddSeats(int quantity)
        {
            if (Class == Classes.Economy)
            {
                Journey.EconomySeats -= quantity;
            }
            else if (Class == Classes.Business)
            {
                Journey.BusinessSeats -= quantity;
            }
        }
        public void RemoveSeats()
        {
            if (Class == Classes.Economy)
            {
                Journey.EconomySeats += Seats;
            }
            else if (Class == Classes.Business)
            {
                Journey.BusinessSeats += Seats;
            }
        }
    }
}
