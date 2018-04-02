using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using DentalClinicManagement.Models;
using DentalClinicManagement.ViewModel;
namespace DentalClinicManagement.Areas.Reception.Controllers
{
    [FilterReception]
    public class HomeController : Controller
    {
        graduationProjectEntities db = new graduationProjectEntities();
        ReceptionModel rm = new ReceptionModel();
        MessageModel mm = new MessageModel();
        AppModel am = new AppModel();
        AttendModel atm = new AttendModel();
        LeavesModel lm = new LeavesModel();
        // GET: Reception/Home
        public ActionResult Index()
        {
            var id = Convert.ToInt32(Session["id"]);
            rm._stuff = db.Stuffs.Where(s => s.id == id).FirstOrDefault();
            rm._note = db.Notes.ToList();
            rm._holiday = db.Holidays.ToList();
            return View(rm);
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
                Session["ReceptEmail"] = count.stuff_email;
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
        public ActionResult Messages()
        {
            var id = Convert.ToInt32(Session["id"]);
            mm._stuff = db.Stuffs.Where(s => s.id == id).FirstOrDefault();
            mm._message = db.Messages.ToList();
            return View(mm);
        }
        public ActionResult Appointments()
        {
            var id = Convert.ToInt32(Session["id"]);
            am._stuff = db.Stuffs.Where(s => s.id == id).FirstOrDefault();
            am._app = db.Appointments.ToList();
            return View(am);
        }
        public ActionResult Attendence()
        {
            var id = Convert.ToInt32(Session["id"]);
            atm._stuff = db.Stuffs.Where(s => s.id == id).FirstOrDefault();
            atm._doctors = db.Doctors.ToList();
            atm._stuffs = db.Stuffs.ToList();
            return View(atm);
        }
        [HttpPost]
        public ActionResult CreateAjax(string[] doctorArray, int[] checkArray)
        {
            bool[] checkbool = new bool[checkArray.Length];
            for (int i = 0; i < checkArray.Length; i++)
            {
                if (checkArray[i] == 1)
                {
                    checkbool[i] = true;
                }
                else
                {
                    checkbool[i] = false;
                }
            }
            Doctor_Attendence doc_att = new Doctor_Attendence();
            for (int i = 0; i < doctorArray.Length; i++)
            {
                doc_att.doctor_id = Convert.ToInt32(doctorArray[i]);
                doc_att.doctor_status = checkbool[i];
                doc_att.date = DateTime.Now;
                db.Doctor_Attendence.Add(doc_att);
                db.SaveChanges();
            }
            return Content(doctorArray.Length.ToString());
        }
        public ActionResult Leaves()
        {
            var id = Convert.ToInt32(Session["id"]);
            lm._stuff = db.Stuffs.Where(s => s.id == id).FirstOrDefault();
            lm._leaves = db.Leaves.ToList();
            return View(lm);
        }

        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MailMessage mailmessage = new MailMessage();
                    SmtpClient connect = new SmtpClient("smpt.gmail.com", 587);
                    mailmessage.From = new MailAddress("nasirovanarmin96@gmail.com", "Narmin", System.Text.Encoding.UTF8);
                    mailmessage.To.Add(receiver);
                    mailmessage.Subject = subject;
                    Random random = new Random();
                    mailmessage.Body = message;
                    connect.Credentials = new NetworkCredential("nasirovanarmin96@gmail.com", "yataqxana123");
                    connect.EnableSsl = true;
                    connect.Host = "smtp.gmail.com";
                    connect.Send(mailmessage);
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
    }
}