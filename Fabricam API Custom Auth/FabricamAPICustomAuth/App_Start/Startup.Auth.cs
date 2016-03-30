using System.Configuration;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

namespace FabricamAPICustomAuth
{
	public partial class Startup
	{
		public void ConfigureAuth(IAppBuilder app)
		{
			app.UseCors(CorsOptions.AllowAll);

			app.UseWindowsAzureActiveDirectoryBearerAuthentication(
				new WindowsAzureActiveDirectoryBearerAuthenticationOptions
				{
					Tenant = ConfigurationManager.AppSettings["Tenant"],
					TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = false,
						ValidAudience = ConfigurationManager.AppSettings["ClientId"]
					}
				});
		}

	}
}
