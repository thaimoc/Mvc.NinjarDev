using System.Data.Entity.ModelConfiguration;
using eCommerce.Classes;
using EntityFramework.Filters;

namespace eCommerce.DAL.CustomMigrations
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            HasRequired(n => n.TrueIdentity).WithRequiredPrincipal(ti => ti.Customer);

            //HasTableAnnotation("TrackDatabaseChanges", true);

            HasTableAnnotation("View",
            "CustomersWhoHadTheFirstOrder" +
            "|SELECT [Key],CustomerName FROM History.Customers  WHERE OrderLevel=1"
            );

            //MapToStoredProcedures();

            MapToStoredProcedures(
                s =>
                {
                    s.Insert(i => i.HasName("[Customers_Insert]").Parameter(j => j.Key, "CustomerKey")
                    .Navigation<CustomerArea>(
                        ca => ca.Customers, c => c.Parameter(p => p.Key, "CustomerArea_FKKey")
                        )
                    //.Result(c => c.Key, "CustomerKey")
                    );
                    s.Update(u => u.HasName("[Customers_Update]"));
                    s.Delete(d => d.HasName("[Customers_Delete]").Parameter(c => c.Key, "CustomerKey"));
                });

            this.Filter("IsNotDeletedCustomers", c => c.Condition(cus => cus.IsDeleted == false)); // IsDeleted = true
        }
    }
}
