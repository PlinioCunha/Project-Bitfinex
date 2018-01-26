using Domain.Core.Interfaces;
using Domain.Core.Models.Bitfinex;
using Infra.Data.Interfaces.MongoDB;
using Infra.Data.Repository.MongoDB;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Core.Data
{
    public class DataOrderBook : IDataOrderBook
    {

        IMongoRepository<OrderBook> _repository;
        public DataOrderBook(IMongoRepository<OrderBook> repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<OrderBook>> GetOrderAsync(string symbol)
        {
            string colecao = string.Format("{0}_{1}", typeof(OrderBook).Name, symbol);
            return await _repository.GetAllAsync(null, colecao);
        }

        public IMongoQueryable<OrderBook> Query(Expression<Func<OrderBook, bool>> query = null)
        {
            return _repository.Query().Where(query);
        }

        public async Task InsertAsync(OrderBook model, string symbol)
        {
            string colecao = string.Format("{0}_{1}", typeof(OrderBook).Name, symbol);
            await _repository.InsertAsync(model, colecao);
        }




        //public IMongoQueryable<OrderBook> Update(Expression<Func<OrderBook, bool>> query = null)
        //{
        //    return _repository.Query().Where(query);
        //}

        //public IMongoQueryable<OrderBook> Delete(Expression<Func<OrderBook, bool>> query = null)
        //{
        //    return _repository.Query().Where(query);
        //}
    }
}

