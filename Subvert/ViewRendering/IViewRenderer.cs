using System;
using System.Net.Http;

namespace Subvert.ViewRendering
{
	public interface IViewRenderer
	{
		bool CanHandle(IRequest request);

		HttpResponseMessage Render(Object viewModel);
	}
}
