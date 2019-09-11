/***************************************************
    Startup.cs

    Isaac Walker
****************************************************/

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Web.Iot.Shared.Message;
using Web.Iot.ScanService.MongoDB;
using Web.Iot.ScanService.MongoDB.Data;

namespace Web.Iot.ScanService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMongoCollection<Scan>>(GetScanCollection());
            services.AddSingleton<IProcessor<LogScanRequest, LogScanResponse>, LogScanAsync>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }


        private IMongoCollection<Scan> GetScanCollection()
        {
            IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("iotRelationshipDatabase");
            return mongoDatabase.GetCollection<Scan>("scanCollection");
        }
    }
}
