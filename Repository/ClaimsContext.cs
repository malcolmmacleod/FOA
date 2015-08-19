using FOA.Claims.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace FOA.Claims.Repository
{
    public class ClaimsContext : DbContext
    {
        public DbSet<Claim> Claims { get; set; }

        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
