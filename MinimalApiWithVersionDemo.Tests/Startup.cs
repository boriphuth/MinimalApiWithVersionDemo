using System.Web.Http.Dispatcher;
using MinimalApiWithVersionDemo.Version;
using Owin;
using System.Web.Http; 


namespace MinimalApiWithVersionDemo.Tests
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("defaultVersioned", "v{version}/{controller}/{id}", new { id = RouteParameter.Optional }, new { version = @"\d+" });
            config.Routes.MapHttpRoute("default", "{controller}/{id}", new { id = RouteParameter.Optional });
            config.Services.Replace(typeof(IHttpControllerSelector), new VersionAwareControllerSelector(config));

            appBuilder.UseWebApi(config);
        } 
    }
}
