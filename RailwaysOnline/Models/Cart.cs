using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaysOnline.Models
{
    public class Cart
    {
        public const string SESSION_CART = "Cart";
        private List<Reservation> reservations = new List<Reservation>();

        public virtual void AddReservation(Reservation reservation, int quantity = 1)
        {
            Reservation itemReservation = reservations.FirstOrDefault(r => r.Journey.Id == reservation.Journey.Id && r.Class == reservation.Class);
            
            // Already in the cart
            if (null != itemReservation)
            {
                itemReservation.Seats += quantity;
            }
            else
            {
                reservation.Seats+=quantity;
                reservations.Add(reservation);
            }

        }

        public virtual void RemoveReservation(Reservation reservation) 
            => reservations.RemoveAll(r => r.Id == reservation.Id);

        public IEnumerable<Reservation> Reservations => reservations;

        public decimal TotalCosts => reservations.Sum(r => r.Price);
    }
}
