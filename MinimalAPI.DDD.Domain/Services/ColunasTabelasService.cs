using MetodoKlinMilk.Domain.Entities;
using MetodoKlinMilk.Domain.Interfaces.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Services;

namespace MetodoKlinMilk.Domain.Services
{
    public class ColunasTabelasService : IColunasTabelasService
    {
        private readonly IColunasTabelasRepository _colunasTabelasRepository;
        public ColunasTabelasService(IColunasTabelasRepository colunasTabelasRepository)
        {
            _colunasTabelasRepository = colunasTabelasRepository;
        }

        Task<IEnumerable<ColunasTabelasEntityModel>> IServiceBase<ColunasTabelasEntityModel>.Add(ColunasTabelasEntityModel entity)
        {
            try
            {
                return _colunasTabelasRepository.Add(entity);
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

        bool IServiceBase<ColunasTabelasEntityModel>.Delete(ColunasTabelasEntityModel entity)
        {
            try
            {
                return _colunasTabelasRepository.Delete(entity);
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

        void IServiceBase<ColunasTabelasEntityModel>.Dispose()
        {
            try
            {
                _colunasTabelasRepository.Dispose();
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

        Task<ColunasTabelasEntityModel> IServiceBase<ColunasTabelasEntityModel>.Get(int? id)
        {
            try
            {
                return _colunasTabelasRepository.Get(id);
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

        Task<IEnumerable<ColunasTabelasEntityModel>> IServiceBase<ColunasTabelasEntityModel>.GetAll()
        {
            try
            {
                return _colunasTabelasRepository.GetAll();
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

        Task<IEnumerable<ColunasTabelasEntityModel>> IServiceBase<ColunasTabelasEntityModel>.Update(ColunasTabelasEntityModel entity)
        {
            try
            {
                return _colunasTabelasRepository.Update(entity);
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
