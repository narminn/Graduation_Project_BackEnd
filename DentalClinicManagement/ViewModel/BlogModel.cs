using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class BlogModel
    {
        public List<News> _news { get; set; }
        public List<Link> _link { get; set; }
    }
}