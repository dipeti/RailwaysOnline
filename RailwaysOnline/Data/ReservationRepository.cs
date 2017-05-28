using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RailwaysOnline.Models;

namespace RailwaysOnline.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private RailwaysDbContext context;

        public ReservationRepository(RailwaysDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Reservation> Reservations => context.Reservations.Include(r => r.Journey);
        public void SaveReservation(Reservation reservation)
        {
//            if (reservation.Id == 0)
//            {
                context.Attach(reservation.Journey);
                context.Reservations.Add(reservation);
                
//            }
//            else
//            {
//                Reservation dbEntry = context.Reservations.FirstOrDefault(p => p.Id == reservation.Id);
//                if (dbEntry != null)
//                {
//                    dbEntry.Class = reservation.Class;
//                    dbEntry.Seats = reservation.Seats;
//                }
//            }
            context.SaveChanges();
        }

        public Reservation DeleteReservation(Reservation reservation)
        {
            
            if (reservation != null)
            {
                context.Reservations.Remove(reservation);
                context.SaveChanges();
            }
            return reservation;
        }

        

        public void Flush()
        {
            context.SaveChanges();
        }
    }
}
