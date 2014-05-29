using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Subvert.ViewRendering
{
	public class ViewRendererFactory
	{
		private readonly List<IViewRenderer> _renderers;
		private readonly IViewRenderer _defaultRenderer;

		public ViewRendererFactory(IEnumerable<IViewRenderer> renderers)
		{
			_renderers = renderers.ToList();
			_defaultRenderer = _renderers.OfType<JsonViewRenderer>().Single();
		}

		public IViewRenderer ForContentType(IRequest request)
		{
			var renderer = _renderers.FirstOrDefault(r => r.CanHandle(request));

			return renderer ?? _defaultRenderer;
		}

		public void Add(IViewRenderer renderer)
		{
			_renderers.Add(renderer);
		}
	}
}
