using MetodoKlinMilk.Domain.Entities;
using MetodoKlinMilk.Domain.Interfaces.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Services;

namespace MetodoKlinMilk.Domain.Services
{
    public class TabelasBancoService : ITabelasBancoService
    {
        private readonly ITabelasBancoRepository _tabelaBancoRepository;
        public TabelasBancoService(ITabelasBancoRepository tabelasBancoRepository)
        {
            _tabelaBancoRepository = tabelasBancoRepository;
        }

        Task<IEnumerable<TabelasBancoEntityModel>> IServiceBase<TabelasBancoEntityModel>.Add(TabelasBancoEntityModel entity)
        {
            try
            {
                return _tabelaBancoRepository.Add(entity);
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

        bool IServiceBase<TabelasBancoEntityModel>.Delete(TabelasBancoEntityModel entity)
        {
            try
            {
                return _tabelaBancoRepository.Delete(entity);
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

        void IServiceBase<TabelasBancoEntityModel>.Dispose()
        {
            try
            {
                _tabelaBancoRepository.Dispose();
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

        Task<TabelasBancoEntityModel> IServiceBase<TabelasBancoEntityModel>.Get(int? id)
        {
            try
            {
                return _tabelaBancoRepository.Get(id);
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

        Task<IEnumerable<TabelasBancoEntityModel>> IServiceBase<TabelasBancoEntityModel>.GetAll()
        {
            try
            {
                return _tabelaBancoRepository.GetAll();
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

        Task<IEnumerable<TabelasBancoEntityModel>> IServiceBase<TabelasBancoEntityModel>.Update(TabelasBancoEntityModel entity)
        {
            try
            {
                return _tabelaBancoRepository.Update(entity);
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
