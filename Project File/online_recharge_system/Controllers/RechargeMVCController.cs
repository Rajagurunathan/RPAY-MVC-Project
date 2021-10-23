using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using online_recharge_system.Models;

namespace online_recharge_system.Controllers
{
    public class RechargeMVCController : Controller
    {
        public SqlConnection con;
        public SqlCommand cmd, cmd1, cmd2,cmd3,cmd4,cmd5;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        string sqlmaincon = ConfigurationManager.ConnectionStrings["mainconRC"].ConnectionString;
        // GET: RechargeMVC
        
        //GET : RechargeMVC : RechargeView

        public ActionResult RechargeView()
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

            if (Session["UserID"]== null)
            {
                return RedirectToAction("ULogin", "UserLogin");
            }
            using (mainconRCEntities db = new mainconRCEntities())
            {
                List<Operator> op = db.Operators.ToList();
                List<Plan> plan = db.Plans.ToList();


                var plans = from o in op
                            join p in plan on o.operator_id equals p.operator_id into table1
                            from p in table1.ToList()
                            orderby o.operator_name ascending

                            select new ViewModel
                            {
                                op = o,
                                plan = p,

                            };

                return View(plans);

            }

        }

        //POST : RechargeMVC : RechargeView(param)

        [System.Web.Mvc.HttpPost]

        public ActionResult RechargeView(RechargeClass rc)
        {
            con = new SqlConnection(sqlmaincon);
            con.Open();

            //--------------SARAVANA CHANGE connection string to mainROC - global connection string ---------//
          
            Session["phone"] = rc.PhoneNumber;
            Session["operatorname"] = rc.NetworkOperator;
            Session["plantype"] = rc.PlanCategory;
            Session["planname"] = rc.PlanName;
            Session["amount"] = rc.Amount;
           

            // ADD EXCEPTION FOR THIS MODULE
            if (Session["phone"] == null || Session["operatorname"]==null || Session["plantype"]==null || Session["planname"]==null||Convert.ToInt32(Session["amount"])==0)
            {
                return RedirectToAction("SendRechargeOtp", "RechargeMVC");
            }

            string q_balance = "select balance from Users where userid ="+Session["UserKey"];  //-------SARAVANA CHANGE SESSION VALUE USERID HERE-----//

            SqlCommand cmd = new SqlCommand(q_balance, con);

            int balance = Convert.ToInt32(cmd.ExecuteScalar());
            Session["balance"] =balance;
         
            if (balance < Convert.ToInt32(Session["amount"]))  //ADD MONEY MODULE
            { 
                Session.Remove("phone");
                Session.Remove("operatorname");
                Session.Remove("plantype");
                Session.Remove("planname");
                Session.Remove("amount");
                return RedirectToAction("UserMoney", "UserMoney");
                //if(bal < planamt) -- add module

            }

           
            if (balance > Convert.ToInt32(Session["amount"]))
            {
                if (Session["amount"] != null)
                {
                    try
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential("minnanjal2500@gmail.com", "300999@krr");
                        smtp.EnableSsl = true;
                        MailMessage mm = new MailMessage();
                        mm.Subject = "Rpay!!!OTP ALERT";
                        Random rn = new Random();
                        Global.otp = rn.Next(10000, 99999).ToString();
                        mm.Body = "Dear " + "Customer " + "Your Otp " + Global.otp + " Thanks";
                        mm.To.Add(Session["UserID"].ToString());
                        string frmailaddress = "minnanjal2500@gmail.com";
                        mm.From = new MailAddress(frmailaddress, "Rpay");
                        try
                        {   if(Convert.ToInt32(Session["amount"])!=0)
                            {
                                smtp.Send(mm);
                                con.Close();
                                return RedirectToAction("SendRechargeOtp", "RechargeMVC");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    return RedirectToAction("RechargeView", "RechargeMVC");
                   
                }
                return RedirectToAction("RechargeView", "RechargeMVC");
            }
         

            return RedirectToAction("SendRechargeOtp", "RechargeMVC");

        }

        public ActionResult SendRechargeOtp()
        {
            if (Global.otp == null)
            {
                return RedirectToAction("RechargeView", "RechargeMVC");
            }
            if (Session["UserID"] == null)
            {
                return RedirectToAction("ULogin", "UserLogin");
            }
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
        [HttpPost]
        public ActionResult SendRechargeOtp(PasswordReset pwd)
        {
              //PAYMENT MODULE
            {
                // 1. Otp Verification


                /*************************************************************/
                // 2. Transact table update

                //// - UPDATING TRANSACTION TABLE
                
                con = new SqlConnection(sqlmaincon);
                con.Open();
                if (Global.otp == pwd.otp)
                {
                    string q_plan_id = "select plan_id from Plans where plan_type = '" + Session["plantype"] +
                                       "' and plan_name = '" + Session["planname"] + "' and amount = " +
                                       Session["amount"];
                    cmd2 = new SqlCommand(q_plan_id, con);
                    int plan_id = Convert.ToInt32(cmd2.ExecuteScalar());
                    string q_operator_id = "select operator_id from Operator where operator_name = '" +
                                           Session["operatorname"] + "'";
                    cmd3 = new SqlCommand(q_operator_id, con);
                    int operator_id = Convert.ToInt32(cmd3.ExecuteScalar());
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string q_transact = " insert into Transactions values(@date,@uid,@pid,@oid,@phno,@status)";
                    cmd4 = new SqlCommand(q_transact, con);
                    cmd4.Parameters.AddWithValue("@date", date);
                    cmd4.Parameters.AddWithValue("@uid",Session["UserKey"]); 
                    //-------SARAVANA CHANGE SESSION VALUE USERID HERE-----//
                    cmd4.Parameters.AddWithValue("@pid", plan_id);
                    cmd4.Parameters.AddWithValue("@oid", operator_id);
                    cmd4.Parameters.AddWithValue("@phno", Session["phone"]);
                    cmd4.Parameters.AddWithValue("@status", "Success");
                    cmd4.ExecuteNonQuery();

                    //// - UPDATING USER TABLE - (DEDUCT BALANCE)
                    string q_bal_update =
                        "update Users set balance = @bal - @amt where userid =" +
                        Session["UserKey"]; //-------SARAVANA CHANGE SESSION VALUE USERID HERE-----//
                    cmd5 = new SqlCommand(q_bal_update, con);
                    cmd5.Parameters.AddWithValue("@bal", Session["balance"]);
                    cmd5.Parameters.AddWithValue("@amt", Session["amount"]);
                    cmd5.ExecuteNonQuery();
                    cmd =new SqlCommand("Select balance from Users where userid="+Session["UserKey"],con);
                    Session["walbal"] = cmd.ExecuteScalar();
                    con.Close();
                    /****************************************************/
                    if (Session["amount"] == null)
                    {
                        return RedirectToAction("RechargeView", "RechargeMVC");
                    }
                    // 3. Email Receipt
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("minnanjal2500@gmail.com", "300999@krr");
                    smtp.EnableSsl = true;
                    MailMessage mm = new MailMessage();
                    mm.Subject = "Rpay!!!RECHARGE SUCCESSFULLY";
                    mm.Body = "Dear " + "Customer " + "Your Recharge of Rupees plan" + Session["amount"] +
                              " is Successfully" + Session[""] + " \nThanks\nWith Regards\nRpay";
                    mm.To.Add(Session["UserID"].ToString());
                    string frmailaddress = "minnanjal2500@gmail.com";
                    mm.From = new MailAddress(frmailaddress, "Rpay");
                    MemoryStream ms = new MemoryStream();
                    Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0.0f);
                    //require custom parsers? add here.
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open(); //open doc for editing
                    doc.Add(new Paragraph("Dear " + "Customer\n " + "Your Transcation of Rupees " + Session["amount"] +
                                          " from wallet to Rpay is Successful. Your Updated Balance is " + Session["walbal"]
                                           + " \nThanks"));
                    //doc.Add(new Paragraph("Second Paragraph"));
                    writer.CloseStream = false; //important
                    doc.Close(); //build the doc.
                    ms.Position = 0; //reset stream... important
                    mm.Attachments.Add(new Attachment(ms, "Invoice.pdf"));
                    try
                    {
                        smtp.Send(mm);
                        Session.Remove("phone");
                        Session.Remove("operatorname");
                        Session.Remove("plantype");
                        Session.Remove("planname");
                        Session.Remove("amount");
                        Session.Remove("balance");
                        Global.otp = null;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }

                if (Global.otp != pwd.otp)
                {
                    ViewBag.incrtotp = "INCORRECT OTP";
                    return RedirectToAction("SendRechargeOtp", "RechargeMVC");
                }

               
            }
            return RedirectToAction("Index", "Home");
        }
    }

}
