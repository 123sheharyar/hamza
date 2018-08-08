using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebApplication29.Controllers
{
    public class mailController : Controller
    {
        // GET: mail

       
        public ActionResult Index()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Index(string to, string from, string pass,string sub, string msg)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;

                MailMessage mail = new MailMessage(from,to);
                mail.Subject = sub;
                mail.IsBodyHtml = true;
                mail.Body = "<html><p><b>Hello </b></p></html>";

                smtp.Credentials = new NetworkCredential(from, pass);
                smtp.Send(mail);
                ViewBag.msg = "mail sent!";





            }
            catch(Exception ex)
            {

                ViewBag.msg = ex.Message;
            }


            return View();
        }
    }
}