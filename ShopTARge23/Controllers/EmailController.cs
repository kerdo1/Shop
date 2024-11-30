using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models;
using System;

namespace ShopTARge23.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _services;  
   
        public EmailController(IEmailServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Method to send email
        [HttpPost]  
        public IActionResult SendEmail(EmailModel vm)
        {
         
                // Create the email message
                var dto = new EmailDto()
                {
                    To = vm.To,
                    Subject = vm.Subject,
                    Body = vm.Body,
                    Attachments = vm.Attachments?.ToList()


                };
                _services.SendEmail(dto);

            return Ok(new { message = "Email sent" });
        }
    }
}
