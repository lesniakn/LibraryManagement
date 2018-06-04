﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

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
                list = (List<Rzecz>) Session["Koszyk"];
            }

            if (type == 0)
            {
                list.Add(new Rzecz(db.Ksiazka.Where(x => x.ID == id).FirstOrDefault(), 1));
            }
            else if (type == 1)
            {
                list.Add(new Rzecz(db.Film.Where(x => x.ID == id).FirstOrDefault(), 1));
            }
            else if (type == 2)
            {
                list.Add(new Rzecz(db.Czasopismo.Where(x => x.ID == id).FirstOrDefault(), 1));
            }
            else if (type == 3)
            {
                list.Add(new Rzecz(db.Praca_Naukowa.Where(x => x.ID == id).FirstOrDefault(), 1));
            }
            Session["Koszyk"] = list;

            return RedirectToAction("Index");
        }
    }
}