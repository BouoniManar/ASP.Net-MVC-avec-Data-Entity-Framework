using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.Net_MVC_avec_Data_Entity_Framework.Models;

namespace ASP.Net_MVC_avec_Data_Entity_Framework.Controllers
{
    public class PersonsController : Controller
    {
        private personsEntities db = new personsEntities();

        // GET: Persons
        public ActionResult Index()
        {
            return View(db.TBL_PERSONS.ToList());
        }

        // GET: Persons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PERSONS tBL_PERSONS = db.TBL_PERSONS.Find(id);
            if (tBL_PERSONS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PERSONS);
        }

        // GET: Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Job,Age")] TBL_PERSONS tBL_PERSONS)
        {
            if (ModelState.IsValid)
            {
                db.TBL_PERSONS.Add(tBL_PERSONS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_PERSONS);
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PERSONS tBL_PERSONS = db.TBL_PERSONS.Find(id);
            if (tBL_PERSONS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PERSONS);
        }

        // POST: Persons/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Job,Age")] TBL_PERSONS tBL_PERSONS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_PERSONS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_PERSONS);
        }

        // GET: Persons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_PERSONS tBL_PERSONS = db.TBL_PERSONS.Find(id);
            if (tBL_PERSONS == null)
            {
                return HttpNotFound();
            }
            return View(tBL_PERSONS);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_PERSONS tBL_PERSONS = db.TBL_PERSONS.Find(id);
            db.TBL_PERSONS.Remove(tBL_PERSONS);
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
