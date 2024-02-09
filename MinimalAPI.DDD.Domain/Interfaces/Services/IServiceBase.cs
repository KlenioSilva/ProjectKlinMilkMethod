namespace MetodoKlinMilk.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Add(TEntity entity);
        Task<IEnumerable<TEntity>> Update(TEntity entity);
        bool Delete(TEntity entity);
        Task<TEntity> Get(int? id);
        Task<IEnumerable<TEntity>> GetAll();
        void Dispose();
    }
}
