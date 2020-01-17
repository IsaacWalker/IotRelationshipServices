/***************************************************
    SettingsProcessor.cs

    Isaac Walker
****************************************************/

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.SettingService.Settings;
using Web.Iot.Shared.Message;
using Web.Iot.Shared.Setting;
using Web.Iot.Shared.Setting.Models;

namespace Web.Iot.SettingService.Contracts
{
    /// <summary>
    /// Processor for handling operations on settings
    /// </summary>
    public class SettingsProcessor : ISettingProcessor
    {
        private readonly IServiceProvider m_provider;


        private ConfigurationModel _currentConfigurationModel;


        public SettingsProcessor(IServiceProvider provider)
        {
            m_provider = provider;
        }


        /// <summary>
        /// Gets the Current Settings 
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public Task<GetCurrentSettingsResponse> Run(Request Request)
        {
            using (var scope = m_provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<SettingServiceContext>();

                if (_currentConfigurationModel != null)
                {
                    return Task.FromResult(new GetCurrentSettingsResponse(true, _currentConfigurationModel));
                }

                var configurations = context.Configurations
                    .FirstOrDefault();

                if (configurations == null)
                {
                    return Task.FromResult(new GetCurrentSettingsResponse(false, null));
                }

                
                var settings = context.ConfigurationSettings
                    .Where(cs => cs.ConfigurationId == configurations.ConfigurationId)
                    .Select(cs => cs.Setting)
                    .Select(set => new SettingModel { Name = set.Name, Type = set.Type, Value = set.Value })
                    .ToList();

                ConfigurationModel model = new ConfigurationModel()
                {
                    Id = configurations.ConfigurationId,
                    Settings = settings
                };

                _currentConfigurationModel = model;

                return Task.FromResult(new GetCurrentSettingsResponse(true, _currentConfigurationModel));
            }
        }


        /// <summary>
        /// Sets the Current Setting
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public Task<SetCurrentSettingsResponse> Run(SetCurrentSettingsRequest Request)
        {
            var response = new SetCurrentSettingsResponse(true, AddSettingsModel(Request.Configuration, true));         
            return Task.FromResult(response);
        }


        private int AddSettingsModel(ConfigurationModel configurationModel, bool SetToCurrent)
        {
            using (var scope = m_provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<SettingServiceContext>();

                var settings = configurationModel.Settings
                    .Select(S => new Setting { Name = S.Name, Type = S.Type, Value = S.Value })
                    .ToList();

                // Add the settings that are not currently in the database
                foreach(var setting in settings)
                {
                    var presentSetting = context.Settings
                        .ToList()
                        .Where(S => S.Equivalent(setting))
                        .FirstOrDefault();

                    // Setting is not in database yet
                    if(presentSetting == default)
                    {
                        context.Settings.Add(setting);
                    }
                    else
                    {
                        setting.Id = presentSetting.Id;
                    }               
                }


                // Is There a Settings Entry in the database where has identical settings
                var Configuration = context.Configurations
                    .Include(C => C.ConfigurationSettings)
                    .ToList()
                    .Where(C => C.ConfigurationSettings
                    .All(CS => settings.Any(S => S.Id == CS.SettingId)))
                    .Where(CS=> CS.ConfigurationSettings.Count == settings.Count())
                    .FirstOrDefault();


                if(Configuration == null)
                {
                    Configuration = new Configuration();
                    context.Configurations.Add(Configuration);

                    foreach (var setting in settings)
                    {
                        context.ConfigurationSettings.Add(new ConfigurationSetting 
                        { 
                            SettingId = setting.Id, ConfigurationId = Configuration.ConfigurationId
                        });
                    }
                }

                context.SaveChanges();
                
                if(SetToCurrent)
                {
                    configurationModel.Id = Configuration.ConfigurationId;
                    _currentConfigurationModel = configurationModel;
                }

                return configurationModel.Id;
            }
        }


        public Task<GetSettingResponse> Run(GetSettingRequest Request)
        {
            //TODO - Add caching

            using (var scope = m_provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<SettingServiceContext>();

                var settings = context.ConfigurationSettings
                    .Include(CS => CS.Setting)
                    .Where(CS => CS.ConfigurationId == Request.Id)
                    .Select(CS => new SettingModel()
                    { 
                        Name = CS.Setting.Name,
                        Type = CS.Setting.Type,
                        Value = CS.Setting.Value
                     })
                    .ToList();

                bool Success = settings.Count() != 0;

                if(Success)
                {
                    var configurationModel = new ConfigurationModel()
                    {
                        Id = Request.Id,
                        Settings = settings
                    };

                    return Task.FromResult(new GetSettingResponse(true, configurationModel));
                }
                else
                {
                    return Task.FromResult(new GetSettingResponse(false, default));
                }
            }
        }
    }
}
