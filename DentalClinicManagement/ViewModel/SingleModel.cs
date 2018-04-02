using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;

namespace DentalClinicManagement.ViewModel
{
    public class SingleModel
    {
        public News _single_news { get; set; }
        public List<News> _all_news { get; set; }
        public List<Service> _service { get; set; }
        public List<Link> _link { get; set; }
    }
}