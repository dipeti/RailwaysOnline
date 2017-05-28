using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaysOnline.Models
{
    public interface IEmailService
    {
        void SendNotificationEmail(User user, IEnumerable<Reservation> reservations);
    }
}
