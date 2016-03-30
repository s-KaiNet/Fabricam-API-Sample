using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace FabricamAPI
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.MapHttpAttributeRoutes();
		}
	}
}
