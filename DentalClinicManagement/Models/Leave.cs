//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DentalClinicManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Leave
    {
        public int id { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public string leave_reason { get; set; }
        public Nullable<System.DateTime> leave_date { get; set; }
    
        public virtual Doctor Doctor { get; set; }
    }
}
