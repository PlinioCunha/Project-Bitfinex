using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace Domain.Core.Models
{

    public class Usuario
    {
        public Usuario()
        {
            this.LogAcesso = new LogAcessoUsuario();
            this.guid = Guid.NewGuid();
        }
        
        [BsonId]
        [JsonIgnore]
        public ObjectId _id { get; set; }

        public Guid guid { get; set; }
        public Int32 IdUsuario { get; set; }        
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public LogAcessoUsuario LogAcesso { get; set; }
    }

    public class LogAcessoUsuario
    {
        public string IP { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
