using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using online_recharge_system.Models;

namespace online_recharge_system.Controllers
{
    public class HomeController : Controller
    {
        public SqlConnection con;
        public SqlCommand cmd2;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        string sqlmaincon = ConfigurationManager.ConnectionStrings["mainconRC"].ConnectionString;
        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                con = new SqlConnection(sqlmaincon);
                con.Open();
                cmd2 = new SqlCommand("select balance from Users where userid='" + Session["Userkey"] + "'", con);
                cmd2.ExecuteScalar();
                ViewBag.bal = cmd2.ExecuteScalar().ToString();
                con.Close();

            }
            return View();
        }

        public ActionResult PlanView()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            mainconRCEntities entities = new mainconRCEntities();
            var plans = entities.Plans.Include(m => m.Operator);
            return View(plans.ToList());
        }

    }
}