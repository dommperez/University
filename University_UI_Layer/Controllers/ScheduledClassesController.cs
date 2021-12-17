﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using University_DATA_EF;

namespace University_UI_Layer.Controllers
{
    public class ScheduledClassesController : Controller
    {
        private UniversityDatabaseEntities db = new UniversityDatabaseEntities();

        // GET: ScheduledClasses
        public ActionResult Index()
        {
            return View(db.ScheduledClasses.ToList());
        }

        // GET: ScheduledClasses/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
            if (scheduledClass == null)
            {
                return HttpNotFound();
            }
            return View(scheduledClass);
        }

        //GET: ScheduledClasses/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.SCSID = new SelectList(db.SchduledClassStatuses, "SCSID", "SCSName");
            return View();
        }

        //POST: ScheduledClasses/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduledClassId,CourseId,StartDate,EndDate,InstructorName,Location,SCSID")] ScheduledClass scheduledClass)
        {
            if (ModelState.IsValid)
            {
                db.ScheduledClasses.Add(scheduledClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", scheduledClass.CourseId);
            ViewBag.SCSID = new SelectList(db.SchduledClassStatuses, "SCSID", "SCSName", scheduledClass.SCSID);
            return View(scheduledClass);
        }

        //GET: ScheduledClasses/Edit
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
            if (scheduledClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", scheduledClass.CourseId);
            ViewBag.SCSID = new SelectList(db.SchduledClassStatuses, "SCSID", "SCSName", scheduledClass.SCSID);
            return View(scheduledClass);
        }

        //POST: ScheduledClasses/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduledClassId,CourseId,StartDate,EndDate,InstructorName,Location,SCSID")] ScheduledClass scheduledClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduledClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");


            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", scheduledClass.CourseId);
            ViewBag.SCSID = new SelectList(db.SchduledClassStatuses, "SCSID", "SCSName", scheduledClass.SCSID);
            return View(scheduledClass);
        }

        //GET: ScheduledClasses/Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
            if (scheduledClass == null)
            {
                return HttpNotFound();
            }
            return View(scheduledClass);
        }

        //POST: ScheduledClasses/Delete
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduledClass scheduledClass = db.ScheduledClasses.Find(id);
            db.ScheduledClasses.Remove(scheduledClass);
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