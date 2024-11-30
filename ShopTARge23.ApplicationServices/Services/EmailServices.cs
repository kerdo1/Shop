using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Core.Dto;
using MimeKit;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using System;
using System.IO;
using Org.BouncyCastle.Crypto.Macs;
using System.Linq;

namespace ShopTARge23.ApplicationServices.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _config;
        public EmailServices(IConfiguration config) 
        { 
            _config = config;
        }

        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();
            //find config location and write variables
            //"EmailHost": "smtp.gmail.com",
            //"EmailUserName": "inde999@gmail.com",
            //"EmailPassword": "teie salas]na"
            email.From.Add(MailboxAddress.Parse("kerdovahk@gmail.com"));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)

            {
                Text = dto.Body
            };

            var builder = new BodyBuilder();
            builder.TextBody = dto.Body;

            if (dto.Attachments != null && dto.Attachments.Count > 0)
            {
                foreach (var file in dto.Attachments)
                {
                    if (file.Length > 0)
                    {
                        string fileName = file.FileName;
                        using var stream = file.OpenReadStream();
                        builder.Attachments.Add(fileName, stream);
                    }
                }
            }

            email.Body = builder.ToMessageBody();
            //kindlasti kasutada mailkit.net.smtp
            using var smtp = new SmtpClient();

            //choose correct port and use secure socket option
            //authenticate
            //send email
            //free resources
  
                try
                {
                    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate("kerdovahk@gmail.com", "tgnk ezub jaxi dvby");
                    smtp.Send(email);
                    Console.WriteLine("Email sent successfully!");
                    
                }
                finally
                {
                    smtp.Disconnect(true);
                }
            }
        }

    }

