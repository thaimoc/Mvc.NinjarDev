using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.SqlServer;
using eCommerce.DAL.Interceptors;

namespace eCommerce.DAL.DbConfigurations
{
    public class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            SetDefaultConnectionFactory(new SqlConnectionFactory(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;MultipleActiveResultSets=True"));
            SetHistoryContext(SqlProviderServices.ProviderInvariantName, (connection, defaultShema) => new MigrationsHistoryTableContext(connection, defaultShema));

            //SetDatabaseInitializer<DataContext>(null);


            SetPluralizationService(new SpanishPluralizationService());

            SetMigrationSqlGenerator(SqlProviderServices.ProviderInvariantName, () => new CustomSqlMigrationSqlGenerator());

            AddInterceptor(new LoggingInterceptor());
        }
    }
}
