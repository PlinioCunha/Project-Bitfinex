using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace Domain.Core.Models.Bitfinex
{
    public class OrderBook
    {
        public OrderBook()
        {
            this._guid = Guid.NewGuid();
            this.DateCreate = DateTime.Now;
        }


        [BsonId]
        [JsonIgnore]
        public ObjectId _id { get; set; }

        public Guid _guid { get; set; }
        public DateTime DateCreate { get; set; }

        public Bid[] bids { get; set; }
        public Ask[] asks { get; set; }
    }

    public class Bid
    {
        public string price { get; set; }
        public string amount { get; set; }
        public string timestamp { get; set; }
    }

    public class Ask
    {
        public string price { get; set; }
        public string amount { get; set; }
        public string timestamp { get; set; }
    }

}




