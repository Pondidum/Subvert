using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using StructureMap;
using StructureMap.Graph;
using Subvert.Infrastructure;

namespace Subvert
{
	public static class SubvertThis
	{
		public static void Configuration(Type hostType, HttpConfiguration config)
		{
			var container = new Container(c =>
			{
				c.Scan(a =>
				{
					a.TheCallingAssembly();
					a.LookForRegistries();
					a.WithDefaultConventions();
				});

				c.For<HostAssembly>()
					.Use(() => new HostAssembly(hostType))
					.Singleton();
			});

			config.DependencyResolver = new StructureMapDependencyResolver(container);

			config.Services.Replace(typeof(IHttpActionSelector), new EndpointActionSelector());
			config.Services.Replace(typeof(IHttpControllerSelector), new EndpointSelector<FrontController>(config));


		}
	}
}
