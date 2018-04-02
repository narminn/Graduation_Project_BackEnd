using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class ServiceModel
    {
        public Service _single_service { get; set; }
        public List<Link> _link { get; set; }
    }
}