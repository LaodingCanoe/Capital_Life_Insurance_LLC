﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capital_Life_Insurance_LLC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Capital_Life_Insurance_LLCEntities : DbContext
    {
        public Capital_Life_Insurance_LLCEntities()
            : base("name=Capital_Life_Insurance_LLCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CandidateCard> CandidateCard { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Quashions> Quashions { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Speciality> Speciality { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<CandidateEducation> CandidateEducation { get; set; }
    }
}
