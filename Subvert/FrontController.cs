using Subvert.ViewRendering;

namespace Subvert
{
	public class FrontController : IFrontController
	{
		private readonly Router _router;
		private readonly IRouteDataBuilder _routeDataBuilder;
		private readonly ActionExecutor _actionExecutor;
		private readonly IViewRendererFactory _rendererFactory;

		public FrontController(Router router, IRouteDataBuilder routeDataBuilder, ActionExecutor actionExecutor, IViewRendererFactory rendererFactory)
		{
			_router = router;
			_routeDataBuilder = routeDataBuilder;
			_actionExecutor = actionExecutor;
			_rendererFactory = rendererFactory;
		}

		public IResponse Handle(IRequest request)
		{
			var routeData = _routeDataBuilder.Build(request);

			var action = _router.GetAction(routeData);

			if (action == null)
			{
				return new Response { StatusCode = HttpStatus.NotFound};
			}

			var viewModel = _actionExecutor.Execute(request, action);

			var renderer = _rendererFactory.ForContentType(request);

			return renderer.Render(viewModel);

		}
	}
}
