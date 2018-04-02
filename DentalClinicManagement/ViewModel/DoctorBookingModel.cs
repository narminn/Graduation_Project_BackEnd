using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class DoctorBookingModel
    {
        public List<Appointment> _doctor_app { get; set; }
        public Doctor _doctor { get; set; }
    }
}