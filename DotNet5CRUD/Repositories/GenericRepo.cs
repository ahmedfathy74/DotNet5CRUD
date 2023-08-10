using DotNet5CRUD.Models;
using DotNet5CRUD.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNet5CRUD.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T :class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int ID)
        {
            var entry = await _context.Set<T>().FindAsync(ID);
            if(entry is null)
            {
                throw new ArgumentNullException("Invalid ID , Please Enter Valid ID");
            }
            _context.Set<T>().Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllEntries(string[] includes = null)
        {
            IQueryable<T> RelatedEntities = _context.Set<T>();
            if(includes is not null)
            {
                foreach(var include in includes)
                {
                    RelatedEntities = RelatedEntities.Include(include);
                }
            }
            return await RelatedEntities.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllEntries<TKey>(Expression<Func<T, TKey>> orderBy = null,string[] includes = null)
        {
            IQueryable<T> RelatedEntities = _context.Set<T>();

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    RelatedEntities = RelatedEntities.Include(include);
                }
            }

            if (orderBy is not null)
            {
                RelatedEntities = RelatedEntities.OrderBy(orderBy);
            }

            return await RelatedEntities.ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
