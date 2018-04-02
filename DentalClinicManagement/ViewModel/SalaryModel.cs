using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class SalaryModel
    {
        public List<Doctor> _doctors { get; set; }
        public Stuff _stuff { get; set; }
        public List<Leave> _leave { get; set; }
        public List<Award> _award { get; set; }
    }
}