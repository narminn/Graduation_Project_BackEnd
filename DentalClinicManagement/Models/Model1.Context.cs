﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class graduationProjectEntities : DbContext
    {
        public graduationProjectEntities()
            : base("name=graduationProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Customer_quotes> Customer_quotes { get; set; }
        public virtual DbSet<Dental_clinic_details> Dental_clinic_details { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor_Attendence> Doctor_Attendence { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<MarrigeStatu> MarrigeStatus { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Open_hours> Open_hours { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Stuff> Stuffs { get; set; }
        public virtual DbSet<Stuff_Attendence> Stuff_Attendence { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User_Roles> User_Roles { get; set; }
    }
}
