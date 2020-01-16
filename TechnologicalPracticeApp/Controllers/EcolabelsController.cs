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
    public class EcolabelsController : Controller
    {
        private TechnologicalPracticeAppContext db = new TechnologicalPracticeAppContext();

        // GET: Ecolabels
        public ActionResult IndexUser(string name)
        {
            var ecolabels = db.Ecolabels.Include(e => e.Company);
            if (!string.IsNullOrEmpty(name))
            {
                ecolabels = ecolabels.Where(e => e.Name.Contains(name));
            }
            List<Company> companies = db.Companies.ToList();
            companies.Insert(0, new Company { Name = "Все", Id = 0 });
            FilterModel fm = new FilterModel
            {
                Ecolabels = ecolabels.ToList(),
                Companies = new SelectList(companies, "Id", "Name"),
                Name = name
            };
            return View(fm);
        }
        public ActionResult IndexAdmin(string name, int? company)
        {
            var ecolabels = db.Ecolabels.Include(e => e.Company);
            if (company != null && company != 0)
            {
                ecolabels = ecolabels.Where(e => e.CompanyID == company);
            }
            if (!string.IsNullOrEmpty(name))
            {
                ecolabels = ecolabels.Where(e => e.Name.Contains(name));
            }
            List<Company> companies = db.Companies.ToList();
            companies.Insert(0, new Company { Name = "Все", Id = 0 });
            FilterModel fm = new FilterModel
            {
                Ecolabels = ecolabels.ToList(),
                Companies = new SelectList(companies, "Id", "Name"),
                Name = name
            };
            return View(fm);
        }

        public ActionResult IndexAuthUser(string name)
        {
            var ecolabels = db.Ecolabels.Include(e => e.Company);
            if (!String.IsNullOrEmpty(name))
            {
                ecolabels = ecolabels.Where(e => e.Name.Contains(name));
            }
            List<Company> companies = db.Companies.ToList();
            companies.Insert(0, new Company { Name = "Все", Id = 0 });
            FilterModel fm = new FilterModel
            {
                Ecolabels = ecolabels.ToList(),
                Companies = new SelectList(companies, "Id", "Name"),
                Name = name
            };
            return View(fm);
        }
        public ActionResult FavouriteAuthUser(string name)
        {
            var ecolabels = db.Ecolabels.Include(e => e.Company);
            if (!String.IsNullOrEmpty(name))
            {
                ecolabels = ecolabels.Where(e => e.Name.Contains(name));
            }
            List<Company> companies = db.Companies.ToList();
            companies.Insert(0, new Company { Name = "Все", Id = 0 });
            FilterModel fm = new FilterModel
            {
                Ecolabels = ecolabels.ToList(),
                Companies = new SelectList(companies, "Id", "Name"),
                Name = name
            };
            return View(fm);
        }
        public ActionResult ViewPhoto(int? id)
        {
            Ecolabel ecolabel = db.Ecolabels.Find(id);
            if (ecolabel == null)
            {
                return HttpNotFound();
            }
            return File(ecolabel.Image, "image/png");
        }
        // GET: Ecolabels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecolabel ecolabel = db.Ecolabels.Find(id);
            if (ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(ecolabel);
        }
        public ActionResult DetailsAuthUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecolabel ecolabel = db.Ecolabels.Find(id);
            if (ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(ecolabel);
        }
        public ActionResult DetailsUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecolabel ecolabel = db.Ecolabels.Find(id);
            if (ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(ecolabel);
        }
        public ActionResult MakeAMarkAuthUser()
        {
            List<int> marks = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ViewBag.Mark = new SelectList(marks);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeAMarkAuthUser(int Mark, int id)
        {
            if (ModelState.IsValid)
            {
                PersonalCabinet pc = new PersonalCabinet();
                pc.EcolabelID = id;
                pc.Mark = Mark;
                var user = User.Identity.Name;
                int[] ID = new int[1];
                ID = (from p in db.People
                      where p.Login == user
                      select p.Id).ToArray();
                Person findUser = db.People.Find(ID[0]);

                List<int> delete = new List<int>();
                delete = (from perCab in db.PersonalCabinets
                          where perCab.EcolabelID == id
                          where perCab.PersonID == findUser.Id
                          select perCab.Id).ToList();
                foreach (int elem in delete)
                {
                    db.PersonalCabinets.Remove(db.PersonalCabinets.Find(elem));
                }

                pc.PersonID = findUser.Id;
                db.PersonalCabinets.Add(pc);
                db.SaveChanges();
                return RedirectToAction("IndexAuthUser");
            }
            List<int> marks = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ViewBag.Mark = new SelectList(marks);
            return View();
        }
        // GET: Ecolabels/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name");
            ViewBag.EcoTypeID = new SelectList(db.EcoTypes, "Id", "Name");
            ViewBag.CountryID = new SelectList(db.Countries, "Id", "Name");
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "Rule");
            return View();
        }

        public void AddType(List<int> TypesList, Ecolabel ecolabel)
        {
            if (TypesList != null)
            {
                int i = 0;
                foreach (int item in TypesList)
                {
                    EcoType_Ecolabel ee = new EcoType_Ecolabel();
                    ee.EcolabelID = ecolabel.Id;
                    ee.EcoTypeID = TypesList[i];
                    db.EcoType_Ecolabel.Add(ee);
                    i++;
                }
            }
        }
        public void AddCountry(List<int> CountriesList, Ecolabel ecolabel)
        {
            if (CountriesList != null)
            {
                int i = 0;
                foreach (int elem in CountriesList)
                {
                    Country_Ecolabel ce = new Country_Ecolabel();
                    ce.EcolabelID = ecolabel.Id;
                    ce.CountryID = CountriesList[i];
                    db.Country_Ecolabel.Add(ce);
                    i++;
                }
            }
        }
        public void AddDemand(List<int> DemandsList, Ecolabel ecolabel)
        {
            if (DemandsList != null)
            {
                int i = 0;
                foreach (int elem in DemandsList)
                {
                    Demand_Ecolabel de = new Demand_Ecolabel();
                    de.EcolabelID = ecolabel.Id;
                    de.DemandID = DemandsList[i];
                    db.Demand_Ecolabel.Add(de);
                    i++;
                }
            }
        }
        // POST: Ecolabels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,Description,CompanyID")] Ecolabel ecolabel,
                                   HttpPostedFileBase file, List<int> EcoTypeID, List<int> CountryID, List<int> DemandID)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    ecolabel.Image = new byte[file.ContentLength];
                    file.InputStream.Read(ecolabel.Image, 0, file.ContentLength);
                }
                AddCountry(CountryID, ecolabel);
                AddDemand(DemandID, ecolabel);
                AddType(EcoTypeID, ecolabel);

                db.Ecolabels.Add(ecolabel);
                db.SaveChanges();
                return RedirectToAction("IndexAdmin");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name");
            ViewBag.EcoTypeID = new SelectList(db.EcoTypes, "Id", "Name");
            ViewBag.CountryID = new SelectList(db.Countries, "Id", "Name");
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "Rule");
            return View(ecolabel);
        }
        //public ActionResult Create([Bind(Include = "Id,Name,Image,Description,CompanyID")] Ecolabel ecolabel)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        db.Ecolabels.Add(ecolabel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name", ecolabel.CompanyID);
        //    return View(ecolabel);
        //}

        // GET: Ecolabels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecolabel ecolabel = db.Ecolabels.Find(id);
            if (ecolabel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name");
            ViewBag.EcoTypeID = new SelectList(db.EcoTypes, "Id", "Name");
            ViewBag.CountryID = new SelectList(db.Countries, "Id", "Name");
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "Rule");

            return View(ecolabel);
        }
        public ActionResult AddConnectionCountryEcolabel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecolabel ecolabel = db.Ecolabels.Find(id);
            if (ecolabel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EcolabelID = ecolabel.Name;
            return RedirectToAction("Create", "Country_Ecolabel", ViewBag.EcolabelName = ecolabel.Name);
            return View(ecolabel);
        }

        // POST: Ecolabels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Description,CompanyID")] Ecolabel ecolabel, HttpPostedFileBase file,
                                 List<int> EcoTypeID, List<int> CountryID, List<int> DemandID)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    db.Entry(ecolabel).State = EntityState.Modified;
                    ecolabel.Image = new byte[file.ContentLength];
                    file.InputStream.Read(ecolabel.Image, 0, file.ContentLength);
                }

                List<int> delete = new List<int>();
                delete = (from ce in db.Country_Ecolabel
                          where ce.EcolabelID == ecolabel.Id
                          select ce.Id).ToList();
                foreach (int elem in delete)
                {
                    db.Country_Ecolabel.Remove(db.Country_Ecolabel.Find(elem));
                }

                delete = (from de in db.Demand_Ecolabel
                          where de.EcolabelID == ecolabel.Id
                          select de.Id).ToList();
                foreach (int elem in delete)
                {
                    db.Demand_Ecolabel.Remove(db.Demand_Ecolabel.Find(elem));
                }

                delete = (from ee in db.EcoType_Ecolabel
                          where ee.EcolabelID == ecolabel.Id
                          select ee.Id).ToList();
                foreach (int elem in delete)
                {
                    db.EcoType_Ecolabel.Remove(db.EcoType_Ecolabel.Find(elem));
                }

                AddCountry(CountryID, ecolabel);
                AddDemand(DemandID, ecolabel);
                AddType(EcoTypeID, ecolabel);

                db.SaveChanges();
                return RedirectToAction("IndexAdmin");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name");
            ViewBag.EcoTypeID = new SelectList(db.EcoTypes, "Id", "Name");
            ViewBag.CountryID = new SelectList(db.Countries, "Id", "Name");
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "Rule");
            return View(ecolabel);
        }

        // GET: Ecolabels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecolabel ecolabel = db.Ecolabels.Find(id);
            if (ecolabel == null)
            {
                return HttpNotFound();
            }
            return View(ecolabel);
        }

        // POST: Ecolabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ecolabel ecolabel = db.Ecolabels.Find(id);
            db.Ecolabels.Remove(ecolabel);
            db.SaveChanges();
            return RedirectToAction("IndexAdmin");
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
