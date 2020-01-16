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
    public class PersonalCabinetsController : Controller
    {
        private TechnologicalPracticeAppContext db = new TechnologicalPracticeAppContext();

        // GET: PersonalCabinets
        public ActionResult Index()
        {
            var personalCabinets = db.PersonalCabinets.Include(p => p.Ecolabel).Include(p => p.Person);
            return View(personalCabinets.ToList());
        }

        // GET: PersonalCabinets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalCabinet personalCabinet = db.PersonalCabinets.Find(id);
            if (personalCabinet == null)
            {
                return HttpNotFound();
            }
            return View(personalCabinet);
        }

        // GET: PersonalCabinets/Create
        public ActionResult Create()
        {
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name");
            ViewBag.PersonID = new SelectList(db.People, "Id", "Login");
            return View();
        }

        // POST: PersonalCabinets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mark,EcolabelID,PersonID")] PersonalCabinet personalCabinet)
        {
            if (ModelState.IsValid)
            {
                db.PersonalCabinets.Add(personalCabinet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", personalCabinet.EcolabelID);
            ViewBag.PersonID = new SelectList(db.People, "Id", "Login", personalCabinet.PersonID);
            return View(personalCabinet);
        }

        // GET: PersonalCabinets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalCabinet personalCabinet = db.PersonalCabinets.Find(id);
            if (personalCabinet == null)
            {
                return HttpNotFound();
            }
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", personalCabinet.EcolabelID);
            ViewBag.PersonID = new SelectList(db.People, "Id", "Login", personalCabinet.PersonID);
            return View(personalCabinet);
        }

        // POST: PersonalCabinets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mark,EcolabelID,PersonID")] PersonalCabinet personalCabinet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalCabinet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", personalCabinet.EcolabelID);
            ViewBag.PersonID = new SelectList(db.People, "Id", "Login", personalCabinet.PersonID);
            return View(personalCabinet);
        }

        // GET: PersonalCabinets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalCabinet personalCabinet = db.PersonalCabinets.Find(id);
            if (personalCabinet == null)
            {
                return HttpNotFound();
            }
            return View(personalCabinet);
        }

        // POST: PersonalCabinets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalCabinet personalCabinet = db.PersonalCabinets.Find(id);
            db.PersonalCabinets.Remove(personalCabinet);
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
