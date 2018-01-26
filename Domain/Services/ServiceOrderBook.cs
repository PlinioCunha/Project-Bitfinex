using Domain.Core.Bitfinex;
using Domain.Core.Interfaces;
using Domain.Core.Models.Bitfinex;
using Domain.Interfaces.Services;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceOrderBook : IServiceOrderBook
    {
        private readonly IDataOrderBook _dbOrderBook;
        private readonly IApiBitfinex _apiBitfinex;
        public ServiceOrderBook(IDataOrderBook orderBook, IApiBitfinex apiBitfinex)
        {
            this._dbOrderBook = orderBook;
            this._apiBitfinex = apiBitfinex;
        }


        public async Task<IEnumerable<OrderBook>> GetOrderAsync(string symbol)
        {
            // Layer Bussines
            return await _dbOrderBook.GetOrderAsync(symbol);
        }


        public IMongoQueryable<OrderBook> Query(Expression<Func<OrderBook, bool>> query = null)
        {
            return _dbOrderBook.Query(query);
        }

        public async Task SaveOrderBookAsync(string symbol)
        {
            var orderBook = await _apiBitfinex.GetAsnyc<OrderBook>(Api.OrderBook + symbol);
            await _dbOrderBook.InsertAsync(orderBook, symbol);
        }


        //public IEnumerable<Sym>


     
    }
}
