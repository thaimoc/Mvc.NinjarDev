using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using eCommerce.Classes.Intefaces;

namespace eCommerce.DataModel.Repositories
{
    /// <summary>
    /// This is Connectiong Repository to use in WPF, Windows App but you should'n use it for MVC App, Web App (replace by DisConnectRepository)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlConnectingRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        readonly DbContext _ctx;
        readonly DbSet<T> _set;

        private bool _disposed = false;

        public SqlConnectingRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }

        public virtual void Insert(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }

        public virtual void Update(T entityToUpdate)
        {
            _set.Attach(entityToUpdate);
            _ctx.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_ctx.Entry(entityToDelete).State == EntityState.Detached)
            {
                _set.Attach(entityToDelete);
            }
            _set.Remove(entityToDelete);
        }

        public virtual Task<List<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperties = "")
        {
            IQueryable<T> query = _set;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderby != null)
            {
                return orderby(query).ToListAsync();
            }
            return query.ToListAsync();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            this._disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            // Prevent the GC from calling Object.Finalize on an 
            // object that does not require it
            GC.SuppressFinalize(this);
        }
    }
    
}