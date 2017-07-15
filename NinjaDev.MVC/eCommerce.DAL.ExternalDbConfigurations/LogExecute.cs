using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using NLog;

namespace eCommerce.DAL.Interceptors
{
    public abstract class LogExecute<T>
    {
        protected readonly Logger Logger;
        public Action LogCallback { get; }

        protected LogExecute(Logger logger, DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            Logger = logger;
            LogCallback = () =>
            {
                LogTrace(command, interceptionContext);
                LogAction(command, interceptionContext);
            };
        }

        private void LogTrace(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            if (interceptionContext == null) throw new ArgumentNullException(nameof(interceptionContext));
            var initFlags = new[]
            {
                "Edm Metadata",
                "__MigrationHistory",
                "sys.databases",
                "serverproperty"
            };

            if (initFlags.Any(x => command.CommandText.Contains(x)))
                Logger.Info(command.CommandText);
            else
                Logger.Trace(command.CommandText);
        }

        protected abstract void LogAction(DbCommand command, DbCommandInterceptionContext<T> interceptionContext);
    }
}