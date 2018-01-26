using Domain.Core.Bitfinex;
using Domain.Core.Interfaces;
using Domain.Core.Models.Bitfinex;
using Domain.Interfaces.Services;
using Infra.Data.Interfaces.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceBitfinex : IServiceBitfinex
    {

        private readonly IMongoRepository<SymbolDetail> _dbSymbolDetail;
        private readonly IMongoRepository<OrderBook> _dbOrderBook;
        private IApiBitfinex _apiRepostitory;

        

        public ServiceBitfinex(IApiBitfinex apiRepostitory, IMongoRepository<SymbolDetail> dbSymbolDetail, IMongoRepository<OrderBook> dbOrderBook)
        {
            this._apiRepostitory = apiRepostitory;
            this._dbSymbolDetail = dbSymbolDetail;
            this._dbOrderBook = dbOrderBook;
        }

        public async Task<IEnumerable<SymbolDetail>> GetSymbols_Save()
        {
            var result = await _apiRepostitory.GetAsnyc<IEnumerable<SymbolDetail>>(Api.SymbolDetails);
            await _dbSymbolDetail.InsertManyAsync(result);

            return result;
        }


        public async Task OrderBook_Save(string symbolName)
        {
            var result = await _apiRepostitory.GetAsnyc<OrderBook>(Api.OrderBook + symbolName);
            await _dbOrderBook.InsertAsync(result, "OrderBook_" + symbolName);
        }

        
        public async Task<IEnumerable<SymbolDetail>> GetSymbols_Mongo(string money = "usd")
        {
            //var listSymbols = _dbSymbolDetail.Query().Where(a => a.pair.EndsWith(symbolName));
            //var result = _dbSymbolDetail.Query().Where(a => a.pair.EndsWith(symbolName)).GroupBy(item => item.pair)
            //     .Select(grouping => grouping.FirstOrDefault())
            //     .OrderByDescending(item => item.DateCreate);

            //var result = from symbol in listSymbols
            //              group symbol by symbol.pair into dateGroup
            //              select new SymbolDetail { pair = dateGroup.Key };

            var listSymbols = await _dbSymbolDetail.GetAllAsync(a => a.pair.EndsWith(money));
            var result = listSymbols.GroupBy(item => item.pair)
                 .Select(grouping => grouping.FirstOrDefault())
                 .OrderByDescending(item => item.DateCreate);

            return result;
        }


    }
}

