﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BYOSalad.Models;

namespace BYOSalad.Controllers
{
    public class SaladsController : Controller
    {
        private DatabaseBYOSaladEntities db = new DatabaseBYOSaladEntities();

        // GET: Salads
        public ActionResult Index()
        {
            return View(db.Salad.ToList());
        }

        // GET: Salads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salad salad = db.Salad.Find(id);
            if (salad == null)
            {
                return HttpNotFound();
            }
            return View(salad);
        }

        // GET: Salads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Allergy,Ingredients,Preparation,Time,Cost,Location,Ranking,InsertDB,Visible,DeleteDB")] Salad salad)
        {
            if (ModelState.IsValid)
            {
                db.Salad.Add(salad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salad);
        }

        // GET: Salads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salad salad = db.Salad.Find(id);
            if (salad == null)
            {
                return HttpNotFound();
            }
            return View(salad);
        }

        // POST: Salads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Allergy,Ingredients,Preparation,Time,Cost,Location,Ranking,InsertDB,Visible,DeleteDB")] Salad salad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salad);
        }

        // GET: Salads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salad salad = db.Salad.Find(id);
            if (salad == null)
            {
                return HttpNotFound();
            }
            return View(salad);
        }

        // POST: Salads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salad salad = db.Salad.Find(id);
            db.Salad.Remove(salad);
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
