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
    public class Demand_EcolabelController : Controller
    {
        private TechnologicalPracticeAppContext db = new TechnologicalPracticeAppContext();

        // GET: Demand_Ecolabel
        public ActionResult Index()
        {
            var demand_Ecolabel = db.Demand_Ecolabel.Include(d => d.Demand).Include(d => d.Ecolabel);
            return View(demand_Ecolabel.ToList());
        }

        // GET: Demand_Ecolabel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demand_Ecolabel demand_Ecolabel = db.Demand_Ecolabel.Find(id);
            if (demand_Ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(demand_Ecolabel);
        }

        // GET: Demand_Ecolabel/Create
        public ActionResult Create()
        {
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "Rule");
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name");
            return View();
        }

        // POST: Demand_Ecolabel/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EcolabelID,DemandID")] Demand_Ecolabel demand_Ecolabel)
        {
            if (ModelState.IsValid)
            {
                db.Demand_Ecolabel.Add(demand_Ecolabel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DemandID = new SelectList(db.Demands, "Id", "Rule", demand_Ecolabel.DemandID);
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", demand_Ecolabel.EcolabelID);
            return View(demand_Ecolabel);
        }

        // GET: Demand_Ecolabel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demand_Ecolabel demand_Ecolabel = db.Demand_Ecolabel.Find(id);
            if (demand_Ecolabel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "Rule", demand_Ecolabel.DemandID);
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", demand_Ecolabel.EcolabelID);
            return View(demand_Ecolabel);
        }

        // POST: Demand_Ecolabel/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EcolabelID,DemandID")] Demand_Ecolabel demand_Ecolabel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demand_Ecolabel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "Rule", demand_Ecolabel.DemandID);
            ViewBag.EcolabelID = new SelectList(db.Ecolabels, "Id", "Name", demand_Ecolabel.EcolabelID);
            return View(demand_Ecolabel);
        }

        // GET: Demand_Ecolabel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demand_Ecolabel demand_Ecolabel = db.Demand_Ecolabel.Find(id);
            if (demand_Ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(demand_Ecolabel);
        }

        // POST: Demand_Ecolabel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Demand_Ecolabel demand_Ecolabel = db.Demand_Ecolabel.Find(id);
            db.Demand_Ecolabel.Remove(demand_Ecolabel);
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
