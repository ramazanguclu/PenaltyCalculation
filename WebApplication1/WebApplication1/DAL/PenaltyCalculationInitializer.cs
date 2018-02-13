using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class PenaltyCalculationInitializer : CreateDatabaseIfNotExists<PenaltyCalculationContext>
    {
        protected override void Seed(PenaltyCalculationContext context)
        {
            List<Countries> countries = new List<Countries>
            {
                new Countries {Name = "Turkey"},
                new Countries {Name = "Dubai"}
            };

            countries.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();
        }
    }
}