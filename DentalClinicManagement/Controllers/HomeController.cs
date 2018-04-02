using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;
using DentalClinicManagement.ViewModel;
namespace DentalClinicManagement.Controllers
{
    
    public class HomeController : Controller
    {
        graduationProjectEntities db = new graduationProjectEntities();
        BlogModel bm = new BlogModel();
        ClinicModel cm = new ClinicModel();
        IndexModel im = new IndexModel();
        SingleModel sm = new SingleModel();
        ServiceModel svm = new ServiceModel();
        ContactModel ctm = new ContactModel();
        BookingModel bkm = new BookingModel();
        DoctorModel dm = new DoctorModel();
        public ActionResult Index()
        {

            im._dental = db.Dental_clinic_details.FirstOrDefault();
            im._service = db.Services.ToList();
            im._news = db.News.Take(4).ToList();
            im._open = db.Open_hours.ToList();
            im._link = db.Links.ToList();
            im._doctors = db.Doctors.ToList();
            return View(im);
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {

            Appointment app = new Appointment();
            app.doctor_id = Convert.ToInt32(frm["doctor_id"]);
            app.patient_name = frm["name"];
            app.patient_email = frm["email"];
            app.patient_phone = frm["phone"];
            app.appoint_date = Convert.ToDateTime(frm["date"]);
            app.appoint_hour = Convert.ToDateTime(frm["time"]);
            db.Appointments.Add(app);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            cm._clinic = db.Dental_clinic_details.FirstOrDefault();
            cm._photo_list = db.Photos.ToList();
            cm._photo = cm._photo_list.ElementAt(0);
            cm._quotes = db.Customer_quotes.ToList();
            cm._supplier = db.Suppliers.ToList();
            cm._link = db.Links.ToList();
            cm._doctors = db.Doctors.Take(4).ToList();
            return View(cm);
        }
        public ActionResult Booking()
        {
            bkm._link = db.Links.ToList();
            bkm._open = db.Open_hours.ToList();
            return View(bkm);
        }
        [HttpPost]
        public ActionResult Booking(FormCollection frm)
        {
            Appointment app = new Appointment();
            app.patient_name = frm["name"];
            app.patient_email = frm["email"];
            app.patient_phone = frm["phone"];
            app.doctor_id = 6;
            app.appoint_date = Convert.ToDateTime(frm["date"]);
            app.appoint_hour = Convert.ToDateTime(frm["time"]);
            db.Appointments.Add(app);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Blog()
        {
                bm._news = db.News.OrderByDescending(x=>x.news_date).ToList();
                bm._link = db.Links.ToList();
                return View(bm);
          
        }
        
     

        public ActionResult Contact()
        {
            ctm._link = db.Links.ToList();
            ctm._details = db.Dental_clinic_details.FirstOrDefault();
            return View(ctm);
        }
        [HttpPost]
        public ActionResult Contact(FormCollection frm)
        {
            Message msg = new Message();
            msg.user_name = frm["name"];
            msg.user_email = frm["email"];
            msg.message_subject = frm["subject"];
            msg.message_text = frm["text"];
            db.Messages.Add(msg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Single(int id)
        {
            sm._link = db.Links.ToList();
            sm._all_news = db.News.ToList();
            sm._service = db.Services.ToList();
            sm._single_news = db.News.Where(n => n.id == id).FirstOrDefault();
            return View(sm);
        }
        public ActionResult Doctor(int id)
        {
            dm._single_doctor = db.Doctors.Where(d => d.id == id).FirstOrDefault();
            dm._link = db.Links.ToList();
            return View(dm);
        }
        public ActionResult Service(int id)
        {
            svm._link = db.Links.ToList();
            svm._single_service = db.Services.Where(v => v.id == id).FirstOrDefault();
            return View(svm);
        }
        public ActionResult NewsSearch(string search)
        {
            IEnumerable<News> news_list = db.News.Where(e => e.news_title.Contains(search)).ToList();
            return View(news_list);
        }
    }
}