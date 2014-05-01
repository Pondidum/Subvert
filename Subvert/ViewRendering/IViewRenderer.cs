using System;
using System.Net.Http;

namespace Subvert.ViewRendering
{
	public interface IViewRenderer
	{
		bool CanHandle(string contentType);

		HttpResponseMessage Render(Object viewModel);
	}
}
