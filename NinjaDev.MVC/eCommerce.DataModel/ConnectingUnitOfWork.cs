using System;
using System.Threading.Tasks;
using eCommerce.Classes;
using eCommerce.DataModel.Repositories;
using eCommerce.DAL;

namespace eCommerce.DataModel
{
    public class ConnectingUnitOfWork : IDisposable
    {
        private readonly DataContext _context;
        private SqlConnectingRepository<Customer> _customerConnectingRepository;
        private SqlConnectingRepository<Product> _productConnectingRepository;

        public ConnectingUnitOfWork(SqlConnectingRepository<Customer> customerConnectingRepository, SqlConnectingRepository<Product> productConnectingRepository, DataContext context)
        {
            _customerConnectingRepository = customerConnectingRepository;
            _productConnectingRepository = productConnectingRepository;
            _context = context;
        }

        public virtual Task<int> Commit()
        {

#if DEBUG
            _context.Database.Log = Console.WriteLine;
#endif
            return _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
