using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class LeavesModel
    {
        public List<Leave> _leaves { get; set; }
        public Stuff _stuff { get; set; }
    }
}