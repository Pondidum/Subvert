using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StructureMap;
using Subvert.ViewRendering;

namespace Subvert
{
	internal class FrontController : ApiController
	{
		private readonly Router _router;
		private readonly ViewRendererFactory _rendererFactory;
		private readonly IContainer _container;

		public FrontController(Router router, ViewRendererFactory rendererFactory, IContainer container)
		{
			_router = router;
			_rendererFactory = rendererFactory;
			_container = container;
		}

		public HttpResponseMessage Handle()
		{
			var endpoint = _router.GetEndpointForRoute(Request.RequestUri);

			if (endpoint == null)
			{
				return new HttpResponseMessage(HttpStatusCode.NotFound);
			}

			var method = endpoint.GetMethod("Get");
			var modelType = method.GetParameters().First().ParameterType;

			var inputModel = _container.GetInstance(modelType);
			var instance = _container.GetInstance(endpoint);
			var viewModel = method.Invoke(instance, new[] { inputModel });

			var renderer = _rendererFactory.ForContentType(Request.Headers.Accept);

			return renderer.Render(viewModel);
		}
	}
}
