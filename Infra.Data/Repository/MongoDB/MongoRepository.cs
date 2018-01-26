using Infra.Data.Interfaces.MongoDB;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Data.Repository.MongoDB
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {

        private readonly IMongoDatabase _db;
        private IMongoCollection<T> _collection;

        #region Construtor
        public MongoRepository()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.json");
            var configuration = builder.Build();

            var client = new MongoClient(configuration.GetSection(MongoBase._conexao).Value);
            if (client != null)
                _db = client.GetDatabase(configuration.GetSection(MongoBase._dataBase).Value);
            else
                throw new Exception("Falha ao conectar no banco de dados MongoDB.");
        }
        #endregion


        public IMongoQueryable<T> Query(string colecao = null)
        {
            return _db.GetCollection<T>(string.IsNullOrEmpty(colecao) ? typeof(T).Name : colecao).AsQueryable<T>();
        }


        #region Find /  GetAll
        public async Task<T> FindAsync(Expression<Func<T, bool>> filter, string colecao = null)
        {
            _collection = _db.GetCollection<T>(string.IsNullOrEmpty(colecao) ? typeof(T).Name : colecao);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string colecao = null)
        {
            _collection = _db.GetCollection<T>(string.IsNullOrEmpty(colecao) ? typeof(T).Name : colecao);
            return await _collection.Find(filter == null ? _ => true : filter).ToListAsync();
        }
        #endregion

        #region Insert
        public async Task<T> InsertAsync(T model, string colecao = null)
        {
            _collection = _db.GetCollection<T>(string.IsNullOrEmpty(colecao) ? typeof(T).Name : colecao);
            await _collection.InsertOneAsync(model);

            return model;
        }

        public async Task InsertManyAsync(IEnumerable<T> model, string colecao = null)
        {
            _collection = _db.GetCollection<T>(string.IsNullOrEmpty(colecao) ? typeof(T).Name : colecao);
            await _collection.InsertManyAsync(model);
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> filter = null, string colecao = null)
        {
            //_collection = _db.GetCollection<T>(string.IsNullOrEmpty(colecao) ? typeof(T).Name : colecao);
            //var result = await _collection.DeleteOneAsync(filter);
            //return result.IsAcknowledged && result.DeletedCount > 0;

            var result = await _collection.FindOneAndDeleteAsync(filter);
            return true;
            
        }

        public async Task<bool> DeleteManyAsync(Expression<Func<T, bool>> filter = null, string colecao = null)
        {
            _collection = _db.GetCollection<T>(string.IsNullOrEmpty(colecao) ? typeof(T).Name : colecao);
            var result = await _collection.DeleteManyAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }
        #endregion

        #region Update
        public async Task<bool> UpdateAsync(T model, Expression<Func<T, bool>> filter = null, string colecao = null)
        {
            _collection = _db.GetCollection<T>(string.IsNullOrEmpty(colecao) ? typeof(T).Name : colecao);
            var update = Builders<T>.Update.Set(s => s, model);
            var result = await _collection.UpdateOneAsync(filter, update);

            //var result = await _collection.FindOneAndUpdateAsync(filter, model);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
        #endregion





        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).                    
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MongoRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion



    }
}
