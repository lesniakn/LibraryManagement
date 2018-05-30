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
    public class Wypozyczenia_CzasopismaController : Controller
    {
        private LibraryManagementDataEntities db = new LibraryManagementDataEntities();

        // GET: Wypozyczenia_Czasopisma
        public ActionResult Index()
        {
            var wypozyczenia_Czasopisma = db.Wypozyczenia_Czasopisma.Include(w => w.Czasopismo).Include(w => w.Czytelnik);
            return View(wypozyczenia_Czasopisma.ToList());
        }

        // GET: Wypozyczenia_Czasopisma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia_Czasopisma wypozyczenia_Czasopisma = db.Wypozyczenia_Czasopisma.Find(id);
            if (wypozyczenia_Czasopisma == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia_Czasopisma);
        }

        // GET: Wypozyczenia_Czasopisma/Create
        public ActionResult Create()
        {
            ViewBag.ID_Czasopisma = new SelectList(db.Czasopismo, "ID", "Tytul");
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie");
            return View();
        }

        // POST: Wypozyczenia_Czasopisma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Czytelnika,ID_Czasopisma,Data_Wypozyczenia,Data_Zwrotu")] Wypozyczenia_Czasopisma wypozyczenia_Czasopisma)
        {
            if (ModelState.IsValid)
            {
                db.Wypozyczenia_Czasopisma.Add(wypozyczenia_Czasopisma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Czasopisma = new SelectList(db.Czasopismo, "ID", "Tytul", wypozyczenia_Czasopisma.ID_Czasopisma);
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie", wypozyczenia_Czasopisma.ID_Czytelnika);
            return View(wypozyczenia_Czasopisma);
        }

        // GET: Wypozyczenia_Czasopisma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia_Czasopisma wypozyczenia_Czasopisma = db.Wypozyczenia_Czasopisma.Find(id);
            if (wypozyczenia_Czasopisma == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Czasopisma = new SelectList(db.Czasopismo, "ID", "Tytul", wypozyczenia_Czasopisma.ID_Czasopisma);
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie", wypozyczenia_Czasopisma.ID_Czytelnika);
            return View(wypozyczenia_Czasopisma);
        }

        // POST: Wypozyczenia_Czasopisma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Czytelnika,ID_Czasopisma,Data_Wypozyczenia,Data_Zwrotu")] Wypozyczenia_Czasopisma wypozyczenia_Czasopisma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wypozyczenia_Czasopisma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Czasopisma = new SelectList(db.Czasopismo, "ID", "Tytul", wypozyczenia_Czasopisma.ID_Czasopisma);
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie", wypozyczenia_Czasopisma.ID_Czytelnika);
            return View(wypozyczenia_Czasopisma);
        }

        // GET: Wypozyczenia_Czasopisma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia_Czasopisma wypozyczenia_Czasopisma = db.Wypozyczenia_Czasopisma.Find(id);
            if (wypozyczenia_Czasopisma == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia_Czasopisma);
        }

        // POST: Wypozyczenia_Czasopisma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wypozyczenia_Czasopisma wypozyczenia_Czasopisma = db.Wypozyczenia_Czasopisma.Find(id);
            db.Wypozyczenia_Czasopisma.Remove(wypozyczenia_Czasopisma);
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
