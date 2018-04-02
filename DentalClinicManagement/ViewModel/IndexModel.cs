using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class IndexModel
    {
        public Dental_clinic_details _dental { get; set; }
        public List<Service> _service { get; set; }
        public IEnumerable<News> _news { get; set; }
        public List<Open_hours> _open { get; set; }
        public List<Link> _link { get; set; }
        public List<Doctor> _doctors { get; set; }
    }
}