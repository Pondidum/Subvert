using System;

namespace Subvert.Configuration
{
	public class ConfigurationBuilder
	{
		private readonly RendererConfiguration _rendererConfiguration;

		public ConfigurationBuilder(RendererConfiguration rendererConfiguration)
		{
			_rendererConfiguration = rendererConfiguration;
		}

		public void Execute<T>(Func<T> configuration) where T : SubvertConfiguration
		{
			var active = configuration();

			active.Renderers = _rendererConfiguration;

			active.Configure();
		}

	}
}
