using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eCommerce.DataModel.Repositories
{
    public interface IReadOnlyRepository<T> : IDisposable
    {
        Task<List<T>> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperties = "");
    }
}