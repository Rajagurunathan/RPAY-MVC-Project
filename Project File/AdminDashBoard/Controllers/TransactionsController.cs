using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminDashBoard.Models;

namespace AdminDashBoard.Controllers
{
    public class TransactionsController : Controller
    {
        private Recharge1Entities db = new Recharge1Entities();



        // GET: Transactions

        [Route("Transactions/Index")]
        public ActionResult Index()
        {
            ViewBag.admin = Session["adminid"];
            var transactions = db.Transactions.Include(t => t.Operator).Include(t => t.Plan).Include(t => t.User);
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View(transactions.ToList());
        }

        
        public ActionResult Details()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            var transactions = db.Transactions.Include(t => t.Operator).Include(t => t.Plan).Include(t => t.User);
            return View(transactions.ToList());
        }

        [Route("Transactions/DetailsWithId/{id ?}")]
        // GET: Transactions/Details/5
        public ActionResult DetailsWithId(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            ViewBag.operator_id = new SelectList(db.Operators, "operator_id", "operator_name");
            ViewBag.plan_id = new SelectList(db.Plans, "plan_id", "plan_name");
            ViewBag.userid = new SelectList(db.Users, "userid", "name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "transaction_id,date_time,userid,plan_id,operator_id,phone_number,status")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.operator_id = new SelectList(db.Operators, "operator_id", "operator_name", transaction.operator_id);
            ViewBag.plan_id = new SelectList(db.Plans, "plan_id", "plan_name", transaction.plan_id);
            ViewBag.userid = new SelectList(db.Users, "userid", "name", transaction.userid);
            return View(transaction);
        }

       
        public ActionResult IndexEdit()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            var transactions = db.Transactions.Include(t => t.Operator).Include(t => t.Plan).Include(t => t.User);
            return View(transactions.ToList());
        }

      
        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.operator_id = new SelectList(db.Operators, "operator_id", "operator_name", transaction.operator_id);
            ViewBag.plan_id = new SelectList(db.Plans, "plan_id", "plan_name", transaction.plan_id);
            ViewBag.userid = new SelectList(db.Users, "userid", "name", transaction.userid);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transaction_id,date_time,userid,plan_id,operator_id,phone_number,status")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.operator_id = new SelectList(db.Operators, "operator_id", "operator_name", transaction.operator_id);
            ViewBag.plan_id = new SelectList(db.Plans, "plan_id", "plan_name", transaction.plan_id);
            ViewBag.userid = new SelectList(db.Users, "userid", "name", transaction.userid);
            return View(transaction);
        }


     
        public ActionResult IndexDelete()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            var transactions = db.Transactions.Include(t => t.Operator).Include(t => t.Plan).Include(t => t.User);
            return View(transactions.ToList());
        }


       

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
