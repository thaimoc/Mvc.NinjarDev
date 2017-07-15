using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.SqlServer;
using eCommerce.DAL.Data_Migrations;
using eCommerce.DAL.Interceptors;

namespace eCommerce.DAL.DbConfigurations
{
    public class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            SetDefaultConnectionFactory(new SqlConnectionFactory(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;MultipleActiveResultSets=True"));

#if __AllowNullForSetInitializer__________

            SetDatabaseInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
            /*
                        SetDatabaseInitializer<DataContext>(null);
            */
            SetDatabaseInitializer(new NullDatabaseInitializer<DataContext>());
#endif

            SetHistoryContext(SqlProviderServices.ProviderInvariantName, (connection, defaultShema) => new MigrationsHistoryTableContext(connection, defaultShema));

            //var entries = new[]
            //{
            //    new CustomPluralizationEntry("Proveedor", "Proveedores"),
            //    new CustomPluralizationEntry("Cervecría", "Cervecrías")

            //};

            //SetPluralizationService(new EnglishPluralizationService(entries));
            //SetPluralizationService(new CustomPluralizationService.CustomPluralizationService());
            SetPluralizationService(new SpanishPluralizationService());

            SetMigrationSqlGenerator(SqlProviderServices.ProviderInvariantName, () => new CustomSqlMigrationSqlGenerator());

            AddInterceptor(new LoggingInterceptor());
        }
    }
}
