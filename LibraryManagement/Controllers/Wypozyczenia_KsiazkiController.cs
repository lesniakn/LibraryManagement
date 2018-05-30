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
    public class Wypozyczenia_KsiazkiController : Controller
    {
        private LibraryManagementDataEntities db = new LibraryManagementDataEntities();

        // GET: Wypozyczenia_Ksiazki
        public ActionResult Index()
        {
            var wypozyczenia_Ksiazki = db.Wypozyczenia_Ksiazki.Include(w => w.Czytelnik).Include(w => w.Ksiazka);
            return View(wypozyczenia_Ksiazki.ToList());
        }

        // GET: Wypozyczenia_Ksiazki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia_Ksiazki wypozyczenia_Ksiazki = db.Wypozyczenia_Ksiazki.Find(id);
            if (wypozyczenia_Ksiazki == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia_Ksiazki);
        }

        // GET: Wypozyczenia_Ksiazki/Create
        public ActionResult Create()
        {
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie");
            ViewBag.ID_Ksiazki = new SelectList(db.Ksiazka, "ID", "Tytul");
            return View();
        }

        // POST: Wypozyczenia_Ksiazki/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Czytelnika,ID_Ksiazki,Data_Wypozyczenia,Data_Zwrotu")] Wypozyczenia_Ksiazki wypozyczenia_Ksiazki)
        {
            if (ModelState.IsValid)
            {
                db.Wypozyczenia_Ksiazki.Add(wypozyczenia_Ksiazki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie", wypozyczenia_Ksiazki.ID_Czytelnika);
            ViewBag.ID_Ksiazki = new SelectList(db.Ksiazka, "ID", "Tytul", wypozyczenia_Ksiazki.ID_Ksiazki);
            return View(wypozyczenia_Ksiazki);
        }

        // GET: Wypozyczenia_Ksiazki/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia_Ksiazki wypozyczenia_Ksiazki = db.Wypozyczenia_Ksiazki.Find(id);
            if (wypozyczenia_Ksiazki == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie", wypozyczenia_Ksiazki.ID_Czytelnika);
            ViewBag.ID_Ksiazki = new SelectList(db.Ksiazka, "ID", "Tytul", wypozyczenia_Ksiazki.ID_Ksiazki);
            return View(wypozyczenia_Ksiazki);
        }

        // POST: Wypozyczenia_Ksiazki/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Czytelnika,ID_Ksiazki,Data_Wypozyczenia,Data_Zwrotu")] Wypozyczenia_Ksiazki wypozyczenia_Ksiazki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wypozyczenia_Ksiazki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie", wypozyczenia_Ksiazki.ID_Czytelnika);
            ViewBag.ID_Ksiazki = new SelectList(db.Ksiazka, "ID", "Tytul", wypozyczenia_Ksiazki.ID_Ksiazki);
            return View(wypozyczenia_Ksiazki);
        }

        // GET: Wypozyczenia_Ksiazki/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia_Ksiazki wypozyczenia_Ksiazki = db.Wypozyczenia_Ksiazki.Find(id);
            if (wypozyczenia_Ksiazki == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia_Ksiazki);
        }

        // POST: Wypozyczenia_Ksiazki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wypozyczenia_Ksiazki wypozyczenia_Ksiazki = db.Wypozyczenia_Ksiazki.Find(id);
            db.Wypozyczenia_Ksiazki.Remove(wypozyczenia_Ksiazki);
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
