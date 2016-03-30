using System.Web.Mvc;
using System.Web.Routing;
using FabricamAPICustomAuth;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace FabricamAPICustomAuth
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			WebApiConfig.Register(app);
		}
	}
}
