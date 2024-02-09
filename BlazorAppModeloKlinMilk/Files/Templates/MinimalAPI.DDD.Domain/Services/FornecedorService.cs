using MinimalAPI.DDD.Domain.EntitiesModels;
using MinimalAPI.DDD.Domain.Interfaces.Repositories;
using MinimalAPI.DDD.Domain.Interfaces.Services;

namespace MinimalAPI.DDD.Domain.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public int Add(Fornecedor entity)
        {
            return _fornecedorRepository.Add(entity);
        }

        public int Delete(Fornecedor entity)
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

        public int Update(Fornecedor entity)
        {
            throw new NotImplementedException();
        }
    }
}
