using System.Data.Entity.ModelConfiguration;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using eCommerce.Classes;

namespace eCommerce.DAL.CustomMigrations
{
    public class OrderItemConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfiguration()
        {
            Ignore(c => c.DateCreated);
            Ignore(c => c.DateModified);
        }
    }
}