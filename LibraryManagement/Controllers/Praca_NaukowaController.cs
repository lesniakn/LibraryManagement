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
    public class Praca_NaukowaController : Controller
    {
        private LibraryManagementDataEntities db = new LibraryManagementDataEntities();

        // GET: Praca_Naukowa
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var praca_Naukowa = db.Praca_Naukowa.Include(p => p.Autor);
            return View(praca_Naukowa.ToList());
        }

        // GET: Praca_Naukowa/Details/5
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Praca_Naukowa praca_Naukowa = db.Praca_Naukowa.Find(id);
            if (praca_Naukowa == null)
            {
                return HttpNotFound();
            }
            return View(praca_Naukowa);
        }

        // GET: Praca_Naukowa/Create
        public ActionResult Create()
        {
            ViewBag.ID_Autora = new SelectList(db.Autor, "ID", "Imie");
            return View();
        }

        // POST: Praca_Naukowa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tytul,ID_Autora,Stan_Magazynowy")] Praca_Naukowa praca_Naukowa)
        {
            if (ModelState.IsValid)
            {
                db.Praca_Naukowa.Add(praca_Naukowa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Autora = new SelectList(db.Autor, "ID", "Imie", praca_Naukowa.ID_Autora);
            return View(praca_Naukowa);
        }

        // GET: Praca_Naukowa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Praca_Naukowa praca_Naukowa = db.Praca_Naukowa.Find(id);
            if (praca_Naukowa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Autora = new SelectList(db.Autor, "ID", "Imie", praca_Naukowa.ID_Autora);
            return View(praca_Naukowa);
        }

        // POST: Praca_Naukowa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tytul,ID_Autora,Stan_Magazynowy")] Praca_Naukowa praca_Naukowa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(praca_Naukowa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Autora = new SelectList(db.Autor, "ID", "Imie", praca_Naukowa.ID_Autora);
            return View(praca_Naukowa);
        }

        // GET: Praca_Naukowa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Praca_Naukowa praca_Naukowa = db.Praca_Naukowa.Find(id);
            if (praca_Naukowa == null)
            {
                return HttpNotFound();
            }
            return View(praca_Naukowa);
        }

        // POST: Praca_Naukowa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Praca_Naukowa praca_Naukowa = db.Praca_Naukowa.Find(id);
            db.Praca_Naukowa.Remove(praca_Naukowa);
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
