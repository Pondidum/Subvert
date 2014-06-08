using System;

namespace Subvert.Configuration
{
	public class ConfigurationBuilder
	{
		private readonly RendererConfiguration _rendererConfiguration;
		private readonly RouteConfiguration _routeConfiguration;

		public ConfigurationBuilder(RendererConfiguration rendererConfiguration, RouteConfiguration routeConfiguration)
		{
			_rendererConfiguration = rendererConfiguration;
			_routeConfiguration = routeConfiguration;
		}

		public void Execute<T>(Func<T> configuration) where T : SubvertConfiguration
		{
			var active = configuration();

			active.Renderers = _rendererConfiguration;
			active.Routes = _routeConfiguration;

			active.Configure();
		}

	}
}
