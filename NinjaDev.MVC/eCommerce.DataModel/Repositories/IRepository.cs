namespace eCommerce.DataModel.Repositories
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>
    {
         
    }
}