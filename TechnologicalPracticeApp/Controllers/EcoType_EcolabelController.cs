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
    public class EcoType_EcolabelController : Controller
    {
        private TechnologicalPracticeAppContext db = new TechnologicalPracticeAppContext();

        // GET: EcoType_Ecolabel
        public ActionResult Index()
        {
            var ecoType_Ecolabel = db.EcoType_Ecolabel.Include(e => e.Ecolabel).Include(e => e.EcoType);
            return View(ecoType_Ecolabel.ToList());
        }

        // GET: EcoType_Ecolabel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoType_Ecolabel ecoType_Ecolabel = db.EcoType_Ecolabel.Find(id);
            if (ecoType_Ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(ecoType_Ecolabel);
        }

        // GET: EcoType_Ecolabel/Create
        public ActionResult Create()
        {
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name");
            ViewBag.EcoTypeID = new SelectList(db.EcoTypes, "Id", "Name");
            return View();
        }

        // POST: EcoType_Ecolabel/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EcoTypeID,EcolabelID")] EcoType_Ecolabel ecoType_Ecolabel)
        {
            if (ModelState.IsValid)
            {
                db.EcoType_Ecolabel.Add(ecoType_Ecolabel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", ecoType_Ecolabel.EcolabelID);
            ViewBag.EcoTypeID = new SelectList(db.EcoTypes, "Id", "Name", ecoType_Ecolabel.EcoTypeID);
            return View(ecoType_Ecolabel);
        }

        // GET: EcoType_Ecolabel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoType_Ecolabel ecoType_Ecolabel = db.EcoType_Ecolabel.Find(id);
            if (ecoType_Ecolabel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", ecoType_Ecolabel.EcolabelID);
            ViewBag.EcoTypeID = new SelectList(db.EcoTypes, "Id", "Name", ecoType_Ecolabel.EcoTypeID);
            return View(ecoType_Ecolabel);
        }

        // POST: EcoType_Ecolabel/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EcoTypeID,EcolabelID")] EcoType_Ecolabel ecoType_Ecolabel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecoType_Ecolabel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", ecoType_Ecolabel.EcolabelID);
            ViewBag.EcoTypeID = new SelectList(db.EcoTypes, "Id", "Name", ecoType_Ecolabel.EcoTypeID);
            return View(ecoType_Ecolabel);
        }

        // GET: EcoType_Ecolabel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoType_Ecolabel ecoType_Ecolabel = db.EcoType_Ecolabel.Find(id);
            if (ecoType_Ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(ecoType_Ecolabel);
        }

        // POST: EcoType_Ecolabel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EcoType_Ecolabel ecoType_Ecolabel = db.EcoType_Ecolabel.Find(id);
            db.EcoType_Ecolabel.Remove(ecoType_Ecolabel);
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
