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
    public class PlansController : Controller
    {
        private Recharge1Entities db = new Recharge1Entities();

        [Route("Plans/Index")]

        // GET: Plans
        public ActionResult Index()
        {
            ViewBag.admin = Session["adminid"];
            var plans = db.Plans.Include(p => p.Operator);
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View(plans.ToList());
        }

     
        public ActionResult Details()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            var plans = db.Plans.Include(p => p.Operator);
            return View(plans.ToList());
        }

     
        // GET: Plans/Details/5
        public ActionResult DetailsWithId(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }


        // GET: Plans/Create
        public ActionResult Create()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            ViewBag.operator_id = new SelectList(db.Operators, "operator_id", "operator_name");
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "plan_id,plan_name,plan_description,amount,validity,plan_type,operator_id")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Plans.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.operator_id = new SelectList(db.Operators, "operator_id", "operator_name", plan.operator_id);
            return View(plan);
        }

        

        public ActionResult IndexEdit()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            var plans = db.Plans.Include(p => p.Operator);
            return View(plans.ToList());
        }
      
        // GET: Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.operator_id = new SelectList(db.Operators, "operator_id", "operator_name", plan.operator_id);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "plan_id,plan_name,plan_description,amount,validity,plan_type,operator_id")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexEdit");
            }
            ViewBag.operator_id = new SelectList(db.Operators, "operator_id", "operator_name", plan.operator_id);
            return View(plan);
        }

      
        public ActionResult IndexDelete()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            var plans = db.Plans.Include(p => p.Operator);
            return View(plans.ToList());
        }

      
        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.Plans.Find(id);
            db.Plans.Remove(plan);
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
