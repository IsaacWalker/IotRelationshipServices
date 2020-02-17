/***************************************************
    Startup.cs

    Isaac Walker
****************************************************/

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Iot.Models.Setting;
using Web.Iot.SettingService.Contracts;
using Web.Iot.SettingService.Settings;

namespace Web.Iot.SettingService
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
            services.AddDbContext<SettingServiceContext>(op => op.UseInMemoryDatabase("SettingServiceDB"));
            services.AddSingleton<ISettingProcessor, SettingsProcessor>();

            services.AddControllers();
            services.AddMvc().AddMvcOptions(O => O.EnableEndpointRouting = false);
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AddDefaultData(app);

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

        private void AddDefaultData(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<SettingServiceContext>();

                var initialSettings = new Configuration() { };
                context.Configurations.Add(initialSettings);

                context.SaveChanges();

                var ScannerSleepTime = new Setting { Name = "ScannerSleepTime", Type = SettingType.Integer, Value = "4000" };
                var PusherSleepTime = new Setting { Name = "PusherSleepTime", Type = SettingType.Integer, Value = "10000" };
                var PusherBatchSize = new Setting { Name = "PusherBatchSize", Type = SettingType.Integer, Value = "5" };
                var ScanningTime = new Setting { Name = "ScanningTime", Type = SettingType.Integer, Value = "3000" };
                var SettingSleepTime = new Setting { Name = "SettingSleepTime", Type = SettingType.Integer, Value = "20000" };
                var MeetingFrequency = new Setting { Name = "MeetingFrequency", Type = SettingType.Integer, Value = "3" };
                
                context.Settings.Add(ScannerSleepTime);
                context.Settings.Add(PusherSleepTime);
                context.Settings.Add(PusherBatchSize);
                context.Settings.Add(ScanningTime);
                context.Settings.Add(SettingSleepTime);
                context.Settings.Add(MeetingFrequency);

                context.SaveChanges();

                InsertSettingEntrySetting(context, initialSettings, ScannerSleepTime); 
                InsertSettingEntrySetting(context, initialSettings, PusherSleepTime);
                InsertSettingEntrySetting(context, initialSettings, PusherBatchSize);
                InsertSettingEntrySetting(context, initialSettings, ScanningTime);
                InsertSettingEntrySetting(context, initialSettings, SettingSleepTime);
                InsertSettingEntrySetting(context, initialSettings, MeetingFrequency);

                context.SaveChanges();
            }        
        }

        private void InsertSettingEntrySetting(SettingServiceContext context, Configuration ses, Setting setting)
        {
            context.ConfigurationSettings.Add(new ConfigurationSetting { SettingId = setting.Id, ConfigurationId = ses.ConfigurationId });
        }
    }
}
