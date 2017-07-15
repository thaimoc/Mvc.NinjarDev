using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace eCommerce.DAL
{
    public class ContextSpecifiedLogFormatter : DatabaseLogFormatter
    {
        public ContextSpecifiedLogFormatter(DbContext context, Action<string> writerAction) : base(context, writerAction)
        {
        }

        public override void LogCommand<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            Write(Context == null
                ? $"Unknown context is executing command '{command.CommandText}'{Environment.NewLine}'"
                : $"Context '{Context.GetType().Name}' is executing command '{command.CommandText}'{Environment.NewLine}'");
        }
    }
}
