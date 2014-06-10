using System.Collections.Generic;
using System.Linq;
using Subvert.Configuration;

namespace Subvert.ViewRendering
{
	public class ViewRendererFactory : IViewRendererFactory
	{
		private readonly RendererConfiguration _configuration;
		private readonly IViewRenderer _defaultRenderer;

		public ViewRendererFactory(RendererConfiguration configuration)
		{
			_configuration = configuration;
			_defaultRenderer = _configuration.Renderers.OfType<JsonViewRenderer>().Single();
		}

		public IViewRenderer ForContentType(IRequest request)
		{
			var renderer = _configuration.Renderers.FirstOrDefault(r => r.CanHandle(request));

			return renderer ?? _defaultRenderer;
		}
	}
}
