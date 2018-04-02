using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class DoctorModel
    {
        public Doctor _single_doctor { get; set; }
        public List<Link> _link { get; set; }
    }
}