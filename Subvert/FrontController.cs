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
		private readonly Container _container;

		public FrontController(Router router, IJsonSerializer serializer)
		{
			_router = router;
			_serializer = serializer;
		}

		public HttpResponseMessage Handle()
		{
			var endpoint = _router.GetEndpointForRoute(Request.RequestUri.PathAndQuery);
			var method = endpoint.GetMethod("Get");
			var modelType = method.GetParameters().First().ParameterType;

			var modelInstance = modelType.GetConstructor(Type.EmptyTypes).Invoke(new object[] { });

			var instance = endpoint.GetConstructor(Type.EmptyTypes).Invoke(new object[] { });

			var viewModel = method.Invoke(instance, new[] { modelInstance });

			//content negotiation to work out how to send it back...json for now

			var json = _serializer.Serialize(viewModel);
			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(json, Encoding.UTF8, "text/json")
			};
		}
	}
}
