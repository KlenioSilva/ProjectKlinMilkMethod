using MetodoKlinMilk.Domain.Entities;
using MetodoKlinMilk.Domain.Interfaces.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Services;

namespace MetodoKlinMilk.Domain.Services
{
    public class ParamService : IParamService
    {
        private readonly IParamRepository _paramRepository;
        public ParamService(IParamRepository paramRepository)
        {
            _paramRepository = paramRepository;
        }

        Task<IEnumerable<ParamEntityModel>> IServiceBase<ParamEntityModel>.Add(ParamEntityModel entity)
        {
            try
            {
                return _paramRepository.Add(entity);
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

        bool IServiceBase<ParamEntityModel>.Delete(ParamEntityModel entity)
        {
            try
            {
                return _paramRepository.Delete(entity);   
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

        void IServiceBase<ParamEntityModel>.Dispose()
        {
            try
            {
                _paramRepository.Dispose();
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

        Task<ParamEntityModel> IServiceBase<ParamEntityModel>.Get(int? id)
        {
            try
            {
                return _paramRepository.Get(id);
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

        Task<IEnumerable<ParamEntityModel>> IServiceBase<ParamEntityModel>.GetAll()
        {
            try
            {
                return _paramRepository.GetAll();
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

        Task<IEnumerable<ParamEntityModel>> IServiceBase<ParamEntityModel>.Update(ParamEntityModel entity)
        {
            try
            {
                return _paramRepository.Update(entity);
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
