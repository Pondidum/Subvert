using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Subvert.Spark.Configuration;
using Subvert.ViewRendering;

namespace Subvert.Spark
{
	public class SparkViewRenderer : IViewRenderer
	{
		private readonly SparkEngine _engine;

		public SparkViewRenderer(ISparkConfiguration settings)
		{
			_engine = new SparkEngine(new DescriptorBuilder(settings));
		}

		public bool CanHandle(IRequest request)
		{
			return true;
		}

		public HttpResponseMessage Render(object viewModel)
		{
			var view = _engine.CreateView(viewModel);

			var content = new PushStreamContent((responseStream, cont, context) =>
			{
				using (var writer = new StreamWriter(responseStream))
				{
					view.RenderView(writer);
				}
				responseStream.Close();
			});

			content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = content
			};
		}
	}
}
