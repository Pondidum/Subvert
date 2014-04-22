using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Subvert
{
	public class EndpointSelector : IHttpControllerSelector
	{
		private readonly HttpConfiguration _config;

		public EndpointSelector(HttpConfiguration config)
		{
			_config = config;
		}

		public HttpControllerDescriptor SelectController(HttpRequestMessage request)
		{
			return new HttpControllerDescriptor(
				_config,
				"EndpointFrontController",
				typeof(EndpointFrontController)
				);
		}

		public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
		{
			throw new NotImplementedException();
		}
	}
}
