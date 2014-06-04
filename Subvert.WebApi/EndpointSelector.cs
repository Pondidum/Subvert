using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Subvert.WebApi
{
	internal class EndpointSelector<TController> : IHttpControllerSelector where TController : ApiController
	{
		private readonly HttpControllerDescriptor _controller;

		public EndpointSelector(HttpConfiguration config)
		{
			var  controllerType = typeof(TController);

			_controller = new HttpControllerDescriptor(
				config,
				controllerType.Name,
				controllerType
			);
		}

		public HttpControllerDescriptor SelectController(HttpRequestMessage request)
		{
			return _controller;
		}

		public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
		{
			throw new NotImplementedException();
		}
	}
}
