using MetodoKlinMilk.Domain.Entities;
using MetodoKlinMilk.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MetodoKlinMilk.Data.Repositories
{
    public class AcessoRepository : IAcessoRepository
    {
        public AcessoRepository() { }

        private readonly Context _context;
        public AcessoRepository(Context context) 
        { 
            _context = context;
        }

        async Task<IEnumerable<AcessoEntityModel>> IRepositotyBase<AcessoEntityModel>.Add(AcessoEntityModel entity)
        {
            try
            {
                _context.Set<AcessoEntityModel>().Add(entity);
                await _context.SaveChangesAsync();
                return _context.Set<AcessoEntityModel>().ToList();
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

        async Task<IEnumerable<AcessoEntityModel>> IRepositotyBase<AcessoEntityModel>.Update(AcessoEntityModel entity)
        {
            try
            {
                var existingEntity = await _context.Set<AcessoEntityModel>().FindAsync(entity.Id);

                if (existingEntity == null)
                    throw new ArgumentException("Entidade não encontrada para atualização.");

                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados de forma assíncrona
                return _context.Set<AcessoEntityModel>().ToList();
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

        bool IRepositotyBase<AcessoEntityModel>.Delete(AcessoEntityModel entity)
        {
            try
            {
                var existingEntity = _context.Set<AcessoEntityModel>().Find(entity.Id);

                if (existingEntity == null)
                    return false;

                _context.Set<AcessoEntityModel>().Remove(existingEntity);
                _context.SaveChanges();

                return true;
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

        async Task<AcessoEntityModel> IRepositotyBase<AcessoEntityModel>.Get(int? id)
        {
            try
            {
                return await _context.Set<AcessoEntityModel>().FindAsync(id);
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

        async Task<IEnumerable<AcessoEntityModel>> IRepositotyBase<AcessoEntityModel>.GetAll()
        {
            try
            {
                return await _context.Set<AcessoEntityModel>().ToListAsync();
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
            _context.Dispose();
        }
    }
}
