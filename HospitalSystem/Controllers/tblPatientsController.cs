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
    public class tblPatientsController : Controller
    {
        private HospitalContext db = new HospitalContext();//Hospital Database

        // GET: tblPatients
        //Searches table based on the SearchBy term
        public ActionResult Index(string SearchBy, string search)
        {
            var tblPatients = db.tblPatients.Include(t => t.tblDoctor);//Joins Patients and Doctors tables
            if (SearchBy == "Name")
            {
                return View(tblPatients.Where(d => d.Name.Contains(search) || search == null).ToList());//Returns tblPatients object list that contains the inputted name
            }
            else
            {
                return View(tblPatients.Where(d => d.Address.Contains(search) || search == null).ToList());//Returns tblPatients object list that contains the inputted address
            }
            
        }

        // GET: tblPatients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatient tblPatient = db.tblPatients.Find(id);
            if (tblPatient == null)
            {
                return HttpNotFound();
            }
            return View(tblPatient);
        }

        // GET: tblPatients/Create
        public ActionResult Create()
        {
            ViewBag.Doctor_Id = new SelectList(db.tblDoctors, "Id", "Name");
            return View();
        }

        // POST: tblPatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Doctor_Id,Email,Address")] tblPatient tblPatient)
        {
            if (ModelState.IsValid)
            {
                db.tblPatients.Add(tblPatient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Doctor_Id = new SelectList(db.tblDoctors, "Id", "Name", tblPatient.Doctor_Id);
            return View(tblPatient);
        }

        // GET: tblPatients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatient tblPatient = db.tblPatients.Find(id);
            if (tblPatient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doctor_Id = new SelectList(db.tblDoctors, "Id", "Name", tblPatient.Doctor_Id);
            return View(tblPatient);
        }

        // POST: tblPatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Doctor_Id,Email,Address")] tblPatient tblPatient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doctor_Id = new SelectList(db.tblDoctors, "Id", "Name", tblPatient.Doctor_Id);
            return View(tblPatient);
        }

        // GET: tblPatients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPatient tblPatient = db.tblPatients.Find(id);
            if (tblPatient == null)
            {
                return HttpNotFound();
            }
            return View(tblPatient);
        }

        // POST: tblPatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPatient tblPatient = db.tblPatients.Find(id);
            db.tblPatients.Remove(tblPatient);
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
