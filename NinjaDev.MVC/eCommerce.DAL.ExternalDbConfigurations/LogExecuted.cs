using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using NLog;

namespace eCommerce.DAL.Interceptors
{
    public class LogExecuted<T> : LogExecute<T>
    {
        protected override void LogAction(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            if (!interceptionContext.IsAsync)
            {
                Logger.Error($"Command {command.CommandText} failed with exception {interceptionContext.Exception}");
            }
        }

        public LogExecuted(Logger logger, DbCommand command, DbCommandInterceptionContext<T> interceptionContext) : base(logger, command, interceptionContext)
        {
        }
    }
}