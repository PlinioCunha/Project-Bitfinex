using Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Api
{
    public class Startup
    {

        /// <summary>
        /// Construtor
        /// </summary>
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        


        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // IoC - Injeção de Dependência
            Bindings.RegisterServices(services);

            // remove object null in return json
            services.AddMvc().AddJsonOptions(o => 
                o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore);


            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Projeto Bitfinex",
                    Description = "A simple example ASP.NET Core Web API, projeto destinado a referencia e estudos compartilhado.",
                    TermsOfService = "None",
                    //Contact = new Contact { Name = "Shayne Boyer", Email = "", Url = "https://twitter.com/spboyer" },
                    //License = new License { Name = "Use under LICX", Url = "https://example.com/license" }
                });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Api_V1.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
