﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FieldGroupProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Delivery_DBEntities : DbContext
    {
        public Delivery_DBEntities()
            : base("name=Delivery_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<menu> menus { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}