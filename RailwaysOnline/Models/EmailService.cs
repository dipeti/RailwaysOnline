using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace RailwaysOnline.Models
{
    public class EmailService : IEmailService
    {
        public async void SendNotificationEmail(User user, IEnumerable<Reservation> reservations)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("dipeti@live.com", "Peter Dinya");
            var subject = "Your reservation have been saved!";
            var to = new EmailAddress(user.Email, user.UserName);
            StringBuilder sb = new StringBuilder();
            foreach (var reservation in reservations)
            {
                sb.Append(reservation.ToString()).Append("/n");
            }
            var plainTextContent = sb.ToString();
            var htmlContent = "<strong>Hello, Email from the helper! [SendSingleEmailAsync]</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
