﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExpenseAppEntities : DbContext
    {
        public ExpenseAppEntities()
            : base("name=ExpenseAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }
        public virtual DbSet<TransactionsMaster> TransactionsMasters { get; set; }
        public virtual DbSet<UserLoginActivityMaster> UserLoginActivityMasters { get; set; }
        public virtual DbSet<UserTypeMaster> UserTypeMasters { get; set; }
        public virtual DbSet<CountryMaster> CountryMasters { get; set; }
        public virtual DbSet<CurrenyMaster> CurrenyMasters { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
    }
}
