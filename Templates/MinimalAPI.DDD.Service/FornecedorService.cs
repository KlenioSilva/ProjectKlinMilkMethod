using MinimalAPI.DDD.Domain.EntitiesModels;
using MinimalAPI.DDD.Domain.Interfaces.Services;
using MinimalAPI.DDD.;

namespace MinimalAPI.DDD.Domain.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly Context dbContext;

        public void Add(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Fornecedor Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Fornecedor entity)
        {
            throw new NotImplementedException();
        }
    }
}
