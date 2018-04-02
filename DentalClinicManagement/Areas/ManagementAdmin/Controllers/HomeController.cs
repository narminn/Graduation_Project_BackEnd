using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;

namespace DentalClinicManagement.Areas.ManagementAdmin.Controllers
{
    [FilterManAdmin]
    public class HomeController : Controller
    {
        graduationProjectEntities db = new graduationProjectEntities();
        // GET: ManagementAdmin/Home
        public ActionResult Index()
        {
            return View();
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
            var count = db.User_Roles.Where(e => e.user_role_mail == email && e.user_role_password == password).FirstOrDefault();
            if (count != null)
            {
                var employee = db.User_Roles.First(p => p.user_role_mail == email && p.user_role_password == password);
                Session["ManAdminEmail"] = count.user_role_mail;
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
    }
}