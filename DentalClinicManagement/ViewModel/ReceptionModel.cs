using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class ReceptionModel
    {
        public Stuff _stuff { get; set; }
        public List<Holiday> _holiday { get; set; }
        public List<Note> _note { get; set; }
    }
}