using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class WydawcaController : Controller
    {
        private LibraryManagementDataEntities db = new LibraryManagementDataEntities();

        // GET: Wydawca
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Wydawca.ToList());
        }

        // GET: Wydawca/Details/5
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wydawca wydawca = db.Wydawca.Find(id);
            if (wydawca == null)
            {
                return HttpNotFound();
            }
            return View(wydawca);
        }

        // GET: Wydawca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wydawca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa")] Wydawca wydawca)
        {
            if (ModelState.IsValid)
            {
                db.Wydawca.Add(wydawca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wydawca);
        }

        // GET: Wydawca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wydawca wydawca = db.Wydawca.Find(id);
            if (wydawca == null)
            {
                return HttpNotFound();
            }
            return View(wydawca);
        }

        // POST: Wydawca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa")] Wydawca wydawca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wydawca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wydawca);
        }

        // GET: Wydawca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wydawca wydawca = db.Wydawca.Find(id);
            if (wydawca == null)
            {
                return HttpNotFound();
            }
            return View(wydawca);
        }

        // POST: Wydawca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wydawca wydawca = db.Wydawca.Find(id);
            db.Wydawca.Remove(wydawca);
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
