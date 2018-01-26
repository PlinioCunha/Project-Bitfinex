using Domain.Core.Bitfinex;
using Domain.Core.Data;
using Domain.Core.Interfaces;
using Domain.Core.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Services;
using Infra.Data.Interfaces.MongoDB;
using Infra.Data.Repository.MongoDB;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC
{
    public class Bindings
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra.Data
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));


            // Domain.Core
            services.AddTransient(typeof(IDataUsuario), typeof(DataUsuario));
            services.AddTransient(typeof(IDataOrderBook), typeof(DataOrderBook));
            services.AddTransient(typeof(IApiBitfinex), typeof(Api));


            // Domain - Services
            services.AddTransient(typeof(IServiceUsuario), typeof(ServiceUsuario));
            services.AddTransient(typeof(IServiceBitfinex), typeof(ServiceBitfinex));
            services.AddTransient(typeof(IServiceOrderBook), typeof(ServiceOrderBook));
        }
    }
}
