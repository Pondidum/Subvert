using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Subvert.WebApi
{
	public class WebApiHook
	{
		public WebApiHook(IFrontController frontController, HttpConfiguration config)
			: this(frontController, config, "{*url}")
		{
		}

		public WebApiHook(IFrontController frontController, HttpConfiguration config, string baseRoute)
		{
			ServiceLocator.FrontController = frontController;

			config.Services.Replace(typeof(IHttpActionSelector), new EndpointActionSelector());
			config.Services.Replace(typeof(IHttpControllerSelector), new EndpointSelector<WebApiController>(config));

			config.Routes.MapHttpRoute(name: "Subvert.Route", routeTemplate: baseRoute);
		}
	}
}
