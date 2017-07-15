using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using NLog;

namespace eCommerce.DAL.Interceptors
{
    public class LoggingInterceptor : IDbCommandInterceptor
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            var log = new LogExecuting<int>(Logger, command, interceptionContext);
            log.LogCallback();
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            var log = new LogExecuted<int>(Logger, command, interceptionContext);
            log.LogCallback();
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            var log = new LogExecuting<DbDataReader>(Logger, command, interceptionContext);
            log.LogCallback();
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            var log = new LogExecuted<DbDataReader>(Logger, command, interceptionContext);
            log.LogCallback();
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            var log = new LogExecuting<object>(Logger, command, interceptionContext);
            log.LogCallback();
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            var log = new LogExecuted<object>(Logger, command, interceptionContext);
            log.LogCallback();
        }
    }
}