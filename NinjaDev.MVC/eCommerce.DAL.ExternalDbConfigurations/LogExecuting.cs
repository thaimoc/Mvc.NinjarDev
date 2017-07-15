using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using NLog;

namespace eCommerce.DAL.Interceptors
{
    public class LogExecuting<T> : LogExecute<T>
    {
        protected override void LogAction(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            if (!interceptionContext.IsAsync)
            {
                Logger.Warn($"Non-async command used: {command.CommandText}");
            }
        }

        public LogExecuting(Logger logger, DbCommand command, DbCommandInterceptionContext<T> interceptionContext) : base(logger, command, interceptionContext)
        {
        }
    }
}