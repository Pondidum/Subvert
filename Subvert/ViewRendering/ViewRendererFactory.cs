using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Subvert.ViewRendering
{
	public class ViewRendererFactory
	{
		private readonly IEnumerable<IViewRenderer> _renderers;
		private readonly IViewRenderer _defaultRenderer;

		public ViewRendererFactory(IEnumerable<IViewRenderer> renderers)
		{
			_renderers = renderers;
			_defaultRenderer = _renderers.OfType<JsonViewRenderer>().Single();
		}

		public IViewRenderer ForContentType(IRequest request)
		{
			var renderer = _renderers.FirstOrDefault(r => r.CanHandle(request));

			return renderer ?? _defaultRenderer;
		}
	}
}
