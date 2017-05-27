using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RailwaysOnline.Data;
using RailwaysOnline.Infrastructure;
using RailwaysOnline.Models;

namespace RailwaysOnline.Controllers
{
    public class CartController : Controller
    {
        private const string SESSION_CART = "Cart";
        private readonly IJourneyRepository journeyRepository;

        public CartController(IJourneyRepository journeyRepository)
        {
            this.journeyRepository = journeyRepository;
        }

        public ViewResult Index()
        {
            return View(new CartViewModel()
            {
                Cart = GetCart(),
                ReturnUrl = "/",
            });
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>(SESSION_CART) ?? new Cart();
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson(SESSION_CART, cart);
        }

        [HttpPost]
        public JsonResult AddToCart(int id, Classes selectedClass, int seats)
        {
            Journey journey = journeyRepository.Journeys.FirstOrDefault(j => j.Id == id);
            
            if (null != journey)
            {
                string validationMsg = journey.ValidateJourney(selectedClass, seats);
                if (!String.IsNullOrEmpty(validationMsg))
                {
                    return Json(new {Result = false, Message = validationMsg });
                }
                Cart cart = GetCart();
                Reservation reservation = new Reservation
                {
                    Id = cart.Reservations.Count(),
                    Journey = journey,
                    Class = selectedClass
                };
                reservation.AddSeats(seats);
                journeyRepository.Flush();
                cart.AddReservation(reservation, seats);
                SaveCart(cart);
                return Json(journey);
                
            }
            return Json(null);
        }


        public IActionResult RemoveFromCart(int id, string returnUrl)
        {
            Cart cart = GetCart();
            Reservation reservation = cart.Reservations.FirstOrDefault(r => r.Id == id);
            if (null != reservation)
            {
                cart.RemoveReservation(reservation);
                journeyRepository.Persist(reservation.Journey);
                reservation.RemoveSeats();
                
                journeyRepository.Flush();
                SaveCart(cart);
            }
            return RedirectToAction("Index", new {ReturnUrl = returnUrl});
        }
    }
}