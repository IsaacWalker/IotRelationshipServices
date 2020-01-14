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

                var initialSettings = new SettingsEntry() { };
                context.SettingsEntries.Add(initialSettings);

                context.SaveChanges();

                var ScannerSleepTimeSetting = new Setting { Name = "ScannerSleepTime", Type = SettingType.Integer, Value = "1000" };
                var PusherSleepTimeSetting = new Setting { Name = "PusherSleepTimeSetting", Type = SettingType.Integer, Value = "16000" };
                var PusherBatchSizeSetting = new Setting { Name = "PusherBatchSizeSetting", Type = SettingType.Integer, Value = "5" };
                var ScanningTimeSetting = new Setting { Name = "ScanningTimeSetting", Type = SettingType.Integer, Value = "3000" };

                context.Settings.Add(ScannerSleepTimeSetting);
                context.Settings.Add(PusherSleepTimeSetting);
                context.Settings.Add(PusherBatchSizeSetting);
                context.Settings.Add(ScanningTimeSetting);

                context.SaveChanges();

                InsertSettingEntrySetting(context, initialSettings, ScannerSleepTimeSetting); 
                InsertSettingEntrySetting(context, initialSettings, PusherSleepTimeSetting);
                InsertSettingEntrySetting(context, initialSettings, PusherBatchSizeSetting);
                InsertSettingEntrySetting(context, initialSettings, ScanningTimeSetting);

                context.SaveChanges();
            }        
        }

        private void InsertSettingEntrySetting(SettingServiceContext context, SettingsEntry ses, Setting setting)
        {
            context.SettingsEntrySettings.Add(new SettingsEntrySetting { SettingId = setting.Id, SettingsEntryId = ses.SettingsEntryId });
        }
    }
}
