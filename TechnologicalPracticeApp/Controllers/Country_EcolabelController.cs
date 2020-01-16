using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechnologicalPracticeApp.Models;

namespace TechnologicalPracticeApp.Controllers
{
    public class Country_EcolabelController : Controller
    {
        private TechnologicalPracticeAppContext db = new TechnologicalPracticeAppContext();

        // GET: Country_Ecolabel
        public ActionResult Index()
        {
            var country_Ecolabel = db.Country_Ecolabel.Include(c => c.Country).Include(c => c.Ecolabel);
            return View(country_Ecolabel.ToList());
        }

        // GET: Country_Ecolabel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country_Ecolabel country_Ecolabel = db.Country_Ecolabel.Find(id);
            if (country_Ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(country_Ecolabel);
        }
        
        // GET: Country_Ecolabel/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "Id", "Name");
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name");
            return View();
        }

        // POST: Country_Ecolabel/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CountryID,EcolabelID")] Country_Ecolabel country_Ecolabel)
        {
            if (ModelState.IsValid)
            {
                db.Country_Ecolabel.Add(country_Ecolabel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Countries, "Id", "Name", country_Ecolabel.CountryID);
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", country_Ecolabel.EcolabelID);
            return View(country_Ecolabel);
        }

        // GET: Country_Ecolabel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country_Ecolabel country_Ecolabel = db.Country_Ecolabel.Find(id);
            if (country_Ecolabel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "Id", "Name", country_Ecolabel.CountryID);
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", country_Ecolabel.EcolabelID);
            return View(country_Ecolabel);
        }

        // POST: Country_Ecolabel/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CountryID,EcolabelID")] Country_Ecolabel country_Ecolabel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country_Ecolabel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "Id", "Name", country_Ecolabel.CountryID);
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", country_Ecolabel.EcolabelID);
            return View(country_Ecolabel);
        }

        // GET: Country_Ecolabel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country_Ecolabel country_Ecolabel = db.Country_Ecolabel.Find(id);
            if (country_Ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(country_Ecolabel);
        }

        // POST: Country_Ecolabel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country_Ecolabel country_Ecolabel = db.Country_Ecolabel.Find(id);
            db.Country_Ecolabel.Remove(country_Ecolabel);
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
