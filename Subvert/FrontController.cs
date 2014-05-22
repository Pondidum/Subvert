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
		private readonly IRequestResolver _requestResolver;
		private readonly IRouteDataBuilder _routeDataBuilder;
		private readonly ViewRendererFactory _rendererFactory;

		public FrontController(Router router,IRequestResolver requestResolver,  IRouteDataBuilder routeDataBuilder, ViewRendererFactory rendererFactory, IContainer container)
		{
			_router = router;
			_requestResolver = requestResolver;
			_routeDataBuilder = routeDataBuilder;
			_rendererFactory = rendererFactory;
		}

		public HttpResponseMessage Handle()
		{
			var routeData = _routeDataBuilder.Build(Request);

			var action = _router.GetAction(routeData);

			if (action == null)
			{
				return new HttpResponseMessage(HttpStatusCode.NotFound);
			}

			var instance = _requestResolver.GetInstance(action.EndpointType);
			var inputModel = _requestResolver.GetInstance(action.InputModelType);


			//populate inputModel

			var viewModel = action.Run(instance, inputModel);

			var renderer = _rendererFactory.ForContentType(Request.Headers.Accept);

			return renderer.Render(viewModel);

		}
	}
}
