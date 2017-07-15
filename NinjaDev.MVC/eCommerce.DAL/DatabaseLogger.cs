using System;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Data.Entity.Utilities;

namespace eCommerce.DAL
{
    //public class DatabaseLogger : IDisposable, IDbConfigurationInterceptor, IDbInterceptor
    //{
    //    private DatabaseLogFormatter _formatter;
    //    private TextWriter _writer;

    //    public DatabaseLogger()
    //    {
            
    //    }

    //    public DatabaseLogger(string path) : this(path, false)
    //    {
            
    //    }

    //    [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
    //    private DatabaseLogger(string path, bool append)
    //    {
    //        //System.Data.Entity.Utilities.Check.NotEmpty(path, "path");

    //        StreamWriter writer = new StreamWriter(path, append)
    //        {
    //            AutoFlush = true
    //        };
    //        this._writer = writer;
    //    }


    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        if (_formatter != null)
    //        {
    //            _formatter.Disposed();
    //        }
    //    }

    //    public void Dispose(bool predicate)
    //    {
    //        if (!predicate || _writer == null) return;
    //        _writer.Close();
    //        _writer.Dispose();
    //    }

    //    public void Loaded(DbConfigurationLoadedEventArgs loadedEventArgs, DbConfigurationInterceptionContext interceptionContext)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
