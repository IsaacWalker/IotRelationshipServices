/***************************************************
    SettingsProcessor.cs

    Isaac Walker
****************************************************/

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.SettingService.Models;
using Web.Iot.SettingService.Settings;
using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    /// <summary>
    /// Processor for handling operations on settings
    /// </summary>
    public class SettingsProcessor : ISettingProcessor
    {
        private readonly IServiceProvider m_provider;


        private SettingsModel _currentSettingsModel;


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

                if (_currentSettingsModel != null)
                {
                    return Task.FromResult(new GetCurrentSettingsResponse(true, _currentSettingsModel));
                }

                var settingEntries = context.SettingsEntries
                    .FirstOrDefault();

                if (settingEntries == null)
                {
                    return Task.FromResult(new GetCurrentSettingsResponse(false, null));
                }

                
                var settings = context.SettingsEntrySettings
                    .Where(ses => ses.SettingsEntryId == settingEntries.SettingsEntryId)
                    .Select(ses => ses.Setting)
                    .Select(set => new SettingModel { Name = set.Name, Type = set.Type, Value = set.Value })
                    .ToList();

                SettingsModel model = new SettingsModel()
                {
                    Id = settingEntries.SettingsEntryId,
                    Settings = settings
                };

                _currentSettingsModel = model;

                return Task.FromResult(new GetCurrentSettingsResponse(true, _currentSettingsModel));
            }
        }


        /// <summary>
        /// Sets the Current Setting
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public Task<SetCurrentSettingsResponse> Run(SetCurrentSettingsRequest Request)
        {
            return Task.FromResult(new SetCurrentSettingsResponse(true, AddSettingsModel(Request.SettingsModel)));
        }


        private int AddSettingsModel(SettingsModel settingsModel)
        {
            using (var scope = m_provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<SettingServiceContext>();

                var settings = settingsModel.Settings
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
                        context.Settings.Add(presentSetting);
                    }
                       
                    setting.Id = presentSetting.Id;
                }


                // Is There a Settings Entry in the database where has identical settings
                var settingEntry = context.SettingsEntries
                    .ToList()
                    .Where(SE => SE.SettingsEntrySettings
                    .All(SES => settings.Any(S => SES.SettingId == S.Id)))
                    .FirstOrDefault();

                if(settingEntry == null)
                {
                    settingEntry = new SettingsEntry();
                    context.Add(settingEntry);

                    foreach (var setting in settings)
                    {
                        context.SettingsEntrySettings.Add(new SettingsEntrySetting 
                        { 
                            SettingId = setting.Id, SettingsEntryId = settingEntry.SettingsEntryId 
                        });
                    }
                }

                context.SaveChanges();

                return settingEntry.SettingsEntryId;
            }
        }
    }
}
