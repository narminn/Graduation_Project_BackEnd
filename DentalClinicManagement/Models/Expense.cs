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
    
    public partial class Expense
    {
        public int id { get; set; }
        public string product_name { get; set; }
        public string product_price { get; set; }
        public Nullable<System.DateTime> expense_date { get; set; }
    }
}
