using MetodoKlinMilk.Domain.Entities;
using MetodoKlinMilk.Domain.Interfaces.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Services;

namespace MetodoKlinMilk.Services
{
    public class AcessoService : IAcessoService
    {
        private readonly IAcessoRepository _acessoRepository;
        public AcessoService(IAcessoRepository acessoRepository)
        {
            _acessoRepository = acessoRepository;
        }

        public bool Delete(AcessoEntityModel entity)
        {
            try
            {
                return _acessoRepository.Delete(entity);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (TimeoutException)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _acessoRepository?.Dispose();
        }

        public Task<AcessoEntityModel> Get(int? id)
        {
            try
            {
                return _acessoRepository.Get(id);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (TimeoutException)
            {
                throw;
            }
        }

        Task<IEnumerable<AcessoEntityModel>> IServiceBase<AcessoEntityModel>.Add(AcessoEntityModel entity)
        {
            try
            {
                return _acessoRepository.Add(entity);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (TimeoutException)
            {
                throw;
            }
        }

        Task<IEnumerable<AcessoEntityModel>> IServiceBase<AcessoEntityModel>.GetAll()
        {
            try
            {
                return _acessoRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (TimeoutException)
            {
                throw;
            }
        }

        Task<IEnumerable<AcessoEntityModel>> IServiceBase<AcessoEntityModel>.Update(AcessoEntityModel entity)
        {
            try
            {
                return _acessoRepository.Update(entity);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (TimeoutException)
            {
                throw;
            }
        }
    }
}
