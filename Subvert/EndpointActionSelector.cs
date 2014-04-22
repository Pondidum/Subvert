using System;
using System.Linq;
using System.Web.Http.Controllers;

namespace Subvert
{
	public class EndpointActionSelector : IHttpActionSelector
	{
		public HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
		{
			var type = typeof(EndpointFrontController);
			var method = type.GetMethod("Handle");

			return new ReflectedHttpActionDescriptor(
				controllerContext.ControllerDescriptor,
				method
				);
		}

		public ILookup<string, HttpActionDescriptor> GetActionMapping(HttpControllerDescriptor controllerDescriptor)
		{
			throw new NotImplementedException();
		}
	}
}
