using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web.Http;
using StructureMap;

namespace Subvert
{
	internal class FrontController : ApiController
	{
		private readonly Router _router;
		private readonly IJsonSerializer _serializer;
		private readonly IContainer _container;

		public FrontController(Router router, IJsonSerializer serializer, IContainer container)
		{
			_router = router;
			_serializer = serializer;
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

			//content negotiation to work out how to send it back...json for now

			var json = _serializer.Serialize(viewModel);
			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(json, Encoding.UTF8, "text/json")
			};
		}
	}
}
