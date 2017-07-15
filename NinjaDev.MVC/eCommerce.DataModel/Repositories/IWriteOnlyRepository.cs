using System;

namespace eCommerce.DataModel.Repositories
{
    public interface IWriteOnlyRepository<in T> : IDisposable
    {
        void Insert(T newEntity);
        void Update(T entityToUpdate);
        void Delete(T entityToDelete);
    }
}