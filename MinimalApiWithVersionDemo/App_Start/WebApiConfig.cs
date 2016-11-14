using System.Web.Http;
using System.Web.Http.Dispatcher;
using MinimalApiWithVersionDemo.Version;

namespace MinimalApiWithVersionDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("defaultVersioned", "v{version}/{controller}/{id}", new { id = RouteParameter.Optional }, new { version = @"\d+" });
            config.Routes.MapHttpRoute("default", "{controller}/{id}", new { id = RouteParameter.Optional });
            config.Services.Replace(typeof(IHttpControllerSelector), new VersionAwareControllerSelector(config));
            config.EnableSystemDiagnosticsTracing();
        }
    }
}