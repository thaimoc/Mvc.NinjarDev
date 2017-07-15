using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using eCommerce.Classes;
using eCommerce.DAL.CustomMigrations;
using eCommerce.ModelConventions;

namespace eCommerce.DAL
{
    public class AreasContext : DbContext
    {
        public DbSet<CustomerArea> Areas { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(c => c.Ignore("IsDirty"));

            modelBuilder.Properties<Guid>().Where(p => p.Name == "Key").Configure(c => c.IsKey());

            var temp = new EntityTypeConfiguration<Person>();
            temp.Ignore(p => p.Customer);
            modelBuilder.Configurations.Add(temp);

            var cus = new CustomerConfigurations();
            modelBuilder.Configurations.Add(cus);

            modelBuilder.Conventions.Add(new TableSchemaAttributeConvention());

            modelBuilder.HasDefaultSchema("AnythingsBut_dbo");

            base.OnModelCreating(modelBuilder);
        }
    }
}
