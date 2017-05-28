using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RailwaysOnline.Data;
using RailwaysOnline.Models;

namespace RailwaysOnline.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private IReservationRepository reservationRepository;
        private UserManager<User> userManager;
        private Cart cart;
        private IEmailService mailer;
        public ReservationController(IReservationRepository repository, Cart cart, UserManager<User> userManager, IEmailService mailer)
        {
            this.reservationRepository = repository;
            this.cart = cart;
            this.userManager = userManager;
            this.mailer = mailer;
        }
        public async Task<RedirectToActionResult> Checkout()
        {
            User user = await userManager.GetUserAsync(User);
            foreach (var reservation in cart.Reservations)
            {
                user.Reservations.Add(reservation);
                reservationRepository.SaveReservation(reservation);
            }
            mailer.SendNotificationEmail(user,cart.Reservations);
            cart.Clear();
            return RedirectToAction(nameof(Show));
        }

        public async Task<ViewResult> Show()
        {
            string username = (await userManager.GetUserAsync(User)).UserName;
           return View(reservationRepository.Reservations.Where(r => r.User.UserName == username));
        } 
        
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