using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class ContactModel
    {
        public Dental_clinic_details _details { get; set; }
        public List<Link> _link { get; set; }
    }
}