using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;
using DentalClinicManagement.ViewModel;
namespace DentalClinicManagement.Areas.DoctorPanel.Controllers
{
    [FilterDoctor]
    public class HomeController : Controller
    {
        graduationProjectEntities db = new graduationProjectEntities();
        UserModel um = new UserModel();
        DoctorLeaveModel dm = new DoctorLeaveModel();
        DoctorBookingModel dbm = new DoctorBookingModel();
        // GET: DoctorPanel/Home
        
        public ActionResult Index()
        {
            var id = Convert.ToInt32(Session["id"]);
            um._doctor = db.Doctors.Where(d => d.id == id).FirstOrDefault();
            um._holiday = db.Holidays.ToList();
            um._note = db.Notes.ToList();
            um._award = db.Awards.Where(w => w.award_doctor_id == id).ToList();
            um._doctors = db.Doctors.ToList();
            um._leave= db.Leaves.Where(l => l.doctor_id == id).ToList();
            return View(um);
        }
       
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            string email = frm["email"];
            string password = frm["password"];
            var count = db.Doctors.Where(e => e.doctor_email == email && e.doctor_password == password).FirstOrDefault();
            if (count != null)
            {
                var employee = db.Doctors.First(p => p.doctor_email == email && p.doctor_password == password);
                Session["DoctorEmail"] = count.doctor_email;
                Session["id"] = count.id;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
        public ActionResult MyLeave()
        {
            var id = Convert.ToInt32(Session["id"]);
            dm._leave = db.Leaves.Where(l => l.doctor_id == id).ToList();
            dm._doctor = db.Doctors.Where(c => c.id == id).FirstOrDefault();
            dm._award= db.Awards.Where(w => w.award_doctor_id == id).ToList();
            return View(dm);
        }
        public ActionResult SubmitLeave(FormCollection frm)
        {
            var id = Convert.ToInt32(Session["id"]);
            Leave leave = new Leave();
            leave.doctor_id = id;
            leave.leave_date = Convert.ToDateTime(frm["l_date"]);
            leave.leave_reason = frm["l_reason"];
            db.Leaves.Add(leave);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ChangePassword(FormCollection frm)
        {
            Doctor doctor = db.Doctors.Find(Session["id"]);

            string pass = Convert.ToString(doctor.doctor_password);
            string oldPass = frm["old_password"];
            string newPass = frm["new_password"];
            if (oldPass == pass)
            {
                doctor.doctor_password = newPass;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Bookings()
        {
            var id = Convert.ToInt32(Session["id"]);
            dbm._doctor_app = db.Appointments.Where(p => p.doctor_id == id).ToList();
            dbm._doctor = db.Doctors.Where(c => c.id == id).FirstOrDefault();
            return View(dbm);
        }
    }
}