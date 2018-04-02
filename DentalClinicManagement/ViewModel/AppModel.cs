using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class AppModel
    {
        public List<Appointment> _app { get; set; }
        public Stuff _stuff { get; set; }
    }
}