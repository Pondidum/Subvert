using System;
using System.Linq;

namespace Subvert
{
	public class Router
	{
		private readonly EndpointDiscovery _endpoints;

		public Router(EndpointDiscovery endpoints)
		{
			_endpoints = endpoints;
		}

		public Type GetEndpointForRoute(string route)
		{
			return _endpoints.GetEndpoints().First();
		}
	}
}
