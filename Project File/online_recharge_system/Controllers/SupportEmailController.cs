using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using online_recharge_system.Models;

namespace online_recharge_system.Controllers
{
    public class SupportEmailController : Controller
    {
        // GET: SupportEmail
        public ActionResult Supportlog()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Supportlog(SupportEmail ec)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://192.168.2.156:80/api/SupportEmailAPI/Supportlog");

            var consumeapi = hc.PostAsJsonAsync<SupportEmail>("Email", ec);
            consumeapi.Wait();

            var sendmail = consumeapi.Result;
            if (sendmail.IsSuccessStatusCode)
            {
                ViewBag.support = "THE MAIL SUCCESSFULLY SENT";
            }
            return View();
        }
    }
}