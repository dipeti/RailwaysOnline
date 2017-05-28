using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RailwaysOnline.Data;
using RailwaysOnline.Models;

namespace RailwaysOnline.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationRepository reservationRepository;
        private Cart cart;
        public ReservationController(IReservationRepository repository, Cart cart)
        {
            reservationRepository = repository;
            this.cart = cart;
        }
        public RedirectToActionResult Checkout()
        {
            foreach (var reservation in cart.Reservations)
            {
                reservationRepository.SaveReservation(reservation);
            }
            cart.Clear();
            return RedirectToAction(nameof(Show));
        }

        public ViewResult Show() => View(reservationRepository.Reservations);
        public IActionResult Cancel(int id)
        {
            var reservation = reservationRepository.Reservations.FirstOrDefault(r => r.Id == id);
            if (null != reservation)
            {
                reservation.RemoveSeats();
                reservationRepository.Flush();
                reservationRepository.DeleteReservation(reservation);
            }
            return RedirectToAction(nameof(Show));
        }
    }

    
}