namespace MinimalAPI.DDD.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        void Dispose();
    }
}
