//using System.Data.Entity.Migrations;
//using System.Data.Entity.Migrations.Infrastructure;
//using System.Data.Entity.Migrations.Model;
//using eCommerce.DAL.CustomMigrations;

//namespace eCommerce.DAL
//{
//    public static class ExtentionMethods
//    {

//        public static void OperationCreateView(this DbMigration migration, string viewName, string viewQueryString)
//        {
//            ((IDbMigration)migration)
//                .AddOperation(new CustomMigrationOperation("CREATE VIEW", viewName, "", viewQueryString));
//        }

//        public static void OperationRemoveView(this DbMigration migration, string viewName)
//        {
//            ((IDbMigration)migration).AddOperation(new CustomMigrationOperation("DROP VIEW", viewName, "", ""));
//        }

//        public static void OperationCreateOrRemoveDatabase(this DbMigration migration, string databaseName, string collation, bool changeTracking)
//        {
//            ((IDbMigration)migration)
//                .AddOperation(new CreateDataContextOperation(databaseName, collation, changeTracking));
//        }

//        public static void ChangeTrackingDatabase(this DbMigration migration, bool changeTracking)
//        {
//            var temp =
//                new SqlOperation(
//                    $"exec sp_executesql N' ALTER DATABASE [eCommerce.DAL.DataContext] SET CHANGE_TRACKING = {(changeTracking ? "ON" : "OFF")}'");
//            temp.SuppressTransaction = false;
//            ((IDbMigration)migration)
//                .AddOperation(temp);
//        }
//    }
//}
