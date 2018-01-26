using Api.Base;
using Domain.Core.Models.Bitfinex;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/OrderBook")]
    public class OrderBookController : BaseController
    {

        private IServiceOrderBook _serviceOrderBook;
        public OrderBookController(IServiceOrderBook serviceOrderBook)
        {
            this._serviceOrderBook = serviceOrderBook;
        }

        [HttpGet("{symbol}")]
        public IEnumerable<OrderBook> GetAsync(string symbol)
        {
            return _serviceOrderBook.GetOrderAsync(symbol).Result;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] symbol symbol)
        {
            await _serviceOrderBook.SaveOrderBookAsync(symbol.pair);
            return Json(
                new
                {
                    Mensagem = "OrderBook " + symbol.pair.ToUpper() + " Salvo com sucesso",
                    Success= true
                });
        }

        //[HttpPut]
        //public IActionResult Put(string symbol)
        //{
        //    return Json(_serviceOrderBook.GetOrderAsync(symbol));
        //}

        //[HttpDelete]
        //public IActionResult Delete(string symbol)
        //{
        //    return Json(_serviceOrderBook.GetOrderAsync(symbol));
        //}
    }

    public class symbol
    {
        public string pair { get; set; }
    }
}