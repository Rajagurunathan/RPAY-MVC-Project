using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using online_recharge_system.Models;

namespace online_recharge_system.Controllers
{
    public class MyPlansMVCController : Controller
    {

        public SqlConnection con;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public SqlCommand cmd2;
        string sqlmaincon = ConfigurationManager.ConnectionStrings["mainconRC"].ConnectionString;

        public ActionResult UserPlans()
        {
            // try
            // {
                if (Session["UserID"] != null)
                {

                    con = new SqlConnection(sqlmaincon);
                    con.Open();
                    cmd2 = new SqlCommand("select balance from Users where userid='" + Session["Userkey"] + "'", con);
                    cmd2.ExecuteScalar();
                    ViewBag.bal = cmd2.ExecuteScalar().ToString();
                    con.Close();

                }
            // }
            // catch (Exception)
            // {
            //     return RedirectToAction("Index", "Home");
            // }
            
            //ViewBag.name = dr["name"].ToString();
            try
            {
                con = new SqlConnection(sqlmaincon);
                con.Open();
                string q_phone = "select phone_number from Users where userid =" + Session["UserKey"];
                SqlCommand cmd1 = new SqlCommand(q_phone, con);
                string ph_no = cmd1.ExecuteScalar().ToString();
                string phonenumber = ph_no;
                string q_user = "select TOP 1 U.name,O.operator_name,T.phone_number,P.plan_name,P.plan_description,P.amount,P.validity,T.date_time  from Operator as" +
                                " O full outer join Plans as P on O.operator_id = P.operator_id full outer join Transactions as T on P.plan_id = T.plan_id full outer join Users as" +
                                " U on T.userid = U.userid where T.phone_number = '" + phonenumber + "' order by t.date_time desc";
                SqlCommand cmd2 = new SqlCommand(q_user, con);
                // //T.userid =@uid and
                // cmd2.Parameters.AddWithValue("@uid", Session["UserKey"]);
                dr = cmd2.ExecuteReader();
                dr.Read();
                ViewBag.operatorname = dr["operator_name"].ToString();
                ViewBag.phone = dr["phone_number"];
                ViewBag.planname = dr["plan_name"];
                ViewBag.plandesc = dr["plan_description"];
                ViewBag.amount = dr["amount"];
                ViewBag.validity = dr["validity"];
                ViewBag.date = Convert.ToDateTime(dr["date_time"]);
            }
            catch (Exception)
            {
                Session["nodata"] ="NO RECORDS FOUND";
                return RedirectToAction("Index", "Home");
            } 
           

            using (mainconRCEntities db = new mainconRCEntities())
            {
                List<Operator> op = db.Operators.ToList();
                List<Plan> plan = db.Plans.ToList();
                List<User> user = db.Users.ToList();
                List<Transaction> transact = db.Transactions.ToList();


                var plans = from o in op
                            join p in plan on o.operator_id equals p.operator_id into table1
                            from p in table1.ToList()
                            join t in transact on p.plan_id equals t.plan_id into table2
                            from t in table2.ToList()
                            join u in user on t.userid equals u.userid into table3
                            from u in table3.ToList()
                            where u.userid == Convert.ToInt32(Session["UserKey"])
                            orderby t.date_time descending

                            select new ViewModel
                            {
                                op = o,
                                plan = p,
                                user = u,
                                transact = t
                            };

                return View(plans);
            }
        }

    }
}