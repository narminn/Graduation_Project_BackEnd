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
    
    public partial class Stuff_Attendence
    {
        public int id { get; set; }
        public Nullable<int> stuff_id { get; set; }
        public Nullable<bool> stuff_status { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual Stuff Stuff { get; set; }
    }
}
