using CarForum.App_Start;
using System.Web.Http;

namespace CarForum
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IoCConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}