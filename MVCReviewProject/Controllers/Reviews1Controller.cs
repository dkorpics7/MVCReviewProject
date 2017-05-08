using System;
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
    public class Reviews1Controller : Controller
    {
        private MVCReviewProjectContext db = new MVCReviewProjectContext();

        // GET: Reviews1
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Category).Include(r => r.Nature);
            return View(reviews.ToList());
        }

        // GET: Reviews1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews1/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Island");
            ViewBag.NatureID = new SelectList(db.Natures, "ID", "Type");
            return View();
        }

        // POST: Reviews1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Author,Attraction,Date,Headline,Comment,Rating,Price,FileLocation,SubmissionDate,CategoryID,NatureID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Island", review.CategoryID);
            ViewBag.NatureID = new SelectList(db.Natures, "ID", "Type", review.NatureID);
            return View(review);
        }

        // GET: Reviews1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Island", review.CategoryID);
            ViewBag.NatureID = new SelectList(db.Natures, "ID", "Type", review.NatureID);
            return View(review);
        }

        // POST: Reviews1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Author,Attraction,Date,Headline,Comment,Rating,Price,FileLocation,SubmissionDate,CategoryID,NatureID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Island", review.CategoryID);
            ViewBag.NatureID = new SelectList(db.Natures, "ID", "Type", review.NatureID);
            return View(review);
        }

        // GET: Reviews1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
