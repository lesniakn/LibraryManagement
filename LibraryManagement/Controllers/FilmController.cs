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
    public class FilmController : Controller
    {
        private LibraryManagementDataEntities db = new LibraryManagementDataEntities();

        // GET: Film
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var film = db.Film.Include(f => f.Aktor);
            return View(film.ToList());
        }

        // GET: Film/Details/5
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            ViewBag.ID_Aktora = new SelectList(db.Aktor, "ID", "Imie");
            return View();
        }

        // POST: Film/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tytul,ID_Aktora,Stan_Magazynowy")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Film.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Aktora = new SelectList(db.Aktor, "ID", "Imie", film.ID_Aktora);
            return View(film);
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Aktora = new SelectList(db.Aktor, "ID", "Imie", film.ID_Aktora);
            return View(film);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tytul,ID_Aktora,Stan_Magazynowy")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Aktora = new SelectList(db.Aktor, "ID", "Imie", film.ID_Aktora);
            return View(film);
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Film.Find(id);
            db.Film.Remove(film);
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
