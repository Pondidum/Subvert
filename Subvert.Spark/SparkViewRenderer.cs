using System.Net.Http;
using Subvert.ViewRendering;

namespace Subvert.Spark
{
	public class SparkViewRenderer : IViewRenderer
	{
		public bool CanHandle(IRequest request)
		{
			throw new System.NotImplementedException();
		}

		public HttpResponseMessage Render(object viewModel)
		{
			throw new System.NotImplementedException();
		}
	}
}
