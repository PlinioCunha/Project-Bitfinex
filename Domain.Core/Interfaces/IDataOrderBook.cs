using Domain.Core.Models.Bitfinex;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces
{


    public interface IDataOrderBook
    {
        Task<IEnumerable<OrderBook>> GetOrderAsync(string symbol);
        IMongoQueryable<OrderBook> Query(Expression<Func<OrderBook, bool>> query = null);
        Task InsertAsync(OrderBook model, string symbol);
    }


}