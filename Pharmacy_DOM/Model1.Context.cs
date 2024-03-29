﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy_DOM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PharmacyEntities : DbContext
    {
        public PharmacyEntities()
            : base("name=PharmacyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MedicineConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new SellerConfiguration());
            modelBuilder.Configurations.Add(new BillingConfiguration());

        }
    
        public virtual DbSet<Billing_details> Billing_details { get; set; }
        public virtual DbSet<Category_details> Category_details { get; set; }
        public virtual DbSet<Med_details> Med_details { get; set; }
        public virtual DbSet<Seller_details> Seller_details { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
