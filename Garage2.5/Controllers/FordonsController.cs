using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2._5.DAL;
using Garage2._5.Models;

namespace Garage2._5.Controllers
{
    public class FordonsController : Controller
    {
        private Garage2_5Context db = new Garage2_5Context();

        // GET: Fordons
        public ActionResult Index()
        {
            var fordons = db.Fordons.Include(f => f.Medlemar);
            return View(fordons.ToList());
        }

        // GET: Fordons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordons.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // GET: Fordons/Create
        public ActionResult Create()
        {
            ViewBag.MedlemId = new SelectList(db.Medlems, "Id", "FörNamn");
            return View();
        }

        // POST: Fordons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FordonsId,Regnr,Märke,Modell,AntalHjul,Parkeringtid,MedlemId,FordonstypId")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Fordons.Add(fordon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedlemId = new SelectList(db.Medlems, "Id", "FörNamn", fordon.MedlemId);
            return View(fordon);
        }

        // GET: Fordons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordons.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedlemId = new SelectList(db.Medlems, "Id", "FörNamn", fordon.MedlemId);
            return View(fordon);
        }

        // POST: Fordons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FordonsId,Regnr,Märke,Modell,AntalHjul,Parkeringtid,MedlemId,FordonstypId")] Fordon fordon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fordon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedlemId = new SelectList(db.Medlems, "Id", "FörNamn", fordon.MedlemId);
            return View(fordon);
        }

        // GET: Fordons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fordon fordon = db.Fordons.Find(id);
            if (fordon == null)
            {
                return HttpNotFound();
            }
            return View(fordon);
        }

        // POST: Fordons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fordon fordon = db.Fordons.Find(id);
            db.Fordons.Remove(fordon);
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
