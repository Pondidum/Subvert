using System.Collections.Generic;
using System.Linq;

namespace Subvert.ViewRendering
{
	public class ViewRendererFactory : IViewRendererFactory
	{
		private readonly IViewRenderer _defaultRenderer;

		public List<IViewRenderer> Renderers { get; private set; }

		public ViewRendererFactory(IEnumerable<IViewRenderer> renderers)
		{
			Renderers = renderers.ToList();
			_defaultRenderer = Renderers.OfType<JsonViewRenderer>().Single();
		}

		public IViewRenderer ForContentType(IRequest request)
		{
			var renderer = Renderers.FirstOrDefault(r => r.CanHandle(request));

			return renderer ?? _defaultRenderer;
		}
	}
}
