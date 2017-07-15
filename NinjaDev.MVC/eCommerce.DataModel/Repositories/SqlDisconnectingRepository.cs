using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using eCommerce.Classes.Intefaces;
using eCommerce.DAL;

namespace eCommerce.DataModel.Repositories
{
    /// <summary>
    /// This is the disconnecting repository you should use it for MVC or web api, or other web application
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlDisconnectingRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        public virtual void Insert(T newEntity)
        {
            using (DataContext context = new DataContext())
            {
                context.Set<T>().Add(newEntity);
                context.SaveChangesAsync();
            }
        }

        public virtual void Update(T entityToUpdate)
        {
            using (DataContext context = new DataContext())
            {
                context.Set<T>().Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
                context.SaveChangesAsync();
            }
        }

        public virtual void Delete(T entityToDelete)
        {
            using (DataContext context = new DataContext())
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    context.Set<T>().Attach(entityToDelete);
                }


                context.Set<T>().Remove(entityToDelete);
                context.SaveChangesAsync();
            }
        }

        public virtual Task<List<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperties = "")
        {
            using (DataContext context = new DataContext())
            {
                IQueryable<T> query = context.Set<T>();
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

                if (orderby != null)
                {
                    return orderby(query).ToListAsync();
                }
                return query.ToListAsync();
            }
        }

        public virtual void Dispose()
        {
            // Prevent the GC from calling Object.Finalize on an 
            // object that does not require it
            GC.SuppressFinalize(this);
        }
    }
    
}