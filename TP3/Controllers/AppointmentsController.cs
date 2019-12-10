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
    public class AppointmentsController : Controller
    {
        private ClinicContext db = new ClinicContext();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointment = db.Appointment.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Reason).Include(a => a.Room);
            return View(appointment.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.DoctorID = new SelectList(db.Doctor, "DoctorID", "DoctorID");
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "LastNamePatient");
            ViewBag.ReasonID = new SelectList(db.Reasons, "ReasonID", "Label");
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomLabel");
            return View();
        }

        // POST: Appointments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentID,PatientID,DoctorID,ReasonID,RoomID,AppointmentDate,StartTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointment.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorID = new SelectList(db.Doctor, "DoctorID", "DoctorID", appointment.DoctorID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "LastNamePatient", appointment.PatientID);
            ViewBag.ReasonID = new SelectList(db.Reasons, "ReasonID", "Label", appointment.ReasonID);
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomID", appointment.RoomID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorID = new SelectList(db.Doctor, "DoctorID", "DoctorID", appointment.DoctorID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "LastNamePatient", appointment.PatientID);
            ViewBag.ReasonID = new SelectList(db.Reasons, "ReasonID", "Label", appointment.ReasonID);
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomID", appointment.RoomID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentID,PatientID,DoctorID,ReasonID,RoomID,AppointmentDate,StartTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorID = new SelectList(db.Doctor, "DoctorID", "DoctorID", appointment.DoctorID);
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "LastNamePatient", appointment.PatientID);
            ViewBag.ReasonID = new SelectList(db.Reasons, "ReasonID", "Label", appointment.ReasonID);
            ViewBag.RoomID = new SelectList(db.Room, "RoomID", "RoomID", appointment.RoomID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointment.Find(id);
            db.Appointment.Remove(appointment);
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
