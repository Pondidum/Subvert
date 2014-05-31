using System;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using StructureMap;
using StructureMap.Graph;
using Subvert.Configuration;
using Subvert.Infrastructure;
using Subvert.ViewRendering;

namespace Subvert
{
	public static class SubvertThis
	{
		public static void Configure<T>(HttpConfiguration config) where T : SubvertConfiguration, new()
		{
			Configure(config, () => new T());
		}

		public static void Configure(HttpConfiguration config, Func<SubvertConfiguration> configuration)
		{

			var container = new Container(c => c.Scan(a =>
			{
				a.TheCallingAssembly();
				a.LookForRegistries();
				
				c.For<HostAssembly>().Singleton();
				c.For<IViewRendererFactory>().Singleton();
			}));

			GlobalConfiguration.Container = container;

			configuration();

			config.DependencyResolver = new StructureMapDependencyResolver(container);

			config.Services.Replace(typeof(IHttpActionSelector), new EndpointActionSelector());
			config.Services.Replace(typeof(IHttpControllerSelector), new EndpointSelector<FrontController>(config));

			config.Routes.MapHttpRoute(name: "Subvert.Route", routeTemplate: "{*url}");
		}
	}
}
