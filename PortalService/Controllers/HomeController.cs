/***************************************************
    HomeController.cs

    Isaac Walker
****************************************************/

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Iot.Client.SettingService;
using Web.Iot.Models.Setting;
using Web.Iot.PortalService.Models.ViewModels;

namespace Web.Iot.PortalService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingServiceClient m_serviceClient;


        private readonly ILogger<HomeController> m_logger;


        public HomeController(ISettingServiceClient serviceClient, ILogger<HomeController> logger)
        {
            m_serviceClient = serviceClient;
            m_logger = logger;
        }


        // GET: /<controller>/
        [Route("home")]
        public async Task<ViewResult> Index([FromQuery] string setting)
        {
            m_logger.LogDebug(LogEventId.IndexGetStart, string.Format("Request for setting {0}", setting));

            ConfigurationModel configuration = null;

            if (setting == "current")
            {
                configuration = await m_serviceClient.GetCurrentConfigurationAsync();
            }
            else if (int.TryParse(setting, out int id))
            {
                configuration = await m_serviceClient.GetConfigurationAsync(id);
            }


            m_logger.LogDebug(LogEventId.IndexGetEnd, string.Format("Request for setting {0}, found: {1}", setting, configuration != default));

            if (configuration == default)
            {
                return View(new HomeModel() { SettingExists = false });
            }

            return View(new HomeModel() { Configuration = configuration, SettingExists = true });
        }


        [HttpPost]
        [Route("home/save")]
        public async Task<RedirectResult> Save( ConfigurationModel configuration)
        {
            m_logger.LogDebug(LogEventId.SaveConfigStart, string.Format("Saving configuration with {0} settings", configuration.Settings.Count));


            int Id = await m_serviceClient.SetCurrentConfigurationAsync(configuration);


            m_logger.LogDebug(LogEventId.SaveConfigEnd, string.Format("Created new configuration with new Id {0}", Id));


            return Redirect(string.Format("~/home?setting=current",Id));
        }
    }
}
