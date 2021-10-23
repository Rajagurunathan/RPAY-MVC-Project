using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using online_recharge_system.Models;

namespace emailapi.Controllers
{
    public class GmailsendController : Controller
    {
        // GET: Gmailsend
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailClass ec)
        {
            HttpClient hc =new HttpClient();
            hc.BaseAddress=new Uri("https://localhost:44314/api/Email");

            var consumeapi = hc.PostAsJsonAsync<EmailClass>("Email", ec);
            consumeapi.Wait();

            var sendmail = consumeapi.Result;
            if (sendmail.IsSuccessStatusCode)
            {
                ViewBag.message = "THE MAIL SUCCESSFULLY SENT TO " + ec.to.ToString();
            }
            return View();
        }
    }
}