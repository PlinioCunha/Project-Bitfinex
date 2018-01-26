using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Interfaces;
using Newtonsoft.Json;
namespace Domain.Core.Bitfinex
{
    public class Api : IApiBitfinex
    {
        public const string baseUrl = "https://api.bitfinex.com/v1";


        public const string SymbolDetails = "https://api.bitfinex.com/v1/symbols_details";
        public const string OrderBook = "https://api.bitfinex.com/v1/book/";

        


        HttpClient _client = new HttpClient();


        public async Task<T> GetAsnyc<T>(string urlPath)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            

            T obj = default(T);
            HttpResponseMessage response = await _client.GetAsync(urlPath);
            if (response.IsSuccessStatusCode)
            {
                string x = await response.Content.ReadAsStringAsync();
                obj = JsonConvert.DeserializeObject<T>(x);
            }

            return obj;

        }

        public T Get<T>(string urlPath)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            T obj = default(T);
            var response = _client.GetAsync(urlPath).Result;
            if (response.IsSuccessStatusCode)
            {
                string x = response.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<T>(x);
            }

            return obj;

        }

    }





}
