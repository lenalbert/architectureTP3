using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class PatientsController : Controller
    {
        private ClinicContext db = new ClinicContext();

        // GET: Patients
        public ActionResult Index(string LastName, string FirstName, string Email, string Address, string Telephone)
        {
            var patient = from p in db.Patients
                          select p;

            if (!String.IsNullOrEmpty(LastName))
            {
                patient = patient.Where(s => s.LastNamePatient.Contains(LastName));
            }
            if (!string.IsNullOrEmpty(FirstName))
            {
                patient = patient.Where(t => t.FirstNamePatient.Contains(FirstName));
            }
            if (!string.IsNullOrEmpty(Email))
            {
                patient = patient.Where(u => u.EmailPatient.Contains(Email));
            }
            if (!string.IsNullOrEmpty(Address))
            {
                patient = patient.Where(v => v.AddressPatient.Contains(Address));
            }
            if (!string.IsNullOrEmpty(Telephone))
            {
                patient = patient.Where(w => w.TelephonePatient == Telephone);
            }
            return View(patient.ToList());
        }


        // GET: Patients/Details/5
        [Authorize(Roles = "Secretary, Doctor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        [Authorize(Roles = "Secretary")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,LastNamePatient,FirstNamePatient,EmailPatient,AddressPatient,TelephonePatient,BirthDatePatient")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        [Authorize(Roles = "Secretary, Doctor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Secretary, Doctor")]
        public ActionResult Edit([Bind(Include = "PatientID,LastNamePatient,FirstNamePatient,EmailPatient,AddressPatient,TelephonePatient,BirthDatePatient")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        [Authorize(Roles = "Secretary")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Secretary")]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
