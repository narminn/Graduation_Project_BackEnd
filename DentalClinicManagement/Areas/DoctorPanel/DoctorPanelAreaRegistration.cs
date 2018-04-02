using System.Web.Mvc;

namespace DentalClinicManagement.Areas.DoctorPanel
{
    public class DoctorPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DoctorPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DoctorPanel_default",
                "DoctorPanel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}