﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFPR3.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MasterEntities : DbContext
    {
        public MasterEntities()
            : base("name=MasterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Calls> Calls { get; set; }
        public virtual DbSet<Masters> Masters { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Parts> Parts { get; set; }
        public virtual DbSet<Supplier_Type> Supplier_Type { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Warehouse_employees> Warehouse_employees { get; set; }
    }
}
