using Microsoft.EntityFrameworkCore;
using SmartManagerServer.Core.Repositories;
using SmartManagerServer.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Infrastructure.Resources
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SmartManagerServerContext context;
        public GenericRepository(SmartManagerServerContext context)
        {
            this.context = context;
        }

        public async Task<T> GetBaseAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetBaseAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetBaseAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).ToListAsync();
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}
