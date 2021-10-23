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
    public class OperatorsController : Controller
    {
        private Recharge1Entities db = new Recharge1Entities();

        // GET: Operators
        public ActionResult Index()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View(db.Operators.ToList());
        }

        public ActionResult IndexEdit()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View(db.Operators.ToList());
        }

        public ActionResult IndexDelete()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View(db.Operators.ToList());
        }


        // GET: Operators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operator @operator = db.Operators.Find(id);
            if (@operator == null)
            {
                return HttpNotFound();
            }
            return View(@operator);
        }

        // GET: Operators/Create
        public ActionResult Create()
        {
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View();
        }

        // POST: Operators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "operator_id,operator_name")] Operator @operator)
        {
            if (ModelState.IsValid)
            {
                db.Operators.Add(@operator);
                db.SaveChanges();
                return RedirectToAction("IndexEdit");
            }

            return View(@operator);
        }

        // GET: Operators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operator @operator = db.Operators.Find(id);
            if (@operator == null)
            {
                return HttpNotFound();
            }
            return View(@operator);
        }

        // POST: Operators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "operator_id,operator_name")] Operator @operator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@operator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexEdit");
            }
            return View(@operator);
        }

        // GET: Operators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operator @operator = db.Operators.Find(id);
            if (@operator == null)
            {
                return HttpNotFound();
            }
            return View(@operator);
        }

        // POST: Operators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operator @operator = db.Operators.Find(id);
            db.Operators.Remove(@operator);
            db.SaveChanges();
            return RedirectToAction("IndexEdit");
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
