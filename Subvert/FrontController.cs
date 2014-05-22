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
		private readonly IRouteDataBuilder _routeDataBuilder;
		private readonly ViewRendererFactory _rendererFactory;
		private readonly IContainer _container;

		public FrontController(Router router, IRouteDataBuilder routeDataBuilder, ViewRendererFactory rendererFactory, IContainer container)
		{
			_router = router;
			_routeDataBuilder = routeDataBuilder;
			_rendererFactory = rendererFactory;
			_container = container;
		}

		public HttpResponseMessage Handle()
		{
			var routeData = _routeDataBuilder.Build(Request);
			
			using (var container = _container.GetNestedContainer())
			{
				var action = _router.GetAction(routeData);

				if (action == null)
				{
					return new HttpResponseMessage(HttpStatusCode.NotFound);
				}

				var instance = container.GetInstance(action.EndpointType);
				var inputModel = container.GetInstance(action.InputModelType);
				

				//populate inputModel

				var viewModel = action.Run(instance, inputModel);

				var renderer = _rendererFactory.ForContentType(Request.Headers.Accept);

				return renderer.Render(viewModel);
			}
		}
	}
}
