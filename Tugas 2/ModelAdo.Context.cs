﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tugas_2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyContexttt : DbContext
    {
        public MyContexttt()
            : base("name=MyContexttt")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_M_Item> TB_M_Item { get; set; }
        public virtual DbSet<TB_M_Sell> TB_M_Sell { get; set; }
        public virtual DbSet<TB_M_Supplier> TB_M_Supplier { get; set; }
        public virtual DbSet<TB_T_TransactionItem> TB_T_TransactionItem { get; set; }
    }
}
