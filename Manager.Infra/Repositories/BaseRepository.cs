using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(long id)
        {
            var entity = Get(id);

            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> Get(long id)
        {
            var entity = await _context.Set<T>().AsNoTracking().Where(x => x.Id == id).ToListAsync();

            return entity.FirstOrDefault();
        }

        public async Task<List<T>> GetAll()
        {
            var entities = await _context.Set<T>().AsNoTracking().ToListAsync();

            return entities;
        }

        public async Task<T> Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
