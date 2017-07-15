using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace eCommerce.DAL.CustomMigrations
{
    public class CreateDataContextOperation : DatabaseCollationOperation, ICustomMigrationOperation
    {
        public bool ChangeTracking { get; private set; }

        public CreateDataContextOperation(string databaseName, string collation, bool changeTracking) : base(databaseName, collation)
        {
            ChangeTracking = changeTracking;
            GetSqlActionFull = $"exec sp_executesql N' ALTER DATABASE [{databaseName}] SET CHANGE_TRACKING = {(ChangeTracking ? "ON" : "OFF")}  '";
        }

        public override bool IsDestructiveChange => false;
        public string GetSqlActionFull { get; }
    }
}