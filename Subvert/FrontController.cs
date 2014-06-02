using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using StructureMap;
using Subvert.ModelBinding;
using Subvert.ViewRendering;

namespace Subvert
{
	internal class FrontController : ApiController
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

		public HttpResponseMessage Handle()
		{
			var request = new Request(Request);
			var routeData = _routeDataBuilder.Build(request);

			var action = _router.GetAction(routeData);

			if (action == null)
			{
				return new HttpResponseMessage(HttpStatusCode.NotFound);
			}

			var instance = _requestResolver.GetInstance(action.EndpointType);
			var inputModel = _requestResolver.GetInstance(action.InputModelType);

			_modelBinder.Bind(request, inputModel);

			var viewModel = action.Run(instance, inputModel);
			var renderer = _rendererFactory.ForContentType(request);

			return BuildResponse(renderer.Render(viewModel));

		}

		private HttpResponseMessage BuildResponse(IResponse response)
		{
			var content = new PushStreamContent((responseStream, cont, context) =>
			{
				response.ContentStream.CopyTo(responseStream);
				responseStream.Close();
				response.ContentStream.Close();
			});

			content.Headers.ContentType = new MediaTypeHeaderValue(response.ContentType);

			var message = new HttpResponseMessage
			{
				StatusCode = (HttpStatusCode)response.StatusCode,
				Content = content,
			};

			return message;
		}
	}
}
