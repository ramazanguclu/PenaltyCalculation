using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class PenaltyCalculationContext : DbContext
    {
        public PenaltyCalculationContext() : base("PenaltyCalculationDataBase") { }

        public DbSet<Countries> Countries { get; set; }
        public DbSet<Holidays> Holidays { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<Weekends> Weekends { get; set; }
        public DbSet<PanelizedAmount> PanelizedAmount { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}