using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Cotacao")]
    public class CotacaoController : Controller
    {

        //private IServiceOrderBook _serviceOrderBook;

        ///// <summary>
        ///// 
        ///// </summary>        
        //public OrderBookController(IServiceOrderBook serviceOrderBook)
        //{
        //    this._serviceOrderBook = serviceOrderBook;
        //}


        ///// <summary>
        ///// GET: api/OrderBook
        ///// </summary>
        ///// <returns></returns>
        ////public IActionResult Get()
        ////{
        ////    return Json(null);
        ////}


        ///// <summary>
        ///// Get
        ///// </summary>
        ///// <param name="symbol"></param>
        ///// <returns></returns>
        //[HttpGet("{symbol}")]
        //public IActionResult Get(string symbol)
        //{
        //    return Json(_serviceOrderBook.GetOrderAsync(symbol));
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody]string symbol)
        //{
        //    return Json(_serviceOrderBook.SaveOrderBookAsync(symbol));
        //}

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


}

