using System;

namespace Subvert.ViewRendering
{
	public interface IViewRenderer
	{
		bool CanHandle(IRequest request);

		IResponse Render(Object viewModel);
	}
}
