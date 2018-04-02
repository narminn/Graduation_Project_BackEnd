using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class ClinicModel
    {
        public Dental_clinic_details _clinic { get; set; }
        public List<Photo> _photo_list { get; set; }
        public Photo _photo { get; set; }
        public List<Customer_quotes> _quotes { get; set; }
        public List<Supplier> _supplier { get; set; }
        public List<Link> _link { get; set; }
        public List<Doctor> _doctors { get; set; }
    }
}