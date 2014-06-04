using Subvert.ModelBinding;
using Subvert.ViewRendering;

namespace Subvert
{
	public class FrontController : IFrontController
	{
		private readonly Router _router;
		private readonly IRequestResolver _requestResolver;
		private readonly IRouteDataBuilder _routeDataBuilder;
		private readonly ModelBinder _modelBinder;
		private readonly IViewRendererFactory _rendererFactory;

		public FrontController(Router router, IRequestResolver requestResolver, IRouteDataBuilder routeDataBuilder, ModelBinder modelBinder, IViewRendererFactory rendererFactory)
		{
			_router = router;
			_requestResolver = requestResolver;
			_routeDataBuilder = routeDataBuilder;
			_modelBinder = modelBinder;
			_rendererFactory = rendererFactory;
		}

		public IResponse Handle(IRequest request)
		{
			var routeData = _routeDataBuilder.Build(request);

			var action = _router.GetAction(routeData);

			if (action == null)
			{
				return new Response() { StatusCode = HttpStatus.NotFound};
			}

			var instance = _requestResolver.GetInstance(action.EndpointType);
			var inputModel = _requestResolver.GetInstance(action.InputModelType);

			_modelBinder.Bind(request, inputModel);

			var viewModel = action.Run(instance, inputModel);
			var renderer = _rendererFactory.ForContentType(request);

			return renderer.Render(viewModel);

		}

	}
}
