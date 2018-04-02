using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class BookingModel
    {
        public List<Open_hours> _open { get; set; }
        public List<Link> _link { get; set; }
    }
}