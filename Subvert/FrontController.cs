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
			var route = new RouteData();

			var segments = Request.RequestUri.Segments.Where(s => s != "/").ToList();
			route.Endpoint = segments.FirstOrDefault();
			route.Action = segments.Skip(1).FirstOrDefault();
			route.Method = Request.Method.Method;
			
			using (var container = _container.GetNestedContainer())
			{
				var action = _router.GetAction(route);

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
