using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalClinicManagement.Models;
namespace DentalClinicManagement.ViewModel
{
    public class MessageModel
    {
        public List<Message> _message { get; set; }
        public Stuff _stuff { get; set; }
    }
}