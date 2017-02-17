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
    public class MedlemsController : Controller
    {
        private Garage2_5Context db = new Garage2_5Context();

        // GET: Medlems
        public ActionResult Index()
        {
            return View(db.Medlems.ToList());
        }

        // GET: Medlems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medlem medlem = db.Medlems.Find(id);
            if (medlem == null)
            {
                return HttpNotFound();
            }
            return View(medlem);
        }

        // GET: Medlems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medlems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FörNamn,EfterNamn")] Medlem medlem)
        {
            if (ModelState.IsValid)
            {
                db.Medlems.Add(medlem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medlem);
        }

        // GET: Medlems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medlem medlem = db.Medlems.Find(id);
            if (medlem == null)
            {
                return HttpNotFound();
            }
            return View(medlem);
        }

        // POST: Medlems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FörNamn,EfterNamn")] Medlem medlem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medlem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medlem);
        }

        // GET: Medlems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medlem medlem = db.Medlems.Find(id);
            if (medlem == null)
            {
                return HttpNotFound();
            }
            return View(medlem);
        }

        // POST: Medlems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medlem medlem = db.Medlems.Find(id);
            db.Medlems.Remove(medlem);
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
