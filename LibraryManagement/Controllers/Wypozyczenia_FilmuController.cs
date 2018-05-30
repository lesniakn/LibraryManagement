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
    public class Wypozyczenia_FilmuController : Controller
    {
        private LibraryManagementDataEntities db = new LibraryManagementDataEntities();

        // GET: Wypozyczenia_Filmu
        public ActionResult Index()
        {
            var wypozyczenia_Filmu = db.Wypozyczenia_Filmu.Include(w => w.Czytelnik).Include(w => w.Film);
            return View(wypozyczenia_Filmu.ToList());
        }

        // GET: Wypozyczenia_Filmu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia_Filmu wypozyczenia_Filmu = db.Wypozyczenia_Filmu.Find(id);
            if (wypozyczenia_Filmu == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia_Filmu);
        }

        // GET: Wypozyczenia_Filmu/Create
        public ActionResult Create()
        {
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie");
            ViewBag.ID_Filmu = new SelectList(db.Film, "ID", "Tytul");
            return View();
        }

        // POST: Wypozyczenia_Filmu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Czytelnika,ID_Filmu,Data_Wypozyczenia,Data_Zwrotu")] Wypozyczenia_Filmu wypozyczenia_Filmu)
        {
            if (ModelState.IsValid)
            {
                db.Wypozyczenia_Filmu.Add(wypozyczenia_Filmu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie", wypozyczenia_Filmu.ID_Czytelnika);
            ViewBag.ID_Filmu = new SelectList(db.Film, "ID", "Tytul", wypozyczenia_Filmu.ID_Filmu);
            return View(wypozyczenia_Filmu);
        }

        // GET: Wypozyczenia_Filmu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia_Filmu wypozyczenia_Filmu = db.Wypozyczenia_Filmu.Find(id);
            if (wypozyczenia_Filmu == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie", wypozyczenia_Filmu.ID_Czytelnika);
            ViewBag.ID_Filmu = new SelectList(db.Film, "ID", "Tytul", wypozyczenia_Filmu.ID_Filmu);
            return View(wypozyczenia_Filmu);
        }

        // POST: Wypozyczenia_Filmu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Czytelnika,ID_Filmu,Data_Wypozyczenia,Data_Zwrotu")] Wypozyczenia_Filmu wypozyczenia_Filmu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wypozyczenia_Filmu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Czytelnika = new SelectList(db.Czytelnik, "ID", "Imie", wypozyczenia_Filmu.ID_Czytelnika);
            ViewBag.ID_Filmu = new SelectList(db.Film, "ID", "Tytul", wypozyczenia_Filmu.ID_Filmu);
            return View(wypozyczenia_Filmu);
        }

        // GET: Wypozyczenia_Filmu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypozyczenia_Filmu wypozyczenia_Filmu = db.Wypozyczenia_Filmu.Find(id);
            if (wypozyczenia_Filmu == null)
            {
                return HttpNotFound();
            }
            return View(wypozyczenia_Filmu);
        }

        // POST: Wypozyczenia_Filmu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wypozyczenia_Filmu wypozyczenia_Filmu = db.Wypozyczenia_Filmu.Find(id);
            db.Wypozyczenia_Filmu.Remove(wypozyczenia_Filmu);
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
