using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RailwaysOnline.Infrastructure;

namespace RailwaysOnline.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session.GetJson<SessionCart>(SESSION_CART) ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddReservation(Reservation product, int quantity = 1)
        {
            base.AddReservation(product, quantity);
            Session.SetJson(SESSION_CART, this);
        }

        public override void RemoveReservation(Reservation reservation)   
        {
            base.RemoveReservation(reservation);
            Session.SetJson(SESSION_CART, this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.SetJson(SESSION_CART,this);
        }
    }
}
