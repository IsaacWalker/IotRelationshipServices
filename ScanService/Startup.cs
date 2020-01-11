using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Web.Iot.ScanService.MongoDB;
using Web.Iot.ScanService.MongoDB.Data;
using Web.Iot.Shared.Message;

namespace Web.Iot.ScanService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMongoCollection<Scan>>(GetScanCollection());
            services.AddSingleton<IProcessor<LogScanRequest, LogScanResponse>, LogScanAsync>();
            services.AddMvc().AddMvcOptions( O => O.EnableEndpointRouting = false);
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }


        private IMongoCollection<Scan> GetScanCollection()
        {
            IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("iot_database");
            return mongoDatabase.GetCollection<Scan>("scan_collection");
        }
    }
}
