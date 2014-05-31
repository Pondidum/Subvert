using System.Collections.Generic;

namespace Subvert.ViewRendering
{
	public interface IViewRendererFactory
	{
		List<IViewRenderer> Renderers { get; }
		IViewRenderer ForContentType(IRequest request);
	}
}
