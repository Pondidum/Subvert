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

		public SparkViewRenderer()
			: this(SparkConfiguration.Default)
		{
		}

		public SparkViewRenderer(ISparkConfiguration settings)
		{
			_engine = new SparkEngine(new DescriptorBuilder(settings));
		}

		public bool CanHandle(IRequest request)
		{
			return true;
		}

		public IResponse Render(object viewModel)
		{
			var view = _engine.CreateView(viewModel);
			
			var ms = new MemoryStream();
			var writer = new StreamWriter(ms);
			
			view.RenderView(writer);
			
			writer.Flush();
			ms.Position = 0;

			return new Response
			{
				StatusCode = HttpStatus.Ok, 
				ContentStream = ms,
				ContentType = "text/html"
			};
		}
	}
}
