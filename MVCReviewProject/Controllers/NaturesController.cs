﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCReviewProject.Models;

namespace MVCReviewProject.Controllers
{
    public class NaturesController : Controller
    {
        private MVCReviewProjectContext db = new MVCReviewProjectContext();

        // GET: Natures
        public ActionResult Index()
        {
            return View(db.Natures.ToList());
        }

        // GET: Natures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nature nature = db.Natures.Find(id);
            if (nature == null)
            {
                return HttpNotFound();
            }
            return View(nature);
        }

        // GET: Natures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Natures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] Nature nature)
        {
            if (ModelState.IsValid)
            {
                db.Natures.Add(nature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nature);
        }

        // GET: Natures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nature nature = db.Natures.Find(id);
            if (nature == null)
            {
                return HttpNotFound();
            }
            return View(nature);
        }

        // POST: Natures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] Nature nature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nature);
        }

        // GET: Natures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nature nature = db.Natures.Find(id);
            if (nature == null)
            {
                return HttpNotFound();
            }
            return View(nature);
        }

        // POST: Natures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nature nature = db.Natures.Find(id);
            db.Natures.Remove(nature);
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
