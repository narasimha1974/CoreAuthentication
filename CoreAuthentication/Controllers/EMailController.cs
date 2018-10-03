using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CoreAuthentication.CustomValidators;
using Microsoft.AspNetCore.Mvc;

namespace CoreAuthentication.Controllers
{
    public class EMailController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new EmailInfo());
        }

        [HttpPost]
        public async Task<ActionResult> Index(EmailInfo emailInfo)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Send Email using hotmail
            using (SmtpClient smtp = new SmtpClient())
            {
                // replace with sender's email
                string senderemail = "***@hotmail.com";

                MailMessage message = new MailMessage();
                message.To.Add(emailInfo.Email);
                message.From = new MailAddress(senderemail);
                message.Subject = emailInfo.Subject;
                message.Body = "To:" + emailInfo.Name + "\n"
                               + "From: " + senderemail + "\n"
                               + emailInfo.Body;

                NetworkCredential credential = new NetworkCredential
                {
                    UserName = "***@hotmail.com",     // replace with sender's email
                    Password = "***"       // replace with sender's password 
                };
                smtp.Credentials = credential;

                smtp.Host = "smtp.live.com";  //  for hotmail replace it as needed
                smtp.Port = 587;               // for hotmail replace it as needed
                smtp.EnableSsl = true;

                smtp.SendCompleted += ((sender, e) =>
                {
                    if (e.Error == null)
                    {
                        TempData["ResultMessage"] = "true";
                    }
                    else
                    {
                        TempData["ResultMessage"] = "false";
                    }
                });

                try
                {
                    await smtp.SendMailAsync(message);
                }
                catch (Exception e)
                {
                    TempData["ResultMessage"] = "false";
                    return View();
                }
            }            
            return RedirectToAction("Index", "Home");
        }
    }
}