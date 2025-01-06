using AllupOnion.Application.Abstraction.Generic;
using AllupOnion.Domain.Entities;
using AllupOnion.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AllupOnion.Persistence.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDBContext _context;
        private readonly DbSet<T> _table;
        public Repository(AppDBContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null,
            Expression<Func<T, object>> sort = null,
            bool IsDescending = false, 
            bool IsTracking = false, 
            int skip = 0,
            int take = 0, 
            params string[] includes)
        {
            IQueryable<T> query = _table;

           if(expression is not null) query = query.Where(expression);

           if(sort is not null) query=IsDescending?query.OrderByDescending(sort):query.OrderBy(sort);

           if(includes is not null)
            {
                query=getincludes(query,includes);
            }

           if(take!=0) query=query.Take(take);
            query=query.Skip(skip);  

            query=IsTracking? query:query.AsNoTracking();
            return query;

        }

        public async Task<T> GetbyIdAsync(int Id, params string[] includes)
        {
           IQueryable<T> query= _table;

            if(includes is not null)
            {
                query = getincludes(query, includes);
            }
             
            return await  query.FirstOrDefaultAsync(q=>q.Id==Id);
        }

        public void UpdateAsync(T entity)
        {
             _table.Update(entity);
        }
        public async Task AddAsync(T entity)
        {
           await _table.AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
           _table.Remove(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           return  await _table.AnyAsync(expression);
        }

        private IQueryable<T> getincludes(IQueryable<T> query,params string[] includes)
        { 
         for(int i = 0; i < query.Count(); i++)
            {
                query = query.Include(includes[i]);
            }
         return query;
        
        }
    }
}
