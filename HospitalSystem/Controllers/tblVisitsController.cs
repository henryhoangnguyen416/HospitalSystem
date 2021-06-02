using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalSystem.Models;

namespace HospitalSystem.Controllers
{
    public class tblVisitsController : Controller
    {
        private HospitalContext db = new HospitalContext();//Hospital Database

        // GET: tblVisits
        //Searches table based on the SearchBy term
        public ActionResult Index(string SearchBy, string year, string month, string day)
        {
            var tblVisits = db.tblVisits.Include(t => t.tblDoctor).Include(t => t.tblPatient);//Joins Visits with Doctors and Patients tables
            if (Int32.TryParse(year, out int yearx) && Int32.TryParse(month, out int monthx) && Int32.TryParse(day, out int dayx))//Converts input values into Intergers
            {         
                if (SearchBy == "TimeAdmitted")
                {
                    return View(tblVisits.Where(d => d.Time_Admitted < new DateTime(yearx, monthx, dayx)).ToList());//Returns tblVisits object that has Time_Admitted below given input
                }
                else
                {
                    return View(tblVisits.Where(d => d.Time_Discharged < new DateTime(yearx, monthx, dayx)).ToList());//Returns tblVisits obect that has Time_Discharged below given input
                }
            }
            else
            {
                return View(tblVisits);
            }
            
        }

        // GET: tblVisits/Details/5
        //Retrieved Details of specific Visit
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVisit tblVisit = db.tblVisits.Find(id);
            if (tblVisit == null)
            {
                return HttpNotFound();
            }
            return View(tblVisit);
        }

        // GET: tblVisits/Create
        public ActionResult Create()
        {
            ViewBag.Doctor_Id = new SelectList(db.tblDoctors, "Id", "Name");
            ViewBag.Patient_Id = new SelectList(db.tblPatients, "ID", "Name");
            return View();
        }

        // POST: tblVisits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Patient_Id,Doctor_Id,Time_Admitted,Time_Discharged,RoomNumber,Complaint")] tblVisit tblVisit)
        {
            if (ModelState.IsValid)
            {
                db.tblVisits.Add(tblVisit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Doctor_Id = new SelectList(db.tblDoctors, "Id", "Name", tblVisit.Doctor_Id);
            ViewBag.Patient_Id = new SelectList(db.tblPatients, "ID", "Name", tblVisit.Patient_Id);
            return View(tblVisit);
        }

        // GET: tblVisits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVisit tblVisit = db.tblVisits.Find(id);
            if (tblVisit == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doctor_Id = new SelectList(db.tblDoctors, "Id", "Name", tblVisit.Doctor_Id);
            ViewBag.Patient_Id = new SelectList(db.tblPatients, "ID", "Name", tblVisit.Patient_Id);
            return View(tblVisit);
        }

        // POST: tblVisits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Patient_Id,Doctor_Id,Time_Admitted,Time_Discharged,RoomNumber,Complaint")] tblVisit tblVisit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVisit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doctor_Id = new SelectList(db.tblDoctors, "Id", "Name", tblVisit.Doctor_Id);
            ViewBag.Patient_Id = new SelectList(db.tblPatients, "ID", "Name", tblVisit.Patient_Id);
            return View(tblVisit);
        }

        // GET: tblVisits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVisit tblVisit = db.tblVisits.Find(id);
            if (tblVisit == null)
            {
                return HttpNotFound();
            }
            return View(tblVisit);
        }

        // POST: tblVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVisit tblVisit = db.tblVisits.Find(id);
            db.tblVisits.Remove(tblVisit);
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
