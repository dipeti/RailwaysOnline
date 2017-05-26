using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View(GetCart());
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>(SESSION_CART) ?? new Cart();
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson(SESSION_CART,cart);
        }

        [HttpPost]
        public JsonResult AddToCart(int id, string classes, int seats)
        {
            Journey journey = journeyRepository.Journeys.FirstOrDefault(j => j.Id==id);
            if (null != journey)
            {
                Cart cart = GetCart();
                Classes journeyClasses = (Classes) Enum.Parse(typeof(Classes), classes);
                cart.AddReservation(new Reservation
                {
                    Journey = journey,
                    Class = journeyClasses
                }, seats);
                SaveCart(cart);
                return Json(journey);
            }
            return Json(null);
        }
    }
}