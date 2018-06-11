﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;

namespace LibraryManagement.Controllers
{
    public class KoszykController : Controller
    {
        private List<Rzecz> list;
        private LibraryManagementDataEntities db = new LibraryManagementDataEntities();
        // GET: Koszyk
        public ActionResult Index()
        {
            if (Session["Koszyk"] == null)
            {
                list = new List<Rzecz>();
            }
            else
            {
                list = (List<Rzecz>)Session["Koszyk"];
            }
            return View(list.ToList());
        }

        public ActionResult Add(int id, int type)
        {
            if (Session["Koszyk"] == null)
            {
                list = new List<Rzecz>();
            }
            else
            {
                list = (List<Rzecz>)Session["Koszyk"];
            }

            if (type == 0)
            {
                Ksiazka k = db.Ksiazka.Where(x => x.ID == id).FirstOrDefault();
                if (!contains(k.Tytul))
                {
                    list.Add(new Rzecz() { tytul = k.Tytul, ilosc = 1, ID = k.ID, type = type });
                }
            }
            else if (type == 1)
            {
                Film f = db.Film.Where(x => x.ID == id).FirstOrDefault();
                if (!contains(f.Tytul))
                {
                    list.Add(new Rzecz() { tytul = f.Tytul, ilosc = 1, ID = f.ID, type = type });
                }
            }
            else if (type == 2)
            {
                Czasopismo c = db.Czasopismo.Where(x => x.ID == id).FirstOrDefault();
                if (!contains(c.Tytul))
                {
                    list.Add(new Rzecz() { tytul = c.Tytul, ilosc = 1, ID = c.ID, type = type });
                }
            }
            else if (type == 3)
            {
                Praca_Naukowa pr = db.Praca_Naukowa.Where(x => x.ID == id).FirstOrDefault();
                if (!contains(pr.Tytul))
                {
                    list.Add(new Rzecz() { tytul = pr.Tytul, ilosc = 1, ID = pr.ID, type = type });
                }
            }
            Session["Koszyk"] = list;

            return RedirectToAction("Index");
        }

        private bool contains(string tytul)
        {
            foreach (Rzecz r in list)
            {
                if (r.tytul.Equals(tytul))
                {
                    return true;
                }
            }
            return false;
        }


        public ActionResult Delete(int id)
        {
            if (Session["Koszyk"] != null)
            {
                list = (List<Rzecz>)Session["Koszyk"];
                list.RemoveAt(id);
                //list.Remove(rzecz);
                Session["Koszyk"] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(List<Rzecz> list, string submit, string save)
        {
            if (!string.IsNullOrEmpty(save))
            {
                Session["Koszyk"] = list;
                return View(list.ToList());
            }

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index"); // Tutaj dać jakiś błąd
            }

            System.Web.HttpContext.Current.Application.Lock();
            int limit = (int)System.Web.HttpContext.Current.Application["Limit"];
            System.Web.HttpContext.Current.Application.UnLock();
            int sum = 0;
            foreach (Rzecz r in list)
            {
                sum += r.ilosc;
            }

            if (sum > limit)
            {
                ViewBag.Error = "Przekroczono limit wypożyczeń";
                return View(list.ToList()); // Tutaj dać jakiś błąd
            }

            foreach (Rzecz r in list)
            {
                RzeczValidator validator = new RzeczValidator();
                FluentValidation.Results.ValidationResult result = validator.Validate(r);
                if (!result.IsValid)
                {
                    List<string> errorStr = new List<string>();
                    foreach (ValidationFailure vf in result.Errors)
                    {
                        errorStr.Add(vf.ErrorMessage);
                    }
                    ViewBag.Error = errorStr;
                    return View(list.ToList());
                }

                r.ID_Czytelnika = Int32.Parse(Session["UserID"].ToString());
                if (r.type == 0)
                {
                    Ksiazka k = db.Ksiazka.Find(r.ID);
                    if (r.ilosc > k.Stan_Magazynowy)
                    {
                        ViewBag.Error = "Nie można przetworzyć zamówienia";
                        return View(list.ToList());
                    }
                    for (int i = 0; i < r.ilosc; i++)
                    {
                        db.Wypozyczenia_Ksiazki.Add(new Wypozyczenia_Ksiazki { ID_Czytelnika = r.ID_Czytelnika, ID_Ksiazki = r.ID, Data_Wypozyczenia = r.data_wypozyczenia, Data_Zwrotu = r.data_zwrotu });
                        k.Stan_Magazynowy -= 1;
                    }
                }
                else if (r.type == 1)
                {
                    Film f = db.Film.Find(r.ID);
                    if (r.ilosc > f.Stan_Magazynowy)
                    {
                        ViewBag.Error = "Nie można przetworzyć zamówienia";
                        return View(list.ToList());
                    }

                    for (int i = 0; i < r.ilosc; i++)
                    {
                        db.Wypozyczenia_Filmu.Add(new Wypozyczenia_Filmu { ID_Czytelnika = r.ID_Czytelnika, ID_Filmu = r.ID, Data_Wypozyczenia = r.data_wypozyczenia, Data_Zwrotu = r.data_zwrotu });
                        f.Stan_Magazynowy -= 1;
                    }
                }
                else if (r.type == 2)
                {
                    Czasopismo c = db.Czasopismo.Find(r.ID);
                    if (r.ilosc > c.Stan_Magazynowy)
                    {
                        ViewBag.Error = "Nie można przetworzyć zamówienia";
                        return View(list.ToList());
                    }

                    for (int i = 0; i < r.ilosc; i++)
                    {
                        db.Wypozyczenia_Czasopisma.Add(new Wypozyczenia_Czasopisma { ID_Czytelnika = r.ID_Czytelnika, ID_Czasopisma = r.ID, Data_Wypozyczenia = r.data_wypozyczenia, Data_Zwrotu = r.data_zwrotu });
                        c.Stan_Magazynowy -= 1;
                    }
                }
                else if (r.type == 3)
                {
                    Praca_Naukowa pr = db.Praca_Naukowa.Find(r.ID);
                    if (r.ilosc > pr.Stan_Magazynowy)
                    {
                        ViewBag.Error = "Nie można przetworzyć zamówienia";
                        return View(list.ToList());
                    }

                    for (int i = 0; i < r.ilosc; i++)
                    {
                        db.Wypozyczenia_Praca_Naukowa.Add(new Wypozyczenia_Praca_Naukowa { ID_Czytelnika = r.ID_Czytelnika, ID_Pracy = r.ID, Data_Wypozyczenia = r.data_wypozyczenia, Data_Zwrotu = r.data_zwrotu });
                        pr.Stan_Magazynowy -= 1;
                    }
                }
            }


            db.SaveChanges();
            list.Clear();
            Session["Koszyk"] = null;
            return RedirectToAction("Index", "Ksiazka", null);
        }
    }
}
