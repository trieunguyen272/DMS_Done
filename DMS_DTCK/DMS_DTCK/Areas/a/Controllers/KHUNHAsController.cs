using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace DMS_DTCK.Areas.a.Controllers
{
    public class KHUNHAsController : Controller
    {
        private QLKTXDbContext db = new QLKTXDbContext();

        // GET: a/KHUNHAs
        public ActionResult Index()
        {
            return View(db.KHUNHAs.ToList());
        }

        // GET: a/KHUNHAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUNHA kHUNHA = db.KHUNHAs.Find(id);
            if (kHUNHA == null)
            {
                return HttpNotFound();
            }
            return View(kHUNHA);
        }

        // GET: a/KHUNHAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: a/KHUNHAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKHU,TENKHU,MOTAKHAC")] KHUNHA kHUNHA)
        {
            if (ModelState.IsValid)
            {
                db.KHUNHAs.Add(kHUNHA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHUNHA);
        }

        // GET: a/KHUNHAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUNHA kHUNHA = db.KHUNHAs.Find(id);
            if (kHUNHA == null)
            {
                return HttpNotFound();
            }
            return View(kHUNHA);
        }

        // POST: a/KHUNHAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKHU,TENKHU,MOTAKHAC")] KHUNHA kHUNHA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHUNHA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHUNHA);
        }

        // GET: a/KHUNHAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUNHA kHUNHA = db.KHUNHAs.Find(id);
            if (kHUNHA == null)
            {
                return HttpNotFound();
            }
            return View(kHUNHA);
        }

        // POST: a/KHUNHAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHUNHA kHUNHA = db.KHUNHAs.Find(id);
            db.KHUNHAs.Remove(kHUNHA);
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
