using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class AttendModel
    {
        public Stuff _stuff { get; set; }
        public List<Doctor> _doctors { get; set; }
        public List<Stuff> _stuffs { get; set; }
    }
}