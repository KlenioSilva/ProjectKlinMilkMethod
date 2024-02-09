using MinimalAPI.DDD.Domain.EntitiesModels;
using MinimalAPI.DDD.Domain.Interfaces.Repositories;

namespace MinimalAPI.DDD.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly Context _context;
        public FornecedorRepository(Context context) 
        { 
            _context = context;
        }

        public int Add(Fornecedor entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
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
