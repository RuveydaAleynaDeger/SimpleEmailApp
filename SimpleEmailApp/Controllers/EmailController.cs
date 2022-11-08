using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleEmailApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("deangelo.flatley@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("deangelo.flatley@ethereal.email"));
            email.Subject = "Test email subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            //gmail hotmail vb gelebilir
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("deangelo.flatley@ethereal.email", "NB4ysAFc6rN4VDVd1v");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();


        }
    }
}

