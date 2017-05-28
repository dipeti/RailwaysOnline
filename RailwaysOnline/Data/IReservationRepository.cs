using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RailwaysOnline.Models;

namespace RailwaysOnline.Data
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> Reservations { get; }
        Reservation DeleteReservation(Reservation reservation);
        void SaveReservation(Reservation reservation);
        void Flush();
    }
}
