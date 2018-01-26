using MongoDB.Bson;
using Newtonsoft.Json;
using System;

namespace Domain.Core.Models.Bitfinex
{
    public class SymbolDetail
    {
        public SymbolDetail()
        {
            _guid = Guid.NewGuid();
            DateCreate = DateTime.Now;
        }

        [JsonIgnore]
        public ObjectId _id { get; set; }

        public Guid _guid { get; set; }

        public string pair { get; set; }
        public int price_precision { get; set; }
        public double initial_margin { get; set; }
        public double minimum_margin { get; set; }
        public double maximum_order_size { get; set; }
        public double minimum_order_size { get; set; }
        public string expiration { get; set; }
        public bool margin { get; set; }

        public DateTime DateCreate { get; set; }
    }

}
