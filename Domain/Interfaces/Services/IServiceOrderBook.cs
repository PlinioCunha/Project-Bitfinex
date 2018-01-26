using Domain.Core.Models.Bitfinex;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IServiceOrderBook
    {

        Task<IEnumerable<OrderBook>> GetOrderAsync(string symbol);
        Task SaveOrderBookAsync(string symbol);




    }
}
