using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;
using DentalClinicManagement.ViewModel;
namespace DentalClinicManagement.Areas.Accountant.Controllers
{
    [FilterAccount]
    public class HomeController : Controller
    {
        graduationProjectEntities db = new graduationProjectEntities();
        AccountantModel am = new AccountantModel();
        SalaryModel sm = new SalaryModel();
        // GET: Accountant/Home
        public ActionResult Index()
        {
            var id = Convert.ToInt32(Session["id"]);
            am._stuff = db.Stuffs.Where(s => s.id == id).FirstOrDefault();
            am._note = db.Notes.ToList();
            am._holiday = db.Holidays.ToList();
            return View(am);
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
            var count = db.Stuffs.Where(e => e.stuff_email == email && e.stuff_password == password).FirstOrDefault();
            if (count != null)
            {
                var employee = db.Stuffs.First(p => p.stuff_email == email && p.stuff_password == password);
                Session["AccountEmail"] = count.stuff_email;
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
 
        public ActionResult ChangePassword(FormCollection frm)
        {
            Stuff stuff = db.Stuffs.Find(Session["id"]);

            string pass = Convert.ToString(stuff.stuff_password);
            string oldPass = frm["old_password"];
            string newPass = frm["new_password"];
            if (oldPass == pass)
            {
                stuff.stuff_password = newPass;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Salary()
        {
            var id = Convert.ToInt32(Session["id"]);
            sm._stuff = db.Stuffs.Where(s => s.id == id).FirstOrDefault();
            sm._doctors = db.Doctors.ToList();
            sm._leave = db.Leaves.ToList();
            sm._award = db.Awards.ToList();
            return View(sm);
        }
    }
}