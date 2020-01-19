/***************************************************
    HomeController.cs

    Isaac Walker
****************************************************/

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Iot.PortalService.Models.ViewModels;
using Web.Iot.PortalService.SettingService;
using Web.Iot.Shared.Setting.Models;

namespace Web.Iot.PortalService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceClient m_serviceClient;


        public HomeController(IServiceClient serviceClient)
        {
            m_serviceClient = serviceClient;
        }


        // GET: /<controller>/
        [Route("home")]
        public async Task<ViewResult> Index([FromQuery] string setting)
        {
            ConfigurationModel configuration = null;

            if (setting == "current")
            {
                configuration = await m_serviceClient.GetCurrentConfigurationAsync();
            }
            else if(int.TryParse(setting, out int id))
            {
                configuration = await m_serviceClient.GetConfigurationAsync(id);
            }
            

            if(configuration == default)  
            {
                return View(new HomeModel() { SettingExists = false }); 
            }

            return View(new HomeModel() { Configuration = configuration, SettingExists = true });
        }

        [Route("home/save")]
        public async Task<RedirectResult> Save(ConfigurationModel model)
        {
            int Id = await m_serviceClient.SetCurrentConfigurationAsync(model);
            return Redirect("~/home?setting=current");
        }
    }
}
