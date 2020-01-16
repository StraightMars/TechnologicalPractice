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
    public class EcoTypesController : Controller
    {
        private TechnologicalPracticeAppContext db = new TechnologicalPracticeAppContext();

        // GET: EcoTypes
        public ActionResult Index()
        {
            return View(db.EcoTypes.ToList());
        }

        // GET: EcoTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoType ecoType = db.EcoTypes.Find(id);
            if (ecoType == null)
            {
                return HttpNotFound();
            }
            return View(ecoType);
        }

        // GET: EcoTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EcoTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] EcoType ecoType)
        {
            if (ModelState.IsValid)
            {
                db.EcoTypes.Add(ecoType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ecoType);
        }

        // GET: EcoTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoType ecoType = db.EcoTypes.Find(id);
            if (ecoType == null)
            {
                return HttpNotFound();
            }
            return View(ecoType);
        }

        // POST: EcoTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] EcoType ecoType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecoType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ecoType);
        }

        // GET: EcoTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EcoType ecoType = db.EcoTypes.Find(id);
            if (ecoType == null)
            {
                return HttpNotFound();
            }
            return View(ecoType);
        }

        // POST: EcoTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EcoType ecoType = db.EcoTypes.Find(id);
            db.EcoTypes.Remove(ecoType);
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
