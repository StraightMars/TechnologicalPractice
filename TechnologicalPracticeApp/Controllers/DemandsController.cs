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
    public class DemandsController : Controller
    {
        private TechnologicalPracticeAppContext db = new TechnologicalPracticeAppContext();

        // GET: Demands
        public ActionResult Index()
        {
            return View(db.Demands.ToList());
        }

        // GET: Demands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demand demand = db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }
            return View(demand);
        }

        // GET: Demands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demands/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rule")] Demand demand)
        {
            if (ModelState.IsValid)
            {
                db.Demands.Add(demand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demand);
        }

        // GET: Demands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demand demand = db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }
            return View(demand);
        }

        // POST: Demands/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rule")] Demand demand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demand);
        }

        // GET: Demands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demand demand = db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }
            return View(demand);
        }

        // POST: Demands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Demand demand = db.Demands.Find(id);
            db.Demands.Remove(demand);
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
