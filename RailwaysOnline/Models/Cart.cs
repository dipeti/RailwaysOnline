using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaysOnline.Models
{
    public class Cart
    {
        private List<Reservation> reservations = new List<Reservation>();

        public virtual void AddReservation(Reservation reservation, int quantity = 1)
        {
            Reservation itemReservation = reservations.FirstOrDefault(r => r.Journey.Id == reservation.Journey.Id);
            
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
    }
}
