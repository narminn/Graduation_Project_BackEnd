using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class UserModel
    {
        public Doctor _doctor { get; set; }
        public List<Holiday> _holiday { get; set; }
        public List<Note> _note { get; set; }
        public List<Award> _award { get; set; }
        public List<Doctor> _doctors { get; set; }
        public List<Leave> _leave { get; set; }
    }
}