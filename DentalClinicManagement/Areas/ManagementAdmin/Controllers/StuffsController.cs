using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;

namespace DentalClinicManagement.Areas.ManagementAdmin.Controllers
{
    [FilterManAdmin]
    public class StuffsController : Controller
    {
        private graduationProjectEntities db = new graduationProjectEntities();

        // GET: ManagementAdmin/Stuffs
        public ActionResult Index()
        {
            var stuffs = db.Stuffs.Include(s => s.Gender).Include(s => s.MarrigeStatu);
            return View(stuffs.ToList());
        }

        // GET: ManagementAdmin/Stuffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stuff stuff = db.Stuffs.Find(id);
            if (stuff == null)
            {
                return HttpNotFound();
            }
            return View(stuff);
        }

        // GET: ManagementAdmin/Stuffs/Create
        public ActionResult Create()
        {
            ViewBag.stuff_gender_id = new SelectList(db.Genders, "id", "gender_name");
            ViewBag.stuff_marriage_status_id = new SelectList(db.MarrigeStatus, "id", "status_name");
            return View();
        }

        // POST: ManagementAdmin/Stuffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,stuff_fullname,stuff_about,stuff_photo,stuff_gender_id,stuff_marriage_status_id,stuff_phone,stuff_email,stuff_address,stuff_salary,stuff_birthday,stuff_start_date,stuff_start_time,stuff_finish_time,stuff_password")] Stuff stuff, HttpPostedFileBase stuff_photo)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 100000);
                var filename = Path.GetFileName(stuff_photo.FileName);
                var src = Path.Combine(Server.MapPath("~/Uploads/"), randomNumber + filename);
                stuff_photo.SaveAs(src);
                stuff.stuff_photo = "/Uploads/" + randomNumber + filename;
                db.Stuffs.Add(stuff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.stuff_gender_id = new SelectList(db.Genders, "id", "gender_name", stuff.stuff_gender_id);
            ViewBag.stuff_marriage_status_id = new SelectList(db.MarrigeStatus, "id", "status_name", stuff.stuff_marriage_status_id);
            return View(stuff);
        }

        // GET: ManagementAdmin/Stuffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stuff stuff = db.Stuffs.Find(id);
            if (stuff == null)
            {
                return HttpNotFound();
            }
            ViewBag.stuff_gender_id = new SelectList(db.Genders, "id", "gender_name", stuff.stuff_gender_id);
            ViewBag.stuff_marriage_status_id = new SelectList(db.MarrigeStatus, "id", "status_name", stuff.stuff_marriage_status_id);
            return View(stuff);
        }

        // POST: ManagementAdmin/Stuffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,stuff_fullname,stuff_about,stuff_photo,stuff_gender_id,stuff_marriage_status_id,stuff_phone,stuff_email,stuff_address,stuff_salary,stuff_birthday,stuff_start_date,stuff_start_time,stuff_finish_time,stuff_password")] Stuff stuff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stuff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.stuff_gender_id = new SelectList(db.Genders, "id", "gender_name", stuff.stuff_gender_id);
            ViewBag.stuff_marriage_status_id = new SelectList(db.MarrigeStatus, "id", "status_name", stuff.stuff_marriage_status_id);
            return View(stuff);
        }

        // GET: ManagementAdmin/Stuffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stuff stuff = db.Stuffs.Find(id);
            if (stuff == null)
            {
                return HttpNotFound();
            }
            return View(stuff);
        }

        // POST: ManagementAdmin/Stuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stuff stuff = db.Stuffs.Find(id);
            db.Stuffs.Remove(stuff);
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
