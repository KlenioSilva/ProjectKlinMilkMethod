using MetodoKlinMilk.Domain.Entities;
using MetodoKlinMilk.Domain.Interfaces.Repositories;
using MetodoKlinMilk.Domain.Interfaces.Services;

namespace MetodoKlinMilk.Domain.Services
{
    public class SnippetService : ISnippetService
    {
        private readonly ISnippetRepository _snippetRepository;
        public SnippetService(ISnippetRepository snippetRepository)
        {
            _snippetRepository = snippetRepository;
        }

        Task<IEnumerable<SnippetEntityModel>> IServiceBase<SnippetEntityModel>.Add(SnippetEntityModel entity)
        {
            try
            {
                return _snippetRepository.Add(entity);
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

        bool IServiceBase<SnippetEntityModel>.Delete(SnippetEntityModel entity)
        {
            try
            {
                return _snippetRepository.Delete(entity);
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

        void IServiceBase<SnippetEntityModel>.Dispose()
        {
            try
            {
                _snippetRepository.Dispose();
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

        Task<SnippetEntityModel> IServiceBase<SnippetEntityModel>.Get(int? id)
        {
            try
            {
                return _snippetRepository.Get(id);
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

        Task<IEnumerable<SnippetEntityModel>> IServiceBase<SnippetEntityModel>.GetAll()
        {
            try
            {
                return _snippetRepository.GetAll();
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

        Task<IEnumerable<SnippetEntityModel>> IServiceBase<SnippetEntityModel>.Update(SnippetEntityModel entity)
        {
            try
            {
                return _snippetRepository.Update(entity);
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
