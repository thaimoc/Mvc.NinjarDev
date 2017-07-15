using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using eCommerce.Classes;

namespace eCommerce.DAL.CustomMigrations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            Property(n => n.Name)
                .HasColumnAnnotation("Index", new IndexAnnotation
                    (new IndexAttribute("PersonName")
                    {
                        IsClustered = false,
                        IsUnique = false,
                        Order = 3
                    }));

        }
    }
}