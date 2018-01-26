using Domain.Core.Models.Bitfinex;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IServiceBitfinex
    {

        /// <summary>
        /// Pega lista de symbols details, grava no mongodb e retorna a lista completa da Api Bitfinex.com
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SymbolDetail>> GetSymbols_Save();


        /// <summary>
        /// Retornar todos os symbols details agrupados pelo "pair" (campo nome, exemplo: btcusd, iotusd, ethusd)
        /// </summary>
        /// <param name="symbolName">USD, BTC, ETH</param>
        /// <returns></returns>   
        Task<IEnumerable<SymbolDetail>> GetSymbols_Mongo(string symbolName);



        // <summary>
        /// Grava Order Book do symbol name
        /// </summary>
        /// <param name="symbolName">XRPUSD, BTCUSD, ETHUSD</param>
        /// <returns></returns>   
        Task OrderBook_Save(string symbolName);

    }
}
