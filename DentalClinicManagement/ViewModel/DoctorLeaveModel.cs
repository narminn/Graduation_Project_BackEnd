using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class DoctorLeaveModel
    {
        public List<Leave> _leave { get; set; }
        public Doctor _doctor { get; set; }
        public List<Award> _award { get; set; }
    }
}