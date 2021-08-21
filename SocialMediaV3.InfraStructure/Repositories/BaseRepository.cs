using Microsoft.EntityFrameworkCore;
using SocialMediaV3.Core.Entities;
using SocialMediaV3.Core.Interfaces;
using SocialMediaV3.InfraStructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaV3.InfraStructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SocialMediadbContext _context;
        private readonly DbSet<T> _entities;

        public BaseRepository(SocialMediadbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
