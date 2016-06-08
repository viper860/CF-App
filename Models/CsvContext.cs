using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace Models
{
    public class CsvContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Postcode> Postcodes { get; set; }
        public DbSet<UsPresident> Presidents { get; set; }

        public DbSet<Athlete> Athletes { get; set; }

        public DbSet<Affiliate> Affiliates { get; set; }

        public DbSet<LeaderboardThirteen> LeaderboardThirteens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Athlete>().HasKey(a => a.CfId);
            modelBuilder.Entity<Athlete>().HasOptional(a => a.LeaderboardThirteen).WithOptionalDependent(l => l.Athlete);
            //modelBuilder.Entity<LeaderboardThirteen>().HasOptional(a => a.LeaderboardThirteen).WithOptionalDependent(l => l.Athlete);
        }
    }
}
