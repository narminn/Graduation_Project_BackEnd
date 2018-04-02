﻿using System.Web.Mvc;

namespace DentalClinicManagement.Areas.Accountant
{
    public class AccountantAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Accountant";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Accountant_default",
                "Accountant/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}