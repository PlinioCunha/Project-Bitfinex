using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Data.Interfaces.MongoDB
{
    public interface IMongoRepository<T> : IDisposable where T : class
    {

        IMongoQueryable<T> Query(string colecao = null);

        #region Async 
        Task<T> FindAsync(Expression<Func<T, bool>> filter, string colecao = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string colecao = null);
        
        Task<T> InsertAsync(T model, string colecao = null);
        Task InsertManyAsync(IEnumerable<T> model, string colecao = null);
        
        Task<bool> UpdateAsync(T model, Expression<Func<T, bool>> filter = null, string colecao = null);
        
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter = null, string colecao = null);
        Task<bool> DeleteManyAsync(Expression<Func<T, bool>> filter = null, string colecao = null);
        #endregion
    }
}
