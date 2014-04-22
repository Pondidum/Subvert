using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Subvert
{
	public static class SubvertThis
	{
		public static void Configuration(HttpConfiguration config)
		{
			config.Services.Replace(typeof(IHttpActionSelector), new EndpointActionSelector());
			config.Services.Replace(typeof(IHttpControllerSelector), new EndpointSelector(config));
		}
	}
}
