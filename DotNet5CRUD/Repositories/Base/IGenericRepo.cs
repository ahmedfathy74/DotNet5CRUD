using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNet5CRUD.Repositories.Base
{
    public interface IGenericRepo<T> where T : class
    {
        Task Add(T entity);
        Task Delete(int ID);
        Task<T> Update(T entity);
        Task<T> GetByID(int id);
        Task<IEnumerable<T>> GetAllEntries(string[]? includes = null);
        Task<IEnumerable<T>> GetAllEntries<TKey>(Expression<Func<T, TKey>> orderBy = null, string[] includes = null);
    }
}
